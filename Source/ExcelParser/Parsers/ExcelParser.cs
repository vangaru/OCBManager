using OCBManager.Domain.Parsing;
using OCBManager.Domain.Models;
using OfficeOpenXml;
using Microsoft.Office.Interop.Excel;

namespace OCBManager.ExcelParser.Parsers
{
    // Should be totally refactored. Didn't have enough time to investigate EPPlus
    public class ExcelParser : ISheetParser
    {
        private const string FirstClassAddress = "A9";

        public TurnoverSheet Parse(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            // EPPlus cannot handle .xls files.
            string xlsxPath = IsXlsFile(path) 
                ? ConvertToXlsx(path) 
                : path;

            using (var package = new ExcelPackage(new FileInfo(xlsxPath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
                TrimEnd(worksheet);
                TurnoverSheet turnoverSheet = ParseTurnoverSheet(worksheet);
                return turnoverSheet;
            }
        }

        private string ConvertToXlsx(string path)
        {
            var app = new Application();
            string xlsFile = path;
            Workbook wb = app.Workbooks.Open(xlsFile);
            string xlsxFile = xlsFile + "x";
            wb.SaveAs(Filename: xlsxFile, FileFormat:XlFileFormat.xlOpenXMLWorkbook);
            wb.Close();
            app.Quit();
            File.Delete(path);
            return xlsxFile;
        }

        private bool IsXlsFile(string path)
        {
            return string.Equals(Path.GetExtension(path), ".xls", StringComparison.OrdinalIgnoreCase);
        }

        private TurnoverSheet ParseTurnoverSheet(ExcelWorksheet worksheet)
        {
            ExcelRange dimensionCells = worksheet.Cells[worksheet.Dimension.FullAddress];
            if (dimensionCells.Value is Array contentsArr && contentsArr.Rank == 2)
            {
                var turnoverSheet = new TurnoverSheet();
                var contentValues = (object?[,])contentsArr;
                List<BillClass> billClasses = ParseBillClasses(worksheet, worksheet.AutoFilterAddress);
                turnoverSheet.BillClasses = billClasses;
                turnoverSheet.Name = $"{ConvertObject<string>(contentValues[1, 0])} {ConvertObject<string>(contentValues[2, 0])} {ConvertObject<string>(contentValues[2, 0])}";
                decimal[] summary = ParseTurnoverSheetSummary(dimensionCells);
                turnoverSheet.IncomingBalanceActive = summary[0];
                turnoverSheet.IncomingBalancePassive = summary[1];
                turnoverSheet.TurnoverDebit = summary[2];
                turnoverSheet.TurnoverCredit = summary[3];
                turnoverSheet.OutgoingBalanceActive = summary[4];
                turnoverSheet.OutgoingBalancePassive = summary[5];
                return turnoverSheet;
            }

            throw new ApplicationException($"Excel format exception: Failed to parse contents");
        }

        private List<BillClass> ParseBillClasses(ExcelWorksheet worksheet, ExcelAddressBase filterAddress)
        {
            object value = worksheet.Cells[filterAddress.FullAddress].Value;

            if (value is Array contentsArr && contentsArr.Rank == 2)
            {
                var values = (object?[,])contentsArr;
                ExcelRange firstClassRange = worksheet.Cells[FirstClassAddress];
                object?[,] billValues = PrepareContentValues(firstClassRange, values);
                
                var billClasses = new List<BillClass>();
                List<(int StartIndex, int EndIndex)> billClassRanges = GetBillClassRanges(billValues);
                foreach ((int startIndex, int endIndex) in billClassRanges)
                {
                    billClasses.Add(ParseBillClass(startIndex, endIndex, billValues));
                }

                return billClasses;
            }

            throw new ApplicationException($"Excel format exception: Failed to parse contents");
        }

        private object?[,] PrepareContentValues(ExcelRange firstClassRange, object?[,] contents)
        {
            if (firstClassRange.Value is string firstClass)
            {
                var values = new object?[contents.GetLength(0) + 1, contents.GetLength(1)];
                values[0, 0] = firstClass;
                for (var i = 1; i < contents.GetLength(0); i++)
                {
                    for (var j = 0; j < contents.GetLength(1); j++)
                    {
                        values[i, j] = contents[i - 1, j];
                    }
                }

                return values;
            }

            return contents;
        }

        private List<(int StartIndex, int EndIndex)> GetBillClassRanges(object?[,] values)
        {
            if (!IsClass(values[0, 0]))
            {
                throw new ApplicationException("Bills must start with a class declaration.");
            }

            var ranges = new List<(int StartIndex, int EndIndex)>();

            int? currentStartIndex = null;
            int? currentEndIndex = null;

            for (var i = 0; i < values.GetLength(0); i++)
            {
                if (IsClass(values[i, 0]))
                {
                    if (currentStartIndex != null)
                    {
                        // Better to introduce new ExcelFormatException class but I have no time.
                        throw new ApplicationException("Excel format exception: new class cannot begin when another class is not closed.");
                    }

                    currentStartIndex = i;
                }
                else if (IsClassSummary(values[i, 0]))
                {
                    if (currentEndIndex != null)
                    {
                        throw new ApplicationException("Excel format exception: new class cannot be summarized until it is not defined");
                    }

                    currentEndIndex = i;

                    if (currentStartIndex == null)
                    {
                        throw new ApplicationException("Excel format exception: undefined class cannot be summarized");
                    }

                    ranges.Add((currentStartIndex.Value, currentEndIndex.Value));
                    currentStartIndex = null;
                    currentEndIndex = null;
                }
            }

            return ranges;
        }

        private bool IsClass(object? obj)
        {
            return obj is string @class && @class.StartsWith("КЛАСС");
        }

        private bool IsClassSummary(object? obj)
        {
            return obj is string summary && summary.StartsWith("ПО КЛАССУ");
        }

        private BillClass ParseBillClass(int startIndex, int endIndex, object?[,] values)
        {
            var billClass = new BillClass();
            billClass.Name = ConvertObject<string>(values[startIndex, 0]);
            billClass.IncomingBalanceActive = ConvertObject<decimal>(values[endIndex, 1]);
            billClass.IncomingBalancePassive = ConvertObject<decimal>(values[endIndex, 2]);
            billClass.TurnoverDebit = ConvertObject<decimal>(values[endIndex, 3]);
            billClass.TurnoverCredit = ConvertObject<decimal>(values[endIndex, 4]);
            billClass.OutgoingBalanceActive = ConvertObject<decimal>(values[endIndex, 5]);
            billClass.OutgoingBalancePassive = ConvertObject<decimal>(values[endIndex, 6]);

            for (var i = startIndex + 1; i < endIndex; i++)
            {
                var bill = new Bill
                {
                    BillNumber = ConvertObject<int>(values[i, 0]),
                    IncomingBalanceActive = ConvertObject<decimal>(values[i, 1]),
                    IncomingBalancePassive = ConvertObject<decimal>(values[i, 2]),
                    TurnoverDebit = ConvertObject<decimal>(values[i, 3]),
                    TurnoverCredit = ConvertObject<decimal>(values[i, 4]),
                    OutgoingBalanceActive = ConvertObject<decimal>(values[i, 5]),
                    OutgoingBalancePassive = ConvertObject<decimal>(values[i, 6])
                };

                billClass.Bills.Add(bill);
            }

            return billClass;
        }

        private T ConvertObject<T>(object? obj)
        {
            object? result = Convert.ChangeType(obj, typeof(T));
            return (T)(result ?? throw new ApplicationException($"Failed to convert object {obj} to type {typeof(T)}")); 
        }

        private void TrimEnd(ExcelWorksheet worksheet)
        {
            object value = worksheet.Cells[worksheet.Dimension.FullAddress].Value;
            if (value is Array array && array.Rank == 2)
            {
                var values = (object?[,])array;
                for (int i = values.GetLength(0) - 1; i >= 0; i--)
                {
                    for (var j = 0; j < values.GetLength(1); j++)
                    {
                        if (values[i, j] != null)
                        {
                            return;
                        }
                    }

                    worksheet.DeleteRow(i + 1);
                }
            }
        }

        private decimal[] ParseTurnoverSheetSummary(ExcelRange dimension)
        {
            var summary = new decimal[6];

            object value = dimension.Value;
            if (value is Array array && array.Rank == 2)
            {
                var values = (object?[,])array;
                for (var j = 1; j < 7; j++)
                {
                    summary[j - 1] = ConvertObject<decimal>(values[dimension.Rows - 1, j]);
                }
            }

            return summary;
        }
    }
}
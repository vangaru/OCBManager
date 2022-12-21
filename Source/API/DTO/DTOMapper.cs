using OCBManager.Domain.Models;
using System.Collections.ObjectModel;

namespace OCBManager.API.DTO
{
    internal static class DTOMapper
    {
        public static IReadOnlyCollection<TurnoverSheetSummaryDTO> GetTurnoverSheetSummary(IEnumerable<TurnoverSheet> turnoverSheet)
        {
            return new ReadOnlyCollection<TurnoverSheetSummaryDTO>(turnoverSheet.Select(sheet => new TurnoverSheetSummaryDTO(
                sheet.Id, sheet.Name,
                sheet.IncomingBalanceActive, sheet.IncomingBalancePassive,
                sheet.TurnoverDebit, sheet.TurnoverCredit,
                sheet.OutgoingBalanceActive, sheet.OutgoingBalancePassive)).ToList()); 
        }

        public static TurnoverSheetDetailsDTO GetTurnoverSheetDetails(TurnoverSheet turnoverSheet)
        {
            return new TurnoverSheetDetailsDTO(
                turnoverSheet.Name,
                turnoverSheet.IncomingBalanceActive, turnoverSheet.IncomingBalancePassive,
                turnoverSheet.TurnoverDebit, turnoverSheet.TurnoverCredit,
                turnoverSheet.OutgoingBalanceActive, turnoverSheet.OutgoingBalancePassive,
                GetBillClassDTOs(turnoverSheet.BillClasses));
        }

        private static List<BillClassDTO> GetBillClassDTOs(List<BillClass> billClasses)
        {
            return billClasses.Select(billClass => new BillClassDTO(
                billClass.Name,
                billClass.IncomingBalanceActive, billClass.IncomingBalancePassive,
                billClass.TurnoverDebit, billClass.TurnoverCredit,
                billClass.OutgoingBalanceActive, billClass.OutgoingBalancePassive,
                GetBillDTOs(billClass))).ToList();
        }

        private static List<BillDTO> GetBillDTOs(BillClass billClass)
        {
            return billClass.Bills.Select(bill => new BillDTO(
                bill.BillNumber,
                bill.IncomingBalanceActive, bill.IncomingBalancePassive,
                bill.TurnoverDebit, bill.TurnoverCredit,
                bill.OutgoingBalanceActive, bill.OutgoingBalancePassive)).ToList();
        }
    }
}
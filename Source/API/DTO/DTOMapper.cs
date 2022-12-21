using OCBManager.Domain.Models;
using System.Collections.ObjectModel;

namespace OCBManager.API.DTO
{
    public static class DTOMapper
    {
        public static IReadOnlyCollection<TurnoverSheetSummaryDTO> GetTurnoverSheetSummary(IEnumerable<TurnoverSheet> turnoverSheet)
        {
            return new ReadOnlyCollection<TurnoverSheetSummaryDTO>(turnoverSheet.Select(sheet => new TurnoverSheetSummaryDTO(
                sheet.Id, sheet.Name,
                sheet.IncomingBalanceActive, sheet.IncomingBalancePassive,
                sheet.TurnoverDebit, sheet.TurnoverCredit,
                sheet.OutgoingBalanceActive, sheet.OutgoingBalancePassive)).ToList()); 
        }
    }
}
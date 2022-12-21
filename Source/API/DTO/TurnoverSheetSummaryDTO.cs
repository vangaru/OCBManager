namespace OCBManager.API.DTO
{
    public record TurnoverSheetSummaryDTO(
        int Id, string Name,
        decimal IncomingBalanceActive,
        decimal IncomingBalancePassive,
        decimal TurnoverDebit,
        decimal TurnoverCredit,
        decimal OutgoingBalanceActive,
        decimal OutgoingBalancePassive);
}

namespace OCBManager.API.DTO
{
    public record TurnoverSheetDetailsDTO(
        string Name,
        decimal IncomingBalanceActive,
        decimal IncomingBalancePassive,
        decimal TurnoverDebit,
        decimal TurnoverCredit,
        decimal OutgoingBalanceActive,
        decimal OutgoingBalancePassive,
        List<BillClassDTO> BillClasses);

    public record BillClassDTO(
        int Id,
        string Name,
        decimal IncomingBalanceActive,
        decimal IncomingBalancePassive,
        decimal TurnoverDebit,
        decimal TurnoverCredit,
        decimal OutgoingBalanceActive,
        decimal OutgoingBalancePassive,
        List<BillDTO> Bills);

    public record BillDTO(
        int BillNumber,
        decimal IncomingBalanceActive,
        decimal IncomingBalancePassive,
        decimal TurnoverDebit,
        decimal TurnoverCredit,
        decimal OutgoingBalanceActive,
        decimal OutgoingBalancePassive);
}

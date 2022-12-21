export interface TurnoverSheetSummaryDto {
    id: number, 
    name: string,
    incomingBalanceActive: number,
    incomingBalancePassive: number,
    turnoverDebit: number,
    turnoverCredit: number,
    outgoingBalanceActive: number,
    outgoingBalancePassive: number
}
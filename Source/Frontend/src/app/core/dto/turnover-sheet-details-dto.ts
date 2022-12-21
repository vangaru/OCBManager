import { BillClassDto } from "./bill-class-dto";

export interface TurnoverSheetDetailsDto {
    name: string,
    incomingBalanceActive: number,
    incomingBalancePassive: number,
    turnoverDebit: number,
    turnoverCredit: number,
    outgoingBalanceActive: number,
    outgoingBalancePassive: number,
    billClasses: BillClassDto[]
}
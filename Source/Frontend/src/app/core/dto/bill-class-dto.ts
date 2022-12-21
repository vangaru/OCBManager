import { BillDto } from "./bill-dto";

export interface BillClassDto {
    id: number,
    name: string,
    incomingBalanceActive: number,
    incomingBalancePassive: number,
    turnoverDebit: number,
    turnoverCredit: number,
    outgoingBalanceActive: number,
    outgoingBalancePassive: number,
    bills: BillDto[]
}
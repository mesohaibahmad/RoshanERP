import { Transaction } from './transaction.model';
export interface Bill {
    invoiceType: string,
    supplierBalance: any,
    customerBalance: any,
   transactions: Transaction[],

}
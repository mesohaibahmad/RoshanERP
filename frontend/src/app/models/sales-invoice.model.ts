import { InvoiceItem } from './invoice-item.model';

export interface SalesInvoice {
  date: string;
  type: string;
  invoiceNo: number;
  customer: string;
  salesman: string;
  items: InvoiceItem[];
}

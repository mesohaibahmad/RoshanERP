import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SalesInvoiceServiceService } from './services/sales-invoice-service.service';
import { Transaction } from './models/transaction.model';
import { Bill } from './models/bill';

@Component({
  selector: 'app-sales-invoice',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './sales-invoice.component.html',
  styleUrls: ['./sales-invoice.component.css']
})
export class SalesInvoiceComponent {
constructor(private invoiceService: SalesInvoiceServiceService) { }

  supplier= {id: 0, name: '', balance: 0 };
  billDetail={date: '', invoiceType: ''};
  customer ={id: 0, name: '', balance: 0 };
  product = {     id: 0,
    name: '',
    unit: '',
    laga: 0,
    quantity: 0,
    rate: 0}
transactions : any[] = [];

  addRow() {
    let item = {
   date: this.billDetail.date,
    invoiceType: this.billDetail.invoiceType,

    // Supplier Info
    supplierId: this.supplier.id,
    supplierName: this.supplier.name,
    supplierBalance: this.supplier.balance,

    // Customer Info
    customerId: this.customer.id,
    customerName: this.customer.name,
    customerBalance: this.customer.balance,

    // Product / Item Info
    productId: this.product.id,
    productName: this.product.name,
    productUnit: this.product.unit,
    laga: this.product.laga,
    quantity: this.product.quantity,
    rate: this.product.rate,
    amount: this.product.quantity * this.product.rate, // calculate total
    }
     this.transactions.push(item);
  }

  calculate(item: any) {
    item.total = (item.qty * item.rate) - item.discount;
  }

  get grandTotal() {
    return "this.bill.transactions.reduce((sum:any,i:any)=>sum+i.total,0)";
  }
  getProductInfo(id: number) {
    return "this.bill.transactions.reduce((sum:any,i:any)=>sum+i.total,0)";
  }
   getCustomerInfo(id: number) {
    return "this.bill.transactions.reduce((sum:any,i:any)=>sum+i.total,0)";
  }

 saveInvoice() {
let bill: Bill ={
    invoiceType: '', 
    supplierBalance: 0,
    customerBalance: 0,
    transactions: []
};
  this.transactions.forEach(transaction => {
    bill.transactions.push({
  id: 0,
  date: transaction.date,
  supplierId: transaction.supplierId ?? null,
  customerId: transaction.customerId ?? null,
  productId: transaction.productId,
  quantity: transaction.quantity,
  rate: transaction.rate,
  totalLaga: transaction.totalLaga ?? null,
  discount: transaction.discount ?? null,
  amount: transaction.amount,
  paymentType: transaction.paymentType || ''
});
  });
bill.invoiceType = this.billDetail.invoiceType;
console.log(bill);

this.invoiceService.saveBill(bill).subscribe(response => {
  console.log('Bill saved successfully', response);
}, error => {
  console.error('Error saving bill', error);
});   
  }
}
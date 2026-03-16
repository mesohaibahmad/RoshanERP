import { Component, OnInit } from '@angular/core';
import { TransactionsService } from './transactions.service';
import { AccountsService } from '../accounts/accounts.service';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-transactions',
    standalone: true,
  imports: [CommonModule, TranslateModule],
  template: `<div style="padding:16px">
    <h2>{{ 'TRANSACTIONS.TITLE' | translate }}</h2>
    <button (click)="openAdd()">+ Add</button>
    <ul>
      <li *ngFor="let t of txs">
        {{t.date | date:'short'}} - {{t.accountName}} - {{t.side}} - {{t.amount}}
      </li>
    </ul>
  </div>`
})
export class TransactionsComponent implements OnInit {
  txs: any[] = [];
  accounts: any[] = [];
  constructor(private svc: TransactionsService, private accSvc: AccountsService) {}
  ngOnInit() { this.load(); this.accSvc.list().subscribe((r:any)=>this.accounts=r); }
  load() { this.svc.list().subscribe((r:any)=>this.txs=r); }
  openAdd() {
    const accId = parseInt(prompt('AccountId (choose from console)') || '0');
    const side = prompt('Side (Debit/Credit)') || 'Debit';
    const amount = parseFloat(prompt('Amount') || '0');
    if (accId && amount) {
      this.svc.create({accountId: accId, side, amount, date: new Date()}).subscribe(()=>this.load());
    }
  }
}

import { Component, OnInit } from '@angular/core';
import { AccountsService } from './accounts.service';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-accounts',
    standalone: true,
  imports: [CommonModule, TranslateModule],
  template: `<div style="padding:16px">
    <h2>{{ 'ACCOUNTS.TITLE' | translate }}</h2>
    <button (click)="openAdd()">+ {{ 'ACCOUNTS.ADD' | translate }}</button>
    <ul>
      <li *ngFor="let a of accounts">
        {{a.name}} ({{a.type}})
      </li>
    </ul>
  </div>`
})
export class AccountsComponent implements OnInit {
  accounts: any[] = [];
  constructor(private svc: AccountsService) {}
  ngOnInit() { this.load(); }
  load() { this.svc.list().subscribe((r:any) => this.accounts = r); }
  openAdd() { const name = prompt('Name'); const type = prompt('Type'); if (name && type) this.svc.create({name,type}).subscribe(()=>this.load()); }
}

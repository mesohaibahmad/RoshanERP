// 

import { Component } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  // imports: [CommonModule, RouterModule, TranslateModule, AccountsComponent, TransactionsComponent],
    imports: [CommonModule, RouterModule],
  templateUrl: "./app.component.html"
  // template: `
  //   <div style="padding:20px">
  //     <h1>{{ 'DASHBOARD.WELCOME' | translate }}</h1>
  //     <p>{{ 'DASHBOARD.TOTAL_ASSETS' | translate }}: 0</p>

  //     <app-accounts></app-accounts>
  //     <app-transactions></app-transactions>
  //   </div>

  //   <router-outlet></router-outlet>
  // `
})
export class AppComponent {
  constructor(private translate: TranslateService) {
    translate.setDefaultLang('ur');
    translate.use('ur');
    document.documentElement.lang = 'ur';
    document.documentElement.dir = 'rtl';
  }

}


import { Routes } from '@angular/router';
import { AccountsComponent } from './features/accounts/accounts.component';
import { TransactionsComponent } from './features/transactions/transactions.component';
import { LayoutComponent } from './Components/layout/layout.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { inject } from '@angular/core';
import { AuthService } from './core/auth/auth.service';
import { map } from 'rxjs/operators';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./Components/login/login.component').then(m => m.LoginComponent), canActivate: [()=> inject(AuthService).isAuthenticated.pipe(map(isAuth => !isAuth))], pathMatch: 'full' },
{ path: 'accounts', component: AccountsComponent },
  { path: 'login', loadComponent: () => import('./Components/login/login.component').then(m => m.LoginComponent), canActivate: [()=> inject(AuthService).isAuthenticated.pipe(map(isAuth => !isAuth))] },
    { path: 'register', loadComponent: () => import('./Components/register/register.component').then(m => m.RegisterComponent), canActivate: [()=> inject(AuthService).isAuthenticated.pipe(map(isAuth => !isAuth))] },
  {path:'', component: LayoutComponent,
    children: [
      {path:'dashboard', component: DashboardComponent, title:'Dashboard', canActivate: [()=> inject(AuthService).isAuthenticated  ]},
        { path: 'sales-invoice', loadComponent: () => import('./features/sales-invoice/sales-invoice.component').then(m => m.SalesInvoiceComponent), title:'SalesInvoice', canActivate: [()=> inject(AuthService).isAuthenticated  ]  },
    ]
    
    
  },
  { path: 'transactions', component: TransactionsComponent },
  
  { path: '**', redirectTo: 'accounts' }
];

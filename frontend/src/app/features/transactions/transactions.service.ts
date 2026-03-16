import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class TransactionsService {
  api = 'https://localhost:7232/api/transactions';
  constructor(private http: HttpClient) {}
  list() { return this.http.get<any[]>(this.api); }
  create(data: any) { return this.http.post(this.api, data); }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AccountsService {
  api = 'https://localhost:7232/api/accounts';
  constructor(private http: HttpClient) {}
  list() { return this.http.get<any[]>(this.api); }
  create(data: any) { return this.http.post(this.api, data); }
  update(id: number, data: any) { return this.http.put(`${this.api}/${id}`, data); }
  delete(id: number) { return this.http.delete(`${this.api}/${id}`); }
}

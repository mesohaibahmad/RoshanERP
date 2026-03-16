import { TestBed } from '@angular/core/testing';

import { SalesInvoiceServiceService } from './sales-invoice-service.service';

describe('SalesInvoiceServiceService', () => {
  let service: SalesInvoiceServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalesInvoiceServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class SalesService {

  private salesUrl =environment.apiUrl+ '/api/Sales';
  constructor(private http: HttpClient) {}

  processSale(saleData: any): Observable<any> {
    return this.http.post(`${this.salesUrl}/process`, saleData);
  }

  generateInvoice(saleId: number): Observable<any> {
    return this.http.get(`${this.salesUrl}/invoice/${saleId}`);
  }

  sendInvoiceToWhatsApp(saleId: number, phoneNumber: string): Observable<any> {
    return this.http.post(`${this.salesUrl}/send-invoice`, {
      saleId,
      phoneNumber
    });
  }
}

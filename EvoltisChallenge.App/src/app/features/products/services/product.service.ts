import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateProduct, Product, UpdateProduct } from '../models/product.interface';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url: string;

  constructor(private http: HttpClient) {
    this.url = environment.apiProductUrl;
  }

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(this.url);
  }

  getById(id: string): Observable<Product> {
    return this.http.get<Product>(`${this.url}/${id}`);
  }

  create(product: CreateProduct): Observable<string> {
    return this.http.post<string>(this.url, product);
  }

  update(id: string, product: UpdateProduct): Observable<void> {
    return this.http.put<void>(`${this.url}/${id}`, product);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}

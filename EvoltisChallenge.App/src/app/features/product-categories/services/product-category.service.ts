import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProductCategory } from '../models/product-category.interface';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductCategoryService {
  private url: string;

  constructor(private http: HttpClient) {
    this.url = environment.apiProductCategoryUrl;
  }

  getAll(): Observable<ProductCategory[]> {
    return this.http.get<ProductCategory[]>(this.url);
  }

  getById(id: string): Observable<ProductCategory> {
    return this.http.get<ProductCategory>(`${this.url}/${id}`);
  }
}

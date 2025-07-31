import { Component, OnInit } from '@angular/core';
import { ROUTES } from '../../../../core/app.routes';

@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.scss']
})
export class ProductTableComponent implements OnInit {
  ngOnInit(): void {
    console.log('📦 Product table cargado');
  }
  routes = ROUTES;
}

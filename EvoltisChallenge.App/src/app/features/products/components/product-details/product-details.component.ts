import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product.interface';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: Product | null = null;

  constructor(private route: ActivatedRoute,
    private productService: ProductService) { }

  ngOnInit(): void {
    console.log('📦 Product detail cargado');
    const id = this.route.snapshot.paramMap.get('id');

    if (!id) {
      console.warn('No ID param found in URL');
      return; // No hacer nada
    }

    if (id) {
      this.productService.getById(id).subscribe({
        next: (prod) => (this.product = prod),
        error: (err) => console.error('Error loading product:', err),
      });
    }
  }

}



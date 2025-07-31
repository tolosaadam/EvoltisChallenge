import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product.interface';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { take } from 'rxjs';

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
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.productService.getById(id)
        .pipe(take(1))
        .subscribe({
          next: (prod) => (this.product = prod),
          error: (err) => console.error('Error loading product:', err),
        });
    }
  }

}



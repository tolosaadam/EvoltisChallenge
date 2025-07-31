import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import * as ProductSelectors from '../../state/product.selectors';
import { ProductWithCategory } from '../../models/product.interface';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  productWithCategory$: Observable<ProductWithCategory | undefined> = of(undefined);
  constructor(private route: ActivatedRoute, private store: Store) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.productWithCategory$ = this.store.pipe(
        select(ProductSelectors.selectProductWithCategoryById(id))
      );
    }
  }
}



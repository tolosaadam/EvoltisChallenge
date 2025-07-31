import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { ConfirmationService } from 'primeng/api';
import { ProductWithCategory } from '../../models/product.interface';
import * as ProductSelectors from '../../state/product.selectors';
import { deleteProduct } from '../../state/product.actions';
import * as ProductFormActions from '../product-form/state/product-form.actions';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  productWithCategory$!: Observable<ProductWithCategory | undefined>;
  loading$!: Observable<boolean>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private store: Store,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit(): void {
    this.loading$ = this.store.pipe(select(ProductSelectors.selectProductsAndCategoriesLoading));
    const productId = this.route.snapshot.paramMap.get('id');
    if (productId) {
      this.productWithCategory$ = this.store.select(
        ProductSelectors.selectProductWithCategoryById(productId)
      );
    }
  }

  onEdit(product: ProductWithCategory) {
    this.store.dispatch(ProductFormActions.openEditProductForm({ product: product }));
  }

  onDelete(product: ProductWithCategory): void {
    this.confirmationService.confirm({
      message: `¿Estás seguro de que deseas eliminar el producto "${product.name}"?`,
      header: 'Confirmar eliminación',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Sí, eliminar',
      rejectLabel: 'Cancelar',
      acceptButtonStyleClass: 'p-button-danger',
      accept: () => {
        this.router.navigate(['/products']);
        this.store.dispatch(deleteProduct({ id: product.id }));
      }
    });
  }
}



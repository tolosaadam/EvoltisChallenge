import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as ProductSelectors from '../../state/product.selectors';
import { deleteProduct } from '../../state/product.actions';
import { ProductWithCategory } from '../../models/product.interface';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.scss'],
  providers: [ConfirmationService, MessageService]
})
export class ProductTableComponent implements OnInit {
  productsWithCategory$!: Observable<ProductWithCategory[]>;
  loading$!: Observable<boolean>;
  
  showFormDialog: boolean = false;
  selectedProduct: ProductWithCategory | null = null;

  constructor(
    private store: Store,
    private router: Router,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.productsWithCategory$ = this.store.pipe(select(ProductSelectors.selectProductsWithCategory));
    this.loading$ = this.store.pipe(select(ProductSelectors.selectProductsAndCategoriesLoading));
  }

  onView(id: string): void {
    this.router.navigate(['/products', id]);
  }

  onAdd(): void {
    this.selectedProduct = null;
    this.showFormDialog = true;
  }

  onEdit(product: ProductWithCategory): void {
    this.selectedProduct = product;
    this.showFormDialog = true;
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
        this.store.dispatch(deleteProduct({ id: product.id }));
        this.messageService.add({
          severity: 'success',
          summary: 'Producto eliminado',
          detail: `El producto "${product.name}" ha sido eliminado exitosamente`
        });
      }
    });
  }
}

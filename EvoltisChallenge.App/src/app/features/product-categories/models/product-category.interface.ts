export interface ProductCategory {
    id: string;
    name: string;
    description?: string;
}

export interface ProductCategoryState {
  categories: ProductCategory[];
  loading: boolean;
  error?: any;
}

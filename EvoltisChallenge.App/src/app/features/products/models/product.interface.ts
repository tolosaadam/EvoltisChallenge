import { ProductCategory } from "../../product-categories/models/product-category.interface";

export interface Product {
    id: string;
    name: string;
    description: string;
    price: number;
    productCategoryId: string;
    category: ProductCategory;
}

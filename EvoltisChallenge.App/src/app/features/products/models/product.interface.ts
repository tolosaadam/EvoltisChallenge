import { ProductCategory } from "../../product-categories/models/product-category.interface";

export interface Product {
    id: string;
    name: string;
    description: string;
    price: number;
    productCategoryId: string;
}

// Interfaz para la creación de un producto.
export interface CreateProduct {
    name: string;
    description: string;
    price: number;
    productCategoryId: string;
}

// Interfaz para la actualización de un producto.
export interface UpdateProduct {
    name: string;
    description: string;
    price: number;
    productCategoryId: string;
}

// Interfaz para el estado de los productos dentro del reducer.
export interface ProductState {
    products: Product[];
    loading: boolean;
    error?: any;
}

// Interfaz para un producto con su categoría asociada.
export interface ProductWithCategory extends Omit<Product, 'productCategoryId'> {
    category: ProductCategory | undefined;
}
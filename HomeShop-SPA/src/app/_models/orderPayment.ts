import { Product } from './product';
export interface OrderPayment {
    userId: number;
    orderDate: Date;
    total: number;
    address: string;
    fullName: string;
    discount: number;
    grandTotal: number;
    email: string;
    OrderProductDto: Product[];
}

export interface Cart {
    orderId: number;
    userId: number;
    productId: number;
    quantity: number;
    price: number;
    productName: string;
    discount: number;
    itemleft: number;
    url: string;
}

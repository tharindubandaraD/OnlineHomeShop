export interface Cart {
    orderId: number;
    userId: number;
    productId: number;
    quantity: number;
    itemLeft: number;
    price: number;
    productName: string;
    discount: number;
    url: string;
}

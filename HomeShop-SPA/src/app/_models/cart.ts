export interface Cart {
    userId: number;
    productId: number;
    quantity: number;
    itemLeft: number;
    price: number;
    productName: string;
    discount: number;
    url: string;
    orderId?: number;
    orderProductId?: number;
}

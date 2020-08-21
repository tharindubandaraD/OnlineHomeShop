export interface OrderDetail{
    orderId: number;
    orderProductId: number;
    userId: number;
    productId: number;
    quantity: number;
    itemLeft: number;
    price: number;
    productName: string;
    discount: number;
    url: string;
    expanded: boolean;
}

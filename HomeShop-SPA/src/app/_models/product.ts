import { Photo } from './Photo';

export interface Product {
    id: number;
    name: string;
    price: number;
    discount: number;
    photoUrl: string;
    quantity?: number;
    category?: string;
    description?: number;
    photos?: Photo[];
}

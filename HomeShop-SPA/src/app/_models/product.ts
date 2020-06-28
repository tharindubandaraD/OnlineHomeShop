import { Photo } from './Photo';

export interface Product {
    id: number;
    category: string;
    name: string;
    price: number;
    discount: number;
    photoId: number;
    photoUrl: string;
    quantity?: number;
    description?: number;
    photos?: Photo[];
}

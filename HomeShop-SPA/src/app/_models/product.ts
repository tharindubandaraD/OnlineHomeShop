import { Photo } from './photo';

export interface Product {
    id: number;
    name: string;
    price: number;
    discount: number;
    photoUrl: string;
    quantity?: number;
    catergory?: string;
    catergoryId?: number;
    description?: number;
    photos?: Photo[];
}

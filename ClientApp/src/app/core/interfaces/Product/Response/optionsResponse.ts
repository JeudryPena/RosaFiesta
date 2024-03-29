export interface OptionsResponse {
  id: string;
  title: string;
  description: string | null;
  price: number;
  color: string | null;
  genderFor: number;
  condition: number;
  stock: string;
  quantityAvailable: number;
  images: any[];
  imageId: number | null;
}

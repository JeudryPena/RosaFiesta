import {OficializeItemsDto} from "@core/interfaces/Product/UserInteract/OficializeItemsDto";

export interface OficializeDto {
  id: string,
  products: OficializeItemsDto[],
  shipping: number,
  phone: string,
  address: string,
  description: string,
  location: string,
  province: string,
  postalCode: number,
  eventDate: Date,
  orderId: string,
}

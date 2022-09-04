import { ShoeStore } from './'
export interface ShoeColor {
  id: number
  shoeId: number
  color: string
  hex: string
  image: string
  shoeStores: ShoeStore[]
}

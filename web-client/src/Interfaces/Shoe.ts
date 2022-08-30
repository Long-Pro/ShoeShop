import { Brand } from './Brand'
import { ShoeFile } from './ShoeFile'

export interface Shoe {
  id: number
  name: string
  description: string
  title: string
  brandId: number
  gender: string
  price: number
  status: number
  brand: Brand
  shoeFiles: ShoeFile[]
}

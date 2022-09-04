import { Brand } from './Brand'
import { ShoeFile } from './ShoeFile'
import { ShoeColor } from './ShoeColor'

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
  isExists: boolean
  shoeFiles: ShoeFile[]
  shoeColors: ShoeColor[]
}

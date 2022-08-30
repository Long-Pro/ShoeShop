import { Shoe } from './Shoe'
export interface Brand {
  id: number
  name: string
  image: string
  shoes: Shoe[]
}

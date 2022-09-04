import { ReviewFile, Customer, Shoe } from './'
export interface Review {
  id: number
  shoeId: number
  customerId: number
  star: number
  comment: string
  shoe: Shoe
  reviewFiles: ReviewFile[]
  customer: Customer
}

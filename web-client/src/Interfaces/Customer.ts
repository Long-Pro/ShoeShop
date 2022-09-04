import { Account } from './Account'
export interface Customer {
  id: number
  accountId: number
  name: string
  birthDate: Date
  phone: string
  address: string
  email: string
  gender: string
  avatar: string
  account: Account
}

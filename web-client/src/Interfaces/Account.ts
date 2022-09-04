import { Role } from './Role'
export interface Account {
  id: number
  accountValue: string
  password: string
  roleId: number
  role: Role
}

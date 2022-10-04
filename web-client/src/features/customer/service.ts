import _axios from '../../utils/_axios'
import { LoginModel } from './customerSlice'

export const login = async (login: LoginModel) => {
  const link = `/api/customers/login`
  return new Promise((resolve, reject) => {
    _axios
      .post(link, login)
      .then((response) => resolve(response))
      .catch((error) => reject(error))
  })
}

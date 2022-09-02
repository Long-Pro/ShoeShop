// import axios, { AxiosError } from 'axios'
// export const getAllShoe = async () => {
//   return new Promise((resolve, reject) => {
//     axios
//       .get(`https://localhost:7138/Shoe/GetAllShoeWithFile`)
//       .then((response) => resolve(response.data))
//       .catch((error) => reject(error.response.data))
//   })
// }

import _axios from '../../utils/_axios'
import { FilterState } from './shoeSlice'

export const getShoeByFilter = async (filter: FilterState) => {
  const link = `/api/shoes`
  console.log(filter)

  return new Promise((resolve, reject) => {
    _axios
      .get(link, {
        params: filter,
      })
      .then((response) => resolve(response))
      .catch((error) => reject(error))
  })
}

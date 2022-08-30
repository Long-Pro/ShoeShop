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

export const getAllShoe = async () => {
  let link = `/Shoe/GetAllShoeWithFileAndBrand`
  return new Promise((resolve, reject) => {
    _axios
      .get(link)
      .then((response) => resolve(response))
      .catch((error) => reject(error))
  })
}

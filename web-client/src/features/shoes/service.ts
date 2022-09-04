import _axios from '../../utils/_axios'
import { FilterState } from './shoesSlice'

export const getShoesByFilter = async (filter: FilterState) => {
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

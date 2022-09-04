import _axios from '../../utils/_axios'
import { FilterState } from './reviewsSlice'
export const getReviewsByShoeId = async (filter: FilterState) => {
  const link = `/api/shoes/${filter.shoeId}/reviews`
  return new Promise((resolve, reject) => {
    _axios
      .get(link, {
        params: { page: filter.page },
      })
      .then((response) => resolve(response))
      .catch((error) => reject(error))
  })
}

import _axios from '../../utils/_axios'

export const getAllBrand = async () => {
  const link = `/api/brands`
  return new Promise((resolve, reject) => {
    _axios
      .get(link)
      .then((response) => resolve(response))
      .catch((error) => reject(error))
  })
}

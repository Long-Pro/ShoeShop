import _axios from '../../utils/_axios'
export const getShoeById = async (id: number) => {
  const link = `/api/shoes/${id}`
  return new Promise((resolve, reject) => {
    _axios
      .get(link)
      .then((response) => resolve(response))
      .catch((error) => reject(error))
  })
}

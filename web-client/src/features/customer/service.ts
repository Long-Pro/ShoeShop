import _axios from '../../utils/_axios'

export const getCustomer = async () => {
  const link = `https://localhost:7138/api/shoes/${123}/reviews`
  return new Promise((resolve, reject) => {
    _axios
      .get(link)
      .then((response) => resolve(response))
      .catch((error) => reject(error))
  })
}

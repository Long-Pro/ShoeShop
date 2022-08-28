import axios, { AxiosError } from 'axios'
export const getAllShoe = async () => {
  //const response = await axios.get('https://localhost:7138/Shoe/GetAllShoeWithFile')

  return new Promise((resolve, reject) => {
    axios
      .get(`https://localhost:7138/Shoe/GetAllShoeWithFile`)
      .then((response) => resolve(response.data))
      .catch((error) => reject(error.response.data))
  })
}

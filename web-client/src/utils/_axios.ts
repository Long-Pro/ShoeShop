import axios from 'axios'
const instance = axios.create({
  baseURL: 'https://localhost:7138/',
})
instance.interceptors.response.use(
  function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data
    let { message, data, totalPage } = response.data
    return { message, data, totalPage }
  },
  function (error) {
    // Any status codes that falls outside the range of 2xx cause this function to trigger
    // Do something with response error
    let { message, data, totalPage } = error.response.data
    return Promise.reject({ message, data, totalPage })
  },
)
export default instance

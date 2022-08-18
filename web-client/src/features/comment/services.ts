import axios from 'axios'
export const getAllComment = async () => {
  const response = await axios.get('https://jsonplaceholder.typicode.com/comments')
  console.log(response)
  return response.data
}

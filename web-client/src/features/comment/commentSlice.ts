import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

import { getAllComment as getAll } from './services'
import { Comment } from '../../Interfaces'

export const getAllComment = createAsyncThunk('comment/getAll', async () => {
  const response = await getAll()
  return response
})

export interface CommentState {
  value: Comment[]
  isLoaded: boolean
  error: any
}
const initialState: CommentState = {
  value: [],
  isLoaded: false,
  error: '',
}
export const commentSlice = createSlice({
  name: 'comment',
  initialState,
  reducers: {
    updateComment: (state, action: PayloadAction<Comment[]>) => {
      state.value = action.payload
    },
  },
  extraReducers: (builder) => {
    builder.addCase(getAllComment.fulfilled, (state, action: any) => {
      state.isLoaded = true
      state.value = action.payload
    })
    builder.addCase(getAllComment.rejected, (state, action) => {
      state.isLoaded = false
      console.log(action.payload)
      state.error = 'loi ---------------'
    })
  },
})
export const { updateComment } = commentSlice.actions

export default commentSlice.reducer

import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

import * as service from './service'
import { Review } from '../../Interfaces'

export const getReviewsByShoeId = createAsyncThunk('review/getReviewsByShoeId', async (filter: FilterState) => {
  const response = await service.getReviewsByShoeId(filter)
  return response
})
export interface FilterState {
  shoeId?: number
  page?: number
}
export interface ReviewsState {
  value: Review[]
  isLoaded: boolean
  message: string
  totalPage: number
}
const initialState: ReviewsState = {
  value: [],
  isLoaded: false,
  message: '',
  totalPage: 0,
}
export const reviewsSlice = createSlice({
  name: 'review',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getReviewsByShoeId.fulfilled, (state, action: any) => {
      state.isLoaded = true
      state.value = action.payload.data
      state.message = action.payload.message
      state.totalPage = action.payload.totalPage
    })
    builder.addCase(getReviewsByShoeId.rejected, (state, action) => {
      state.isLoaded = false
      state.message = action.error.message as string
    })
  },
})
export const {} = reviewsSlice.actions

export default reviewsSlice.reducer

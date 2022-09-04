import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

import * as service from './services'
import { Shoe } from '../../Interfaces'

export const getShoeById = createAsyncThunk('shoe/getShoeById', async (id: number) => {
  const response = await service.getShoeById(id)
  return response
})

export interface ShoesState {
  value?: Shoe
  isLoaded: boolean
  message: string
}

const initialState: ShoesState = {
  value: undefined,
  isLoaded: false,
  message: '',
}
export const shoeSlice = createSlice({
  name: 'shoe',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getShoeById.fulfilled, (state, action: any) => {
      state.isLoaded = true
      state.value = action.payload.data
      state.message = action.payload.message
    })
    builder.addCase(getShoeById.rejected, (state, action) => {
      state.isLoaded = false
      state.message = action.error.message as string
    })
  },
})
export const {} = shoeSlice.actions

export default shoeSlice.reducer

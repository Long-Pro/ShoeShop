import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

import * as service from './services'
import { Brand } from '../../Interfaces'

export const getAllBrand = createAsyncThunk('brand/getAllBrand', async () => {
  const response = await service.getAllBrand()
  return response
})

export interface ShoeState {
  value: Brand[]
  isLoaded: boolean
  message: string
}

const initialState: ShoeState = {
  value: [],
  isLoaded: false,
  message: '',
}
export const brandSlice = createSlice({
  name: 'brand',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getAllBrand.fulfilled, (state, action: any) => {
      state.isLoaded = true
      state.value = action.payload.data
      state.message = action.payload.message
    })
    builder.addCase(getAllBrand.rejected, (state, action) => {
      state.isLoaded = false
      state.message = action.error.message as string
    })
  },
})
export const {} = brandSlice.actions

export default brandSlice.reducer

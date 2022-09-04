import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

import * as service from './service'
import { Brand } from '../../Interfaces'

export const getAllBrands = createAsyncThunk('brand/getAllBrands', async () => {
  const response = await service.getAllBrands()
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
export const allBrandsSlice = createSlice({
  name: 'brand',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getAllBrands.fulfilled, (state, action: any) => {
      state.isLoaded = true
      state.value = action.payload.data
      state.message = action.payload.message
    })
    builder.addCase(getAllBrands.rejected, (state, action) => {
      state.isLoaded = false
      state.message = action.error.message as string
    })
  },
})
export const {} = allBrandsSlice.actions

export default allBrandsSlice.reducer

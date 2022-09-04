import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

import * as service from './service'
import { Customer } from '../../Interfaces'

export const getCustomer = createAsyncThunk('review/getCustomerByShoeId', async () => {
  const response = await service.getCustomer()
  return response
})

export interface CustomerState {
  value?: Customer
  isLoaded: boolean
  message: string
}
const initialState: CustomerState = {
  value: undefined,
  isLoaded: false,
  message: '',
}
export const customerSlice = createSlice({
  name: 'review',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getCustomer.fulfilled, (state, action: any) => {
      state.isLoaded = true
      state.value = action.payload.data
      state.message = action.payload.message
    })
    builder.addCase(getCustomer.rejected, (state, action) => {
      state.isLoaded = false
      state.message = action.error.message as string
    })
  },
})
export const {} = customerSlice.actions

export default customerSlice.reducer

import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

import * as service from './service'
import { Customer } from '../../Interfaces'

export interface LoginModel {
  account: string
  password: string
}

export const login = createAsyncThunk('review/getCustomerByShoeId', async (login: LoginModel) => {
  const response = await service.login(login)
  console.log(response)
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
  name: 'customer',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(login.fulfilled, (state, action: any) => {
      state.isLoaded = true
      state.value = action.payload.data
      state.message = action.payload.message
    })
    builder.addCase(login.rejected, (state, action) => {
      state.isLoaded = false
      state.message = action.error.message as string
    })
  },
})
export const {} = customerSlice.actions

export default customerSlice.reducer

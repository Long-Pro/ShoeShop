import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

import * as service from './services'
import { Shoe } from '../../Interfaces'

export const getAllShoe = createAsyncThunk('shoe/getAllShoe', async () => {
  const response = await service.getAllShoe()
  return response
})

export interface ShoeState {
  value: Shoe[]
  isLoaded: boolean
  message: string
}
const initialState: ShoeState = {
  value: [],
  isLoaded: false,
  message: '',
}
export const shoeSlice = createSlice({
  name: 'shoe',
  initialState,
  reducers: {
    // getAllShoe: (state, action: PayloadAction<Shoe[]>) => {
    //   state.value = action.payload
    // },
  },
  extraReducers: (builder) => {
    builder.addCase(getAllShoe.fulfilled, (state, action: any) => {
      //console.log(action.payload)

      state.isLoaded = true
      state.value = action.payload.data
      state.message = action.payload.message
    })
    builder.addCase(getAllShoe.rejected, (state, action) => {
      //console.log(action)
      state.isLoaded = false
      state.message = action.error.message as string
    })
  },
})
export const {} = shoeSlice.actions

export default shoeSlice.reducer

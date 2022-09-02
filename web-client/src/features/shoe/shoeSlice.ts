import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

import * as service from './services'
import { Shoe } from '../../Interfaces'

export const getShoeByFilter = createAsyncThunk('shoe/getShoeByFilter', async (filter: FilterState) => {
  const response = await service.getShoeByFilter(filter)
  return response
})

export interface FilterState {
  q?: string
  sort?: string
  startPrice?: number
  endPrice?: number
  brandId?: number
  page?: number
}
export interface ShoeState {
  value: Shoe[]
  isLoaded: boolean
  message: string
  totalPage: number
  filter: FilterState
}

const initialState: ShoeState = {
  value: [],
  isLoaded: false,
  message: '',
  totalPage: 0,
  filter: {},
}
export const shoeSlice = createSlice({
  name: 'shoe',
  initialState,
  reducers: {
    updateQ: (state, action: PayloadAction<string>) => {
      state.filter.q = action.payload
    },
    updateSortBy: (state, action: PayloadAction<string>) => {
      state.filter.sort = action.payload
    },
    updatePriceRange: (state, action: PayloadAction<number[]>) => {
      state.filter.startPrice = action.payload[0]
      state.filter.endPrice = action.payload[1]
    },
    updateBrandId: (state, action: PayloadAction<number>) => {
      state.filter.brandId = action.payload
    },
    updatePage: (state, action: PayloadAction<number>) => {
      state.filter.page = action.payload
    },
  },
  extraReducers: (builder) => {
    builder.addCase(getShoeByFilter.fulfilled, (state, action: any) => {
      console.log(action.payload)

      state.isLoaded = true
      state.value = action.payload.data
      state.message = action.payload.message
      state.totalPage = action.payload.totalPage
    })
    builder.addCase(getShoeByFilter.rejected, (state, action) => {
      //console.log(action)
      state.isLoaded = false
      state.message = action.error.message as string
    })
  },
})
export const { updateBrandId, updatePriceRange, updateQ, updateSortBy, updatePage } = shoeSlice.actions

export default shoeSlice.reducer

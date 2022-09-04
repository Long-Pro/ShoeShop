import { configureStore } from '@reduxjs/toolkit'

import reviewsSlice from '../features/reviews/reviewsSlice'
import shoesReducer from '../features/shoes/shoesSlice'
import shoeReducer from '../features/shoe/shoeSlice'
import allBrandsReducer from '../features/allBrands/allBrandsSlice'
import customerSlice from '../features/customer/customerSlice'
import { DashboardCustomizeRounded } from '@mui/icons-material'

export const store = configureStore({
  reducer: {
    reviews: reviewsSlice,
    shoes: shoesReducer,
    shoe: shoeReducer,
    allBrands: allBrandsReducer,
    customer: customerSlice,
  },
})

export type StoreKey = keyof typeof store.getState

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch

import { configureStore } from '@reduxjs/toolkit'

import userReducer from '../features/user/userSlice'
import commentReducer from '../features/comment/commentSlice'
import shoeReducer from '../features/shoe/shoeSlice'
import brandReducer from '../features/brand/brandSlice'

export const store = configureStore({
  reducer: {
    user: userReducer,
    comment: commentReducer,
    shoe: shoeReducer,
    brand: brandReducer,
  },
})

export type StoreKey = keyof typeof store.getState

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch

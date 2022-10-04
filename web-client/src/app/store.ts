import { configureStore } from '@reduxjs/toolkit'
import { persistStore, persistReducer } from 'redux-persist'
import storage from 'redux-persist/lib/storage'
import thunk from 'redux-thunk'
import { combineReducers } from 'redux'
import reviewsReducer from '../features/reviews/reviewsSlice'
import shoesReducer from '../features/shoes/shoesSlice'
import shoeReducer from '../features/shoe/shoeSlice'
import allBrandsReducer from '../features/allBrands/allBrandsSlice'
import customerReducer from '../features/customer/customerSlice'

const rootReducer = combineReducers({
  reviews: reviewsReducer,
  shoes: shoesReducer,
  shoe: shoeReducer,
  allBrands: allBrandsReducer,
  customer: customerReducer,
})
const persistConfig = {
  key: 'root',
  storage,
  blacklist: ['shoes'],
}
const persistedReducer = persistReducer(persistConfig, rootReducer)

export const store = configureStore({
  reducer: persistedReducer,
})

export const persistor = persistStore(store)

export type StoreKey = keyof typeof store.getState

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch

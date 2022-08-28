import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'
import { AppDispatch } from '../../app/store'
import { getAllComment } from '../../features/comment/commentSlice'
import { useAppSelector, useAppDispatch } from '../../app/hooks'
import { User } from '../../Interfaces'
import styles from './Home.module.scss'
import { useDispatch } from 'react-redux'
const cx = classNames.bind(styles)
function Home() {
  // const dispatch = useAppDispatch()
  // let { value, isLoaded, error } = useAppSelector((state) => state.comment)
  // console.log({ value, isLoaded, error })
  // useEffect(() => {
  //   dispatch(getAllComment())
  // }, [])
  return (
    <div className={cx('wrapper')}>
      <h1>Home</h1>
    </div>
  )
}

export default Home

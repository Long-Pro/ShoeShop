import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'
import axios from 'axios'

import styles from './ShoeCardList.module.scss'
import { useAppSelector, useAppDispatch } from '../../app/hooks'
import { getAllShoe, ShoeState } from '../../features/shoe/shoeSlice'

const cx = classNames.bind(styles)
function ShoeCardList() {
  let shoeListState = useAppSelector((state) => state.shoe)

  console.log(shoeListState)

  const dispatch = useAppDispatch()
  useEffect(() => {
    dispatch(getAllShoe())
  }, [])

  return (
    <div className={cx('wrapper')}>
      <h1>ShoeCardList</h1>
    </div>
  )
}

export default ShoeCardList

import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'
import { Container } from '@mui/material'

import styles from './ShoeCardList.module.scss'
import { useAppSelector, useAppDispatch } from '../../app/hooks'
import { getAllShoe, ShoeState } from '../../features/shoe/shoeSlice'
import ShoeCardItem from '../ShoeCardItem'

const cx = classNames.bind(styles)
function ShoeCardList() {
  let shoeList = useAppSelector((state) => state.shoe)

  console.log(shoeList)

  const dispatch = useAppDispatch()
  useEffect(() => {
    dispatch(getAllShoe())
  }, [])

  return (
    <Container maxWidth="lg">
      <div className={cx('wrapper')}>
        {shoeList.isLoaded && (
          <div className={cx('shoe-list')}>
            {shoeList.value.map((item, index) => (
              <ShoeCardItem data={item} key={index} />
            ))}
          </div>
        )}
      </div>
    </Container>
  )
}

export default ShoeCardList

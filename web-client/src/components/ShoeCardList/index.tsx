import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'
import { Container, Pagination, Stack } from '@mui/material'

import styles from './ShoeCardList.module.scss'
import ShoeCardItem from '../ShoeCardItem'
import { useAppSelector, useAppDispatch } from '../../app/hooks'
import { getShoesByFilter, updatePage } from '../../features/shoes/shoesSlice'

const cx = classNames.bind(styles)
function ShoeCardList() {
  const dispatch = useAppDispatch()
  const shoeList = useAppSelector((state) => state.shoes)
  const filter = useAppSelector((state) => state.shoes.filter)
  const [page, setPage] = useState(1)

  useEffect(() => {
    dispatch(getShoesByFilter(filter))

    if (filter.page == 1 && page != 1) setPage(1)
  }, [filter])

  const handleChangePage = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value)
    dispatch(updatePage(value))
    window.scrollTo({ top: 0, behavior: 'smooth' })
  }
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
        <div className="d-flex justify-content-center mt-3">
          <Pagination count={shoeList.totalPage} color="primary" page={page} onChange={handleChangePage} />
        </div>
      </div>
    </Container>
  )
}

export default ShoeCardList

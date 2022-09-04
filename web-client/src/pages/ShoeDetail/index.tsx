import { useState, useEffect, useCallback } from 'react'
import classNames from 'classnames/bind'
import { Routes, Route, useParams } from 'react-router-dom'
import { Container, Button } from '@mui/material'
import Grid from '@mui/material/Unstable_Grid2'
import { ShoppingCart } from '@mui/icons-material'

import { ImageViewer } from '../../components'
import { useAppSelector, useAppDispatch } from '../../app/hooks'
import { getShoeById } from '../../features/shoe/shoeSlice'
import { ShoeFile } from '../../Interfaces'
import styles from './ShoeDetail.module.scss'
import { ShoeColor, ShoeStore } from '../../Interfaces'
import { Reviews } from '../../components'

var currencyFormatter = require('currency-formatter')
const cx = classNames.bind(styles)
function ShoeDetail() {
  const params = useParams()
  const dispatch = useAppDispatch()
  const { value: shoe } = useAppSelector((state) => state.shoe)
  useEffect(() => {
    dispatch(getShoeById(parseInt(params.shoeId as string)))
  }, [])

  const [shoeColor, setShoeColor] = useState<ShoeColor>()
  const [shoeStore, setShoeStore] = useState<ShoeStore>()
  useEffect(() => {
    const x = shoe?.shoeColors[0]
    setShoeColor(x)
    setShoeStore(x?.shoeStores[0])
  }, [shoe])
  const handleClickColorItem = (item: ShoeColor) => {
    setShoeColor(item)
    setShoeStore(item.shoeStores[0])
  }

  const [quantity, setQuantity] = useState<number>(1)

  const images: string[] = shoe?.shoeFiles.map((item: ShoeFile) => item.link) as string[]
  return (
    <>
      {shoe && (
        <Container maxWidth="lg" className={cx('wrapper')}>
          <Grid container spacing={2}>
            <Grid xs={12} sm={6}>
              {images && <ImageViewer images={images} />}
            </Grid>
            <Grid xs={12} sm={6}>
              <h2>{shoe?.name}</h2>
              <p>{shoe?.title}</p>
              <h4 className={cx('price', 'text-success')}>
                {currencyFormatter.format(shoe?.price, { locale: 'vi-VN' })}
              </h4>
              <p>
                Tình trạng: <span className="text-primary">Còn hàng: ({shoeStore?.quantity})</span>
              </p>
              <div className={cx('colors')}>
                {shoe?.shoeColors.map((item: ShoeColor, index: number) => (
                  <div
                    className={cx('item', { color__active: shoeColor?.id == item.id })}
                    key={index}
                    onClick={() => handleClickColorItem(item)}
                  >
                    <img src={item.image} alt="" />
                  </div>
                ))}
              </div>
              <div className={cx('sizes', 'mt-4')}>
                {shoeColor?.shoeStores.map((item: ShoeStore, index: number) => (
                  <div
                    className={cx('item', { size__active: shoeStore?.id == item.id })}
                    key={index}
                    onClick={() => setShoeStore(item)}
                  >
                    {item.size}
                  </div>
                ))}
              </div>
              <div className={cx('quantity', 'mt-4')}>
                <div
                  className={cx({ minus: quantity == 1 })}
                  onClick={() => {
                    if (quantity > 1) setQuantity(quantity - 1)
                  }}
                >
                  -
                </div>
                <div>{quantity}</div>
                <div onClick={() => setQuantity(quantity + 1)}>+</div>
              </div>
              <div className="mt-4">
                <Button variant="contained" sx={{ borderRadius: 0 }} startIcon={<ShoppingCart />}>
                  Thêm vào giỏ hàng
                </Button>
              </div>
              <div className={cx('description', 'mt-4')}>
                <h4>Mô tả sản phẩm</h4>
                <div dangerouslySetInnerHTML={{ __html: shoe?.description }} />
              </div>
            </Grid>
          </Grid>
        </Container>
      )}
      <Reviews />
    </>
  )
}

export default ShoeDetail

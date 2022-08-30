import { useState, useEffect, useRef } from 'react'
import classNames from 'classnames/bind'

import styles from './ShoeCardItem.module.scss'
import { Shoe } from '../../Interfaces'

const cx = classNames.bind(styles)
var currencyFormatter = require('currency-formatter')

interface Prop {
  data: Shoe
}
function ShoeCardItem(prop: Prop) {
  let { data } = prop
  return (
    <div className={cx('wrapper')}>
      <div className={cx('image')}>
        <img src={data.shoeFiles[0].link} alt="" className={cx('shoe-image')} />
        <img src={data.shoeFiles[1].link} alt="" className={cx('shoe-image_hover')} />
        <div className={cx('price', 'text-success font-weight-bold')}>
          {currencyFormatter.format(data.price, { locale: 'vi-VN' })}
        </div>
        <img className={cx('brand-image')} src={data.brand.image} alt="" />
      </div>
      <p className={cx('name')}>{data.name}</p>
    </div>
  )
}

export default ShoeCardItem

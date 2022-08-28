import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'

import styles from './ShoeCardItem.module.scss'
const cx = classNames.bind(styles)
function ShoeCardItem() {
  return (
    <div className={cx('wrapper')}>
      <h1>ShoeCardItem</h1>
    </div>
  )
}

export default ShoeCardItem

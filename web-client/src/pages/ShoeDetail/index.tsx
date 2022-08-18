import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'

import styles from './ShoeDetail.module.scss'
const cx = classNames.bind(styles)
function ShoeDetail() {
  return (
    <div className={cx('wrapper')}>
      <h1>ShoeDetail</h1>
    </div>
  )
}

export default ShoeDetail

import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'

import { Header } from '../../layouts/components'
import styles from './OnlyHeaderLayout.module.scss'
import { Children } from '../../Interfaces'
const cx = classNames.bind(styles)
function OnlyHeaderLayout({ children }: Children) {
  return (
    <div className={cx('wrapper')}>
      <Header />
      {children}
    </div>
  )
}

export default OnlyHeaderLayout

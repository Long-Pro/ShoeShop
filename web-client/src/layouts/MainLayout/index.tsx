import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'

import Header from '../components/Header'

import styles from './MainLayout.module.scss'
import { Children } from '../../Interfaces'
const cx = classNames.bind(styles)
function MainLayout({ children }: Children) {
  return (
    <div className={cx('wrapper')}>
      <h1>MainLayout</h1>
      {children}
    </div>
  )
}

export default MainLayout

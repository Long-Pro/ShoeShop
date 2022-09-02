import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'

import Header from '../components/Header'
import SearchTool from '../components/SearchTool'
import Banner from '../components/Banner'
import Footer from '../components/Footer'

import { ShoeCardList } from '../../components'

import styles from './MainLayout.module.scss'
import { Children } from '../../Interfaces'
const cx = classNames.bind(styles)
function MainLayout({ children }: Children) {
  return (
    <div className={cx('wrapper')}>
      <Header />
      <Banner />
      <SearchTool />
      <ShoeCardList />
      <Footer />
      {children}
    </div>
  )
}

export default MainLayout

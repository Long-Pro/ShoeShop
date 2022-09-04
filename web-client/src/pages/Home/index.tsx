import { useState, useEffect } from 'react'
import classNames from 'classnames/bind'
import { AppDispatch } from '../../app/store'
import { useAppSelector, useAppDispatch } from '../../app/hooks'

import styles from './Home.module.scss'
import { useDispatch } from 'react-redux'
import Banner from '../../layouts/components/Banner'
import SearchTool from '../../layouts/components/SearchTool'
import { ShoeCardList } from '../../components'
const cx = classNames.bind(styles)
function Home() {
  return (
    <div className={cx('wrapper')}>
      <Banner />
      <SearchTool />
      <ShoeCardList />
    </div>
  )
}

export default Home

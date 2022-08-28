import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import classNames from 'classnames/bind'
import { Search, LocalMallOutlined, AccountCircleOutlined } from '@mui/icons-material'
import Grid from '@mui/material/Unstable_Grid2'
import { Container } from '@mui/material'
import images from '../../../assets/images'
import styles from './Header.module.scss'

import { useAppSelector, useAppDispatch } from '../../../app/hooks'
const cx = classNames.bind(styles)
function Header() {
  let user = useAppSelector((state) => state.user)
  //console.log(user)
  return (
    <Container maxWidth="lg">
      <div className={cx('wrapper')}>
        <div className={cx('logo')}>
          <Link to="/">
            <img src={images.logo} alt="" />
          </Link>
        </div>
        <div className={cx('search')}>
          <input placeholder="Tìm kiếm tên giày" />
          <Search className={cx('search-btn')} />
        </div>

        <div className={cx('user')}>
          <LocalMallOutlined style={{ fontSize: '26px' }} />
          <div className={cx('user-icon-wrapper')}>
            <AccountCircleOutlined style={{ fontSize: '26px' }} />
            {user.isLoaded && <span>{user.value?.account}</span>}
          </div>
        </div>
      </div>
    </Container>
  )
}

export default Header

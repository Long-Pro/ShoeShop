import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import classNames from 'classnames/bind'
import { Search, LocalMallOutlined, AccountCircleOutlined, HighlightOff } from '@mui/icons-material'
import { Container } from '@mui/material'

import images from '../../../assets/images'
import styles from './Header.module.scss'
import { getShoesByFilter, updateQ } from '../../../features/shoes/shoesSlice'

import { useAppSelector, useAppDispatch } from '../../../app/hooks'
const cx = classNames.bind(styles)

function Header() {
  const dispatch = useAppDispatch()
  const user: any = useAppSelector((state) => state.customer)

  const [query, setQuery] = useState('')

  const handleChangeSearchInput = (e: any) => {
    const q = e.target.value
    setQuery(q)
  }
  const handleSearch = () => {
    dispatch(updateQ(query))
  }
  const handleDeleteSearch = () => {
    setQuery('')
    dispatch(updateQ(''))
  }
  const handleKeyUpSearchInput = (e: any) => {
    if (e.key === 'Enter') handleSearch()
  }
  return (
    <Container maxWidth="lg">
      <div className={cx('wrapper')}>
        <div className={cx('logo')}>
          <Link to="/">
            <img src={images.logo} alt="" />
          </Link>
        </div>
        <div className={cx('search')}>
          <input
            placeholder="Tìm kiếm tên giày"
            value={query}
            onChange={handleChangeSearchInput}
            onKeyUp={handleKeyUpSearchInput}
          />
          {query && <HighlightOff className={cx('search-delete-btn')} onClick={handleDeleteSearch} />}
          <Search className={cx('search-btn')} onClick={handleSearch} />
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

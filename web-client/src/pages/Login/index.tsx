import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import classNames from 'classnames/bind'
import { Search, LocalMallOutlined, AccountCircleOutlined, HighlightOff } from '@mui/icons-material'
import { Container, Modal, TextField, Button } from '@mui/material'
import Grid from '@mui/material/Unstable_Grid2'

import images from '../../assets/images'
import styles from './Login.module.scss'
import { getShoesByFilter, updateQ } from '../../features/shoes/shoesSlice'

import { useAppSelector, useAppDispatch } from '../../app/hooks'
const cx = classNames.bind(styles)

function Header() {
  const dispatch = useAppDispatch()

  const [account, setAccount] = useState('')
  const [password, setPassword] = useState('')
  const handleChangeAccount = (event: React.ChangeEvent<HTMLInputElement>) => {
    setAccount(event.target.value)
  }
  const handleChangePassword = (event: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(event.target.value)
  }

  const handleSubmit = () => {
    console.log(account)
    console.log(password)
  }

  return (
    <Container maxWidth="lg" className={cx('wrapper')}>
      <Grid container spacing={1}>
        <Grid xs={0} sm={6}>
          <img
            src="https://thumbs.dreamstime.com/b/sportingly-colorful-poster-to-advertise-sports-shoes-take-next-step-motivational-poster-vector-illustration-75779145.jpg"
            alt=""
            className={cx('image')}
          />
        </Grid>
        <Grid xs={12} sm={6}>
          <div className={cx('login')}>
            <h2>Đăng nhập</h2>
            <TextField
              id="account"
              label="Tài khoản"
              variant="outlined"
              sx={{ width: '300px', marginTop: '30px' }}
              value={account}
              onChange={handleChangeAccount}
            />
            <TextField
              id="account"
              label="Mật khẩu"
              variant="outlined"
              sx={{ width: '300px', marginTop: '30px' }}
              value={password}
              onChange={handleChangePassword}
            />
            <Button variant="contained" size="large" sx={{ width: '300px', marginTop: '30px' }} onClick={handleSubmit}>
              Đăng nhập
            </Button>
            <div className={cx('line')}></div>
            <Button variant="contained" color="success" size="large" sx={{ width: '300px' }}>
              Đăng kí
            </Button>
          </div>
        </Grid>
      </Grid>
    </Container>
  )
}

export default Header

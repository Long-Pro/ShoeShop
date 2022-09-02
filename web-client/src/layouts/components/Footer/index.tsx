import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import classNames from 'classnames/bind'
import { Container, Box } from '@mui/system'
import Grid from '@mui/material/Unstable_Grid2'

import images from '../../../assets/images'
import styles from './Footer.module.scss'

const cx = classNames.bind(styles)
function Footer() {
  return (
    <Container maxWidth="lg" className={cx('wrapper')}>
      <Grid container spacing={2}>
        <Grid xs={12} sm={6}>
          <h4>Trợ giúp</h4>
          <ul>
            <li>Tuyển dụng</li>
            <li>Hệ thống của hàng</li>
            <li>Liên hệ hợp tác</li>
            <li>Q&A</li>
          </ul>
        </Grid>
        <Grid xs={12} sm={6}>
          <h4>Thông tin</h4>
          <ul>
            <li className="font-weight-bold">Shoe Shop</li>
            <li>
              <span className={cx('label')}>Địa chỉ:&nbsp;</span>
              22 Lý Chiêu Hoàng, Phường 10, Quận 6, TP. Hồ Chí Minh
            </li>
            <li>
              <span className={cx('label')}>Điện thoại:&nbsp;</span>
              (028) 38 753 443
            </li>
            <li>
              <span className={cx('label')}>Email:&nbsp;</span>
              tuvan_online@shoeshop.com.vn
            </li>
          </ul>
        </Grid>
      </Grid>
    </Container>
  )
}

export default Footer

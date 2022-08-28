import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import classNames from 'classnames/bind'
import Slider from 'react-slick'
import { Container } from '@mui/system'

import images from '../../../assets/images'
import styles from './Banner.module.scss'
import './Banner.module.scss'
import './Slider.css'

const cx = classNames.bind(styles)
function Banner() {
  const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    arrows: false,
  }
  return (
    <Container maxWidth="lg">
      <Slider {...settings}>
        <div>
          <img src="https://www.vascara.com/uploads/banner/2022/August/25/14431661418664.png" alt="" />
        </div>
        <div>
          <img src="https://www.vascara.com/uploads/banner/2022/August/25/14501661426491.jpg" alt="" />
        </div>
        <div>
          <img src="https://www.vascara.com/uploads/banner/2022/August/25/14431661418664.png" alt="" />
        </div>
        <div>
          <img src="https://www.vascara.com/uploads/banner/2022/August/11/12761660208809.png" alt="" />
        </div>
      </Slider>
    </Container>
  )
}

export default Banner

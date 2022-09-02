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
          <img src={images.banner1} alt="" />
        </div>
        <div>
          <img src={images.banner2} alt="" />
        </div>
        <div>
          <img src={images.banner3} alt="" />
        </div>
      </Slider>
    </Container>
  )
}

export default Banner

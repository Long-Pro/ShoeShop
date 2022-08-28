import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import classNames from 'classnames/bind'
import axios from 'axios'
import {
  Search,
  FilterList,
  MonetizationOnOutlined,
  ArrowCircleDown,
  ArrowCircleUp,
  ManageSearch,
} from '@mui/icons-material'
import { Radio, RadioGroup, FormControlLabel, FormControl, FormLabel, Container, Slider, Box } from '@mui/material'
import { blue } from '@mui/material/colors'

import images from '../../../assets/images'
import styles from './SearchTool.module.scss'

const cx = classNames.bind(styles)
const marks = [
  {
    value: 0,
    label: '0',
  },
  {
    value: 1,
    label: '1',
  },
  {
    value: 2,
    label: '2',
  },
  {
    value: 3,
    label: '3',
  },
  {
    value: 4,
    label: '>3',
  },
]
let widthWindow = 0
function SearchTool() {
  const [isAscPrice, setIsAscPrice] = useState(true)
  const [priceRange, setPriceRange] = useState([0, 4])
  const [isShowSearch, setIsShowSearch] = useState(true)
  const [isPhone, setIsPhone] = useState(true)

  useEffect(() => {
    widthWindow = window.innerWidth
    if (window.innerWidth < 576) {
      setIsPhone(true)
      setIsShowSearch(false)
    } else {
      setIsPhone(false)
      setIsShowSearch(true)
    }
    const handleWindowResize = () => {
      if (widthWindow == window.innerWidth) return
      if (window.innerWidth < 576) {
        setIsPhone(true)
        setIsShowSearch(false)
      } else {
        setIsPhone(false)
        setIsShowSearch(true)
      }
    }
    handleWindowResize()
    window.addEventListener('resize', handleWindowResize)
    return () => window.removeEventListener('resize', handleWindowResize)
  }, [])
  const handleChangePriceRange = (event: Event, newValue: number | number[]) => {
    console.log(newValue)
    setPriceRange(newValue as number[])
  }
  const handleToggleSearch = () => {
    setIsShowSearch(!isShowSearch)
  }
  return (
    <Container maxWidth="lg" style={{ marginTop: '2rem' }}>
      {isPhone && (
        <div className={cx('toggle-search')} onClick={handleToggleSearch}>
          <ManageSearch
            sx={{
              fontSize: '1.8rem',
              marginRight: '0.5rem',
              color: isShowSearch ? blue[500] : 'black',
              cursor: 'pointer',
              '&:hover': {
                transform: 'scale(1.2)',
                transition: 'all 0.5s',
              },
            }}
          />
          <span>Bộ lọc</span>
        </div>
      )}
      {isShowSearch && (
        <div className={cx('wrapper')}>
          <div className={cx('search', 'mr-5')}>
            <input placeholder="Tìm kiếm tên giày, thương hiệu" />
            <Search className={cx('search-btn')} />
          </div>

          <div className={cx('sort', 'mr-5')}>
            <div className={cx('title')}>Sắp sếp theo giá:</div>
            <div className={cx('icons')}>
              <ArrowCircleUp
                onClick={() => setIsAscPrice(true)}
                sx={{
                  fontSize: '1.5rem',
                  margin: '0 1rem',
                  color: isAscPrice ? blue[500] : 'black',
                  '&:hover': {
                    transform: 'scale(1.5)',
                    cursor: 'pointer',
                    transition: 'all 0.5s',
                  },
                }}
              />
              <ArrowCircleDown
                onClick={() => setIsAscPrice(false)}
                sx={{
                  fontSize: '1.5rem',
                  color: !isAscPrice ? blue[500] : 'black',
                  '&:hover': {
                    transform: 'scale(1.5)',
                    cursor: 'pointer',
                    transition: 'all 0.5s',
                  },
                }}
              />
            </div>
          </div>
          <div className={cx('price-range')}>
            <div className={cx('title')}>Khoảng giá(triệu):</div>
            <div className={cx('slider')}>
              <Slider
                size="small"
                step={0.5}
                value={priceRange}
                onChange={handleChangePriceRange}
                marks={marks}
                //valueLabelDisplay="on"
                min={0}
                max={4}
              />
            </div>
          </div>
        </div>
      )}
    </Container>
  )
}

export default SearchTool

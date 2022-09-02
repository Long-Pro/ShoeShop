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
  FilterAlt,
} from '@mui/icons-material'

import {
  Radio,
  RadioGroup,
  FormControlLabel,
  FormControl,
  FormLabel,
  Container,
  Slider,
  Box,
  Autocomplete,
  TextField,
} from '@mui/material'
import { blue } from '@mui/material/colors'

import images from '../../../assets/images'
import styles from './SearchTool.module.scss'
import { getAllBrand } from '../../../features/brand/brandSlice'
import { updateSortBy, updateBrandId, updatePriceRange, updatePage } from '../../../features/shoe/shoeSlice'
import { useAppSelector, useAppDispatch } from '../../../app/hooks'

export interface AutocompleteType {
  label: string
  value: number | string | number[]
}
const cx = classNames.bind(styles)
let widthWindow = 0

function SearchTool() {
  const dispatch = useAppDispatch()
  const brandState = useAppSelector((state) => state.brand)

  const [sortBy, setSortBy] = useState<string>()
  const [priceRange, setPriceRange] = useState<number[]>()
  const [brand, setBrand] = useState<number>()

  const [brands, setBrands] = useState<AutocompleteType[]>([])
  const [prices, setPrices] = useState<AutocompleteType[]>([
    { label: '<1 triệu', value: [0, 1000000] },
    { label: '1 -> 2 triệu', value: [1000000, 2000000] },
    { label: '2 ->3 triệu', value: [2000000, 3000000] },
    { label: '>3 triệu', value: [3000000, 999999999] },
  ])
  const [sorts, setSorts] = useState<AutocompleteType[]>([
    { label: 'Giá tăng dần', value: 'PRICE_ASC' },
    { label: 'Giá giảm dần', value: 'PRICE_DESC' },
    { label: 'Tên A-Z', value: 'NAME_ASC' },
    { label: 'Tên Z-A', value: 'NAME_DESC' },
  ])

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

  useEffect(() => {
    if (!brandState.isLoaded) dispatch(getAllBrand())
  }, [])
  useEffect(() => {
    if (brandState.isLoaded) {
      const x: AutocompleteType[] = []
      brandState.value.forEach((item) => {
        x.push({ value: item.id, label: item.name })
      })
      setBrands(x)
    }
  }, [brandState])

  // setInterval(() => {
  //   console.log(sortBy)
  //   console.log(priceRange)
  //   console.log(brand)
  // }, 2000)

  const handleToggleSearch = () => {
    setIsShowSearch(!isShowSearch)
  }
  const handleChangeSortBy = (event: any, newValue: AutocompleteType | null) => {
    const value = newValue?.value as string
    setSortBy(value)
    dispatch(updateSortBy(value))
    dispatch(updatePage(1))
  }
  const handleChangePriceRange = (event: any, newValue: AutocompleteType | null) => {
    const value = newValue?.value as number[]
    setPriceRange(value)
    dispatch(updatePriceRange(value))
    dispatch(updatePage(1))
  }
  const handleChangeBrand = (event: any, newValue: AutocompleteType | null) => {
    const value = newValue?.value as number
    setBrand(value)
    dispatch(updateBrandId(value))
    dispatch(updatePage(1))
  }
  return (
    <Container maxWidth="lg" style={{ marginTop: '2rem' }}>
      {isPhone && (
        <div className={cx('toggle-search')} onClick={handleToggleSearch}>
          <FilterAlt
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
          <div className={cx('sort', 'mr-3')}>
            <Autocomplete
              disablePortal
              id="combo-box-sort"
              size="small"
              options={sorts}
              sx={{ width: 180 }}
              onChange={handleChangeSortBy}
              renderInput={(params) => <TextField {...params} label="Sắp xếp" />}
            />
          </div>
          <div className={cx('price-range', 'mr-3')}>
            <Autocomplete
              disablePortal
              id="combo-box-price"
              size="small"
              options={prices}
              sx={{ width: 180 }}
              onChange={handleChangePriceRange}
              renderInput={(params) => <TextField {...params} label="Giá" />}
            />
          </div>
          <div className={cx('brand', 'mr-3')}>
            <Autocomplete
              disablePortal
              id="combo-box-price"
              size="small"
              options={brands}
              sx={{ width: 180 }}
              onChange={handleChangeBrand}
              renderInput={(params) => <TextField {...params} label="Thương hiệu" />}
            />
          </div>
        </div>
      )}
    </Container>
  )
}

export default SearchTool

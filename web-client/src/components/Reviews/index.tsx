import { useState, useEffect } from 'react'
import { Routes, Route, useParams } from 'react-router-dom'
import { Container, Pagination } from '@mui/material'
import classNames from 'classnames/bind'
import StarRatings from 'react-star-ratings'
import ImageViewer from 'react-simple-image-viewer'

import images from '../../assets/images'
import styles from './Reviews.module.scss'
import { useAppSelector, useAppDispatch } from '../../app/hooks'
import { getReviewsByShoeId } from '../../features/reviews/reviewsSlice'
import { Review, ReviewFile } from '../../Interfaces'

const cx = classNames.bind(styles)
function Reviews() {
  const params = useParams()

  const dispatch = useAppDispatch()
  const { value: reviews, totalPage } = useAppSelector((state) => state.reviews)
  const shoeId = parseInt(params.shoeId as string)

  useEffect(() => {
    dispatch(getReviewsByShoeId({ shoeId, page: 1 }))
  }, [])

  const [currentImage, setCurrentImage] = useState(0)
  const [isViewerOpen, setIsViewerOpen] = useState(false)
  const [images, setImages] = useState<string[]>()

  const openImageViewer = (index: number) => {
    setCurrentImage(index)
    setIsViewerOpen(true)
  }
  const closeImageViewer = () => {
    setCurrentImage(0)
    setIsViewerOpen(false)
  }
  const handleClickImage = (item: Review, index: number) => {
    const x = item.reviewFiles.map((i: ReviewFile) => i.link)
    setImages(x)
    openImageViewer(index)
  }

  const [page, setPage] = useState(1)
  const handleChangePage = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value)
    dispatch(getReviewsByShoeId({ shoeId, page: value }))

    const title: any = document.getElementById('review-title')?.offsetTop
    window.scrollTo({ top: title, behavior: 'smooth' })
  }

  return (
    <Container className={cx('wrapper')}>
      <h4 id="review-title">Đánh giá sản phẩm</h4>
      {!reviews && <p>Sản phẩm chưa có đánh giá nào!</p>}
      {reviews && (
        <div className={cx('reviews')}>
          {reviews.map((item: Review, index: number) => (
            <div className={cx('review')} key={index}>
              <div className="d-flex align-items-center">
                <img src={item.customer.avatar} className={cx('avatar')} alt="" />
                <div>
                  <div>{item.customer.account.accountValue}</div>
                  <StarRatings
                    rating={item.star}
                    starRatedColor="yellow"
                    numberOfStars={5}
                    name="rating"
                    starDimension="16px"
                    starSpacing="2px"
                  />
                </div>
              </div>
              <p className={cx('comment')}>{item.comment}</p>
              <div className={cx('images')}>
                {item.reviewFiles.map((x: ReviewFile, i: number) => (
                  <img src={x.link} onClick={() => handleClickImage(item, i)} key={i} />
                ))}
              </div>
            </div>
          ))}
          <div className="d-flex justify-content-center mt-3">
            <Pagination count={totalPage} color="primary" page={page} onChange={handleChangePage} />
          </div>
        </div>
      )}
      {isViewerOpen && (
        <ImageViewer
          src={images as string[]}
          currentIndex={currentImage}
          disableScroll={false}
          closeOnClickOutside={true}
          onClose={closeImageViewer}
        />
      )}
    </Container>
  )
}

export default Reviews

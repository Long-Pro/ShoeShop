import { useState, useEffect, useCallback } from 'react'
import classNames from 'classnames/bind'
import SimpleImageViewer from 'react-simple-image-viewer'

import styles from './ImageViewer.module.scss'
const cx = classNames.bind(styles)
interface Prop {
  images: string[]
}
function ImageViewer(prop: Prop) {
  const { images } = prop
  const [currentImage, setCurrentImage] = useState(0)
  const [isViewerOpen, setIsViewerOpen] = useState(false)
  const openImageViewer = useCallback((index: number) => {
    setCurrentImage(index)
    setIsViewerOpen(true)
  }, [])
  const closeImageViewer = () => {
    setCurrentImage(0)
    setIsViewerOpen(false)
  }

  return (
    <div className={cx('wrapper')}>
      {images.map((item: string, index: number) => (
        <img
          key={index}
          src={item}
          alt=""
          className={index == 0 ? cx('image-first') : cx('image-behind')}
          onClick={() => openImageViewer(index)}
        />
      ))}

      {isViewerOpen && (
        <SimpleImageViewer
          src={images}
          currentIndex={currentImage}
          disableScroll={false}
          closeOnClickOutside={true}
          onClose={closeImageViewer}
        />
      )}
    </div>
  )
}

export default ImageViewer

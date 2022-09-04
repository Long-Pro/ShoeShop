// pages
import { ShoeDetail, Home } from '../pages'

// layout
import { MainLayout } from '../layouts'

const routes = {
  home: '/',
  //shoeDetail: '/shoes/@:idShoe',
  shoeDetail: '/shoes/:shoeId',
}
const publicRoutes = [
  { path: routes.home, component: Home, layout: MainLayout },
  { path: routes.shoeDetail, component: ShoeDetail, layout: MainLayout },
]
const privateRoutes = [{}]

export { publicRoutes, privateRoutes, routes }

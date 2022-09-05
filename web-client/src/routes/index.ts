// pages
import { ShoeDetail, Home, Login } from '../pages'

// layout
import { MainLayout, OnlyHeaderLayout } from '../layouts'

const routes = {
  home: '/',
  //shoeDetail: '/shoes/@:idShoe',
  shoeDetail: '/shoes/:shoeId',
  login: '/login',
}
const publicRoutes = [
  { path: routes.login, component: Login, layout: OnlyHeaderLayout },
  { path: routes.home, component: Home, layout: MainLayout },
  { path: routes.shoeDetail, component: ShoeDetail, layout: MainLayout },
]
const privateRoutes = [{}]

export { publicRoutes, privateRoutes, routes }

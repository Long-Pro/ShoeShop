import routesConfig from '../configs/routes'

// pages
import { ShoeDetail, Home } from '../pages'

// layout
import { MainLayout } from '../layouts'

const publicRoutes = [
  { path: routesConfig.home, component: Home, layout: MainLayout },
  { path: routesConfig.shoeDetail, component: ShoeDetail, layout: MainLayout },
  { path: routesConfig.shoeDetail2, component: ShoeDetail, layout: MainLayout },
]
const privateRoutes = [{}]

export { publicRoutes, privateRoutes }

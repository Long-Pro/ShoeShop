import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import { Fragment } from 'react'

import { publicRoutes, privateRoutes } from './routes'

function App() {
  return (
    <Router>
      <Routes>
        {publicRoutes.map((route, index) => {
          const Page = route.component
          const Layout = route.layout
          return (
            <Route
              path={route.path}
              key={index}
              element={
                <Layout>
                  <Page />
                </Layout>
              }
            ></Route>
          )
        })}
      </Routes>
    </Router>
  )
}

export default App

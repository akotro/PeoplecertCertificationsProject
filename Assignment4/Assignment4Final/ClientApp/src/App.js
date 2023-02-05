import React, { useEffect, useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import { Layout } from './components/Layout';
import './custom.css';

import { getClaims } from './components/auth/handleJWT'
import {AuthenticationContext} from './components/auth/AuthenticationContext';


function App() {
  //static displayName = App.name;
  const [claims, setClaims] = useState(["o"]);

  useEffect(() => {
    setClaims(getClaims())
  }, [])


  function isAdmin() {
    return claims.findIndex(
      claim => claim.name === 'role' &&
        claim.value === 'admin')
      > -1;
  }
  return (
    <AuthenticationContext.Provider value={{claims, setClaims}} >
      <Layout>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, requireAuth, ...rest } = route;
            return <Route key={index} {...rest}
              element={requireAuth ? <AuthorizeRoute {...rest}
                element={element} /> : element} />;
          })}
        </Routes>
      </Layout>
    </AuthenticationContext.Provider>
  );
}
export default App;

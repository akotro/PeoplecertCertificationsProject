import React, { useEffect, useState, } from 'react';
import { Route, Routes, Navigate, useNavigate, Router } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import { Layout } from './components/Layout';
import './custom.css';

import NotAuth from './components/auth/NotAuth';


import { getClaims } from './components/auth/handleJWT'
import { AuthenticationContext } from './components/auth/AuthenticationContext';


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
    <AuthenticationContext.Provider value={{ claims, update: setClaims }} >
      <Layout>
        <Routes>

          {AppRoutes.map((route, index) => {
            const { element, needsAdmin, ...rest } = route;
            return <Route key={index} {...rest}
            element={needsAdmin ? (
              claims.find(claim => claim.name === 'role' &&
        claim.value === 'admin') ? 
                element : 
                <NotAuth />
            ) : element} />;
          })}
        </Routes>

      </Layout>
    </AuthenticationContext.Provider>
  );
}
export default App;

{/* const { element, needsAdmin, ...rest } = route;
            console.log(isAdmin())
            if (route.needsAdmin ===true && isAdmin()===false) {
              console.log("not an dminpage")
              navigate('/NotAuth')
              return null
              return <Navigate to="/NotAuth" />;
            } else {
              return <Route key={index} {...rest} element={ element} />;
            }
            return <Route key={index} {...rest} element={ element} />;
          })} */}

{/* const { element, isAdmin, ...rest } = route;
            return <Route key={index} {...rest}>
            {route.isAdmin && !isAdmin() ? <>no access</> : element }

            </Route>; */}
{/* })} */ }

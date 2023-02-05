import React, { createContext, Component, useState, useEffect } from 'react';
import { getClaims } from './handleJWT'



export const AuthenticationContext = React.createContext();

// export function AuthenticationContextProvider({ children }) {
    
// //     const [claims, setClaims] = useState(["e"]);
// //     const update = () => {}

// //     useEffect(() => {
// //         // console.log(props.value)
// //         console.log(children)
// //   //   setClaims(getClaims())

// //         setClaims(["a"])
// //     }, [])
// //     // value={{claims, setClaims}}

// //     const [props] = useState();
//     return (
//         <AuthenticationContext.Provider  >
//             {children}
//         </AuthenticationContext.Provider>
//     );
// }


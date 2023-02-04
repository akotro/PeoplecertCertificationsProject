import React, { createContext, Component, useState } from 'react';

//gpt
const ContextTemplate = {
    claims: ["a"],
    update: () => { }
}

export const AuthenticationContext = createContext(ContextTemplate);

function AuthenticationContextProvider({ children }){

    const [context] = useState(ContextTemplate)
    return (
        <AuthenticationContext.Provider value={context}>
            {children}
        </AuthenticationContext.Provider>
    );
}

export default AuthenticationContextProvider;

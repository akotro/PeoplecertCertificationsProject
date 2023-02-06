import React, { useEffect, useState, useContext } from "react";
import {AuthenticationContext} from '../components/auth/AuthenticationContext'

function Home() {

  const con = useContext(AuthenticationContext);

    return (
      <div>
        <h1>Hello, world!</h1>
        <h5>Welcome to our Assignment project</h5>
      </div>
    );
}

export default Home;


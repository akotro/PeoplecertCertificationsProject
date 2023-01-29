import { Form, Button, Col, Row, FloatingLabel, Stack , Table  } from 'react-bootstrap';

import {React,useState,useEffect,Component }from 'react';

import axios from 'axios';
import { Link } from 'react-router-dom';



 function Edit()
{
    const[persons,setState] = useState(null);
    let y;
    var x =axios.get(`https://jsonplaceholder.typicode.com/users`);
    useEffect
    ( 
     x.then(response => {
    
    // setState(response);
    console.log(response.data[2].name);
                        }),[]
    )

     return (
         < ul >
         <p>asdadaf</p>
        <p>{persons.data[2].name}</p>
    </ul>
     )
     
     
      
}

            
export default Edit;
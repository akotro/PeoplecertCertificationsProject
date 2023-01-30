import { Form, Button, Col, Row, FloatingLabel, Stack , Table  } from 'react-bootstrap';

import {React,useState,useEffect} from 'react';

import axios from 'axios';
import { Link } from 'react-router-dom';





function Create()
{
    axios.post("https://localhost:7196/api/Questions");

    const nums = [1,2,4,5,6];

    const squared = nums.map((item) =>{return item*item})

    console.log(squared);

    return(
        

        <h1>Inside Create</h1>
    )



}



export default Create;
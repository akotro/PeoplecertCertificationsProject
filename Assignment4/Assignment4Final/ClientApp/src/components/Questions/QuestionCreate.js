import { Form, Button, Col, Row, FloatingLabel, Stack , Table  } from 'react-bootstrap';

import {React,useState,useEffect} from 'react';

import axios from 'axios';
import { Link } from 'react-router-dom';





function Create()
{
    axios.post("https://localhost:7196/api/Questions");


    return(
        

        <h1>Inside Create</h1>
    )



}



export default Create;
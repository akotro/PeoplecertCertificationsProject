import React, { useEffect, useState } from "react";
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { withRouter } from './../Common/with-router';
import { BrowserRouter, Route, useParams } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function Examination(props) {

    const params = useParams();
    const [data, setData] = useState([]);
    const [user, setUser] = useState();
    let navigate = useNavigate();

    useEffect(() => {
        axios.get('https://localhost:7196/api/CandidateExam/notTaken').then((response) => {
            setData(response.data);
        }).catch(function (error) {
            console.log(error);
        });
        if (!user) {
            setUser("admin");
        }
    }, []);

    return (
        <div className='container-fluid'>
            <h1>hi</h1>
        </div>
    );
};

export default Examination;
import React, {  useState, useContext } from "react";
import { useNavigate,  } from "react-router-dom";
import {AuthenticationContext} from '../auth/AuthenticationContext'
import { getClaims, saveToken } from './handleJWT'

import { Button,  Row, Col,  Form, } from 'react-bootstrap';

import axios from 'axios';

export default function Register() {

    const navigate = useNavigate();
    const [errors, setErrors] = useState([]);
    const { update } = useContext(AuthenticationContext);
    const [credentials, setCredentials]= useState([]);

    const register = (event) => {
        event.preventDefault();
        
        setErrors([]);
        axios.post(`https://localhost:7196/api/accounts/create`, credentials).then(
            res => {
                saveToken(res.data);
                update(getClaims());
                navigate("/candidate/create");
            }
        ).catch(function (error) {
            setErrors(error.response.data);
            console.log(error);
        });
    }

    const handleChangeRegister = (event) => {
        const { name, value } = event.target;
        setCredentials({ ...credentials, [name]: value });
    }

    return (
        <div>
            <h3>Register</h3>
            <Form onSubmit={register}>
                <Row>
                    <Col>
                        <Form.Group >
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="email" name="email" value={credentials.email} onChange={handleChangeRegister} />
                        </Form.Group>
                    </Col>
                    </Row>
                    <Row>
                        
                    <Col>
                        <Form.Group >
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" name="password" value={credentials.password} onChange={handleChangeRegister} />
                        </Form.Group>
                    </Col>
                </Row>
                <Button variant="primary" type="submit">Register</Button>
            </Form>
        </div>
    );
}

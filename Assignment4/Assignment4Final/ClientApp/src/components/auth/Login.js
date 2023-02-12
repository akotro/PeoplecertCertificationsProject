import React, { useEffect, useState, useContext} from "react";
import { useNavigate, useParams } from "react-router-dom";
import { AuthenticationContext } from '../auth/AuthenticationContext'
import { getClaims, saveToken } from './handleJWT'
import Errors from '../Common/ErrorList'


import { ListGroup, ListGroupItem, Button, Table, Row, Col, Stack, Form, CloseButton } from 'react-bootstrap';

import axios from 'axios';

export default function Login() {
    const navigate = useNavigate();

    const [error, setError] = useState(null);
    const { update } = useContext(AuthenticationContext);
    const [credentials, setCredentials] = useState([]);

    const login = (event) => {
        event.preventDefault();
        console.log(credentials)
        console.log(update)

        axios.post(`https://localhost:7196/api/accounts/login`, credentials).then(
            res => {
                saveToken(res.data);
                update(getClaims());
                setError([]);
                navigate("/");
            }
        ).catch(function (error) {
            console.log(error.response.data);
            console.log(error);
            if (error.response && error.response.status === 400) {
                setError("Failed login please check your credentials.");
            } else {
                setError(error);
            }
        });
    }

    const handleChange = (event) => {
        const { name, value, type } = event.target;

        setCredentials({ ...credentials, [name]: value });

        // console.log(credentials);
    }

    return (
        <div>
            {error && <Errors error={error} />}
            <h3>Login</h3>
            <Form onSubmit={login}>
                <Row>
                    <Col>
                        <Form.Group >
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="email" name="email" value={credentials.email} onChange={handleChange} />
                        </Form.Group>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <Form.Group >
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" name="password" value={credentials.password} onChange={handleChange} />
                        </Form.Group>
                    </Col>
                </Row>
                <Button variant="primary" type="submit">login</Button>

            </Form>
        </div>

    );
}

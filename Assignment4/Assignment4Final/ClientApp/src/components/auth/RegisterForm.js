import React, { useState, useContext } from 'react';
import { useNavigate } from "react-router-dom";
import { Form, Button, Container, Row, Col, FormControl, FormGroup, Checkbox } from 'react-bootstrap';
import { AuthenticationContext } from '../auth/AuthenticationContext'
import { getClaims, saveToken } from './handleJWT'
import ErrorsRegister from '../Common/ErrorListRegister'
import axios from 'axios';

const RegisterForm = () => {
  const navigate = useNavigate();
  const { update } = useContext(AuthenticationContext);
  const [error, setError] = useState(null);

  const [user, setUser] = useState({
    // Id: '',
    UserName: '',
    Email: '',
    // PhoneNumber: '',
    // Role: '',
    Credentials: {
      Email: '',
      Password: '',
      IsCandidate: true
    }
  });

  const handleChange = (event) => {
    const target = event.target;
    const name = target.name;
    const value = target.value;
    if (name === 'Email') {
      setUser({
        ...user,
        [name]: value,
        Credentials: {
          ...user.Credentials,
          [name]: value,
        },
      });
    }
    else {
      setUser({
        ...user,
        [name]: value
      });
    }
  };

  const handleCredentialsChange = (event) => {
    const target = event.target;
    const name = target.name;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    setUser({
      ...user,
      Credentials: {
        ...user.Credentials,
        [name]: value
      }
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    axios.post(`https://localhost:7196/api/accounts/create`, user)
    .then(response => {
      console.log(response);

      saveToken(response.data);
      update(getClaims());
      setError([]);

      if (user.Credentials.IsCandidate === true) {
        navigate("/candidate/create");
      }
      else {
        navigate("/");
      }
    })
    .catch(error => {
      console.error(error);
      setError(error);
    });
  };

return (
    <Container>
      {error && <ErrorsRegister error={error} />}
      <h3>Register</h3>
      <Row>
        <Col>
          <Form onSubmit={handleSubmit}>
            <Form.Group controlId="formBasicEmail">
              <Form.Label>Email address</Form.Label>
              <Form.Control
                type="email"
                placeholder="Enter email"
                name="Email"
                value={user.Email}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group controlId="formBasicUserName">
              <Form.Label>Username</Form.Label>
              <Form.Control
                type="text"
                placeholder="Enter username"
                name="UserName"
                value={user.UserName}
                onChange={handleChange}
              />
            </Form.Group>
            {/* <Form.Group controlId="formBasicPhoneNumber"> */}
            {/*   <Form.Label>Phone Number</Form.Label> */}
            {/*   <Form.Control */}
            {/*     type="text" */}
            {/*     placeholder="Enter phone number" */}
            {/*     name="PhoneNumber" */}
            {/*     value={user.PhoneNumber} */}
            {/*     onChange={handleChange} */}
            {/*   /> */}
            {/* </Form.Group> */}
            {/* <Form.Group controlId="formBasicRole"> */}
            {/*   <Form.Label>Role</Form.Label> */}
            {/*   <Form.Control */}
            {/*     type="text" */}
            {/*     placeholder="Enter role" */}
            {/*     name="Role" */}
            {/*     value={user.Role} */}
            {/*     onChange={handleChange} */}
            {/*   /> */}
            {/* </Form.Group> */}
            {/* <Form.Group controlId="formBasicCredentialsEmail"> */}
            {/*   <Form.Label>Credentials Email</Form.Label> */}
            {/*   <Form.Control */}
            {/*     type="email" */}
            {/*     placeholder="Enter email" */}
            {/*     name="Email" */}
            {/*     value={user.Credentials.Email} */}
            {/*     onChange={handleCredentialsChange} */}
            {/*   /> */}
            {/* </Form.Group> */}
            <Form.Group controlId="formBasicCredentialsPassword">
              <Form.Label>Password</Form.Label>
              <Form.Control
                type="password"
                placeholder="Password"
                name="Password"
                value={user.Credentials.Password}
                onChange={handleCredentialsChange}
              />
            </Form.Group>
            <Form.Group controlId="formBasicCredentialsIsCandidate">
              <Form.Check
                type="checkbox"
                label="Register As Candidate?"
                name="IsCandidate"
                checked={user.Credentials.IsCandidate}
                onChange={handleCredentialsChange}
              />
            </Form.Group>
            <Button variant="primary" type="submit">
              Submit
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default RegisterForm;

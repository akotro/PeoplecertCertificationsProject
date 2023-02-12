import React, { useEffect, useState, useContext } from "react";

import { ListGroup, ListGroupItem, Button, Table, Row, Col, Stack, Form, CloseButton } from 'react-bootstrap';
import { AuthenticationContext } from '../auth/AuthenticationContext'
import { getUserId } from '../auth/handleJWT'

import { useNavigate, useParams } from "react-router-dom";
import DatePicker from "react-datepicker";
// import Register from "../auth/Register";
import "react-datepicker/dist/react-datepicker.css";
import axios from "axios";
import { getClaims, saveToken } from './handleJWT'
import Errors from '../Common/ErrorList'

function Register() {

  const params = useParams();
  const navigate = useNavigate();
  const { update } = useContext(AuthenticationContext);
  const [error, setError] = useState();
  const [user, setUser] = useState({});
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  const [credentials, setCredentials] = useState({
    "email": "user@example.com",
    "password": "string",
    "isCandidate": true
  });
  const [roles, setRoles] = useState([]);

  const fetchData = () => {
    if (params.email)
    {
      axios
        .get(`https://localhost:7196/api/accounts/getUser/${params.email}`)
        .then((response) => {
          setUser(response.data);
          // console.log(response.data)
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  };
  
  useEffect(() => {
    fetchData();
  }, []);
  const handleChange = (event) => {

    const { name, value, type, checked } = event.target;
    //console.log(event.target)
    //console.log(name);
    //console.log(type);

    if (type === 'checkbox') {
      // let candBool = false
      // if (event.target.checked === "on")
      // {
      //   candBool = true
      // }

      console.log('checkbox', checked)
      setUser({
        ...user,
        credentials: {
          // ...credentials,
          email: user.email,
          password: confirmPassword,
          isCandidate: checked
        }
      })
    }

    // console.log(value)
    else if (name === "newPassword2") {
      setConfirmPassword(value);
      if(value === password) {
        console.log("same!")
        setUser({
          ...user,
          credentials: {
            ...credentials,
            email: user.email,
            password: password
          }
        });
      }
    } else if (name === "newPassword1") {
      setPassword(value);
      if(value === confirmPassword) {
        console.log("same!")
        setUser({
          ...user,
          credentials: {
            ...credentials,
            email: user.email,
            password: confirmPassword
          }
        });
    }}
     else {
      setUser({ ...user, [name]: value })
    }

    // if (password1.newPassword1 === password2.newPassword2) {
    //   console.log("equal!")
    //   setError(null)
    //   setCredentials({
    //     ...credentials, email: user.email,
    //     password: password1,
    //     newPassword: password1,
    //     isCandidate: null
    //   })
    //   setUser({ ...user, credentials })

    }

const handleSubmit = (event) => {
  event.preventDefault();
  if (password !== confirmPassword) {
    console.log("Passwords do not match");
    setError("Passwords do not match");
  } else {
    console.log("I will send");
  

    if (params.email)
    {
      axios.put(`https://localhost:7196/api/accounts/update/${user.email}`, user)
        .then((response) => {
          console.log(response);
        })
        .catch(function (error) {
          console.log(error);
        });    
    }
    else {
      axios.post(`https://localhost:7196/api/accounts/create`, user)
        .then((response) => {
          console.log(response);
          saveToken(response.data);
          update(getClaims());

          if (user.credentials.isCandidate === true) {
            navigate("/candidate/create");
          }
          else {
            navigate("/");
          }
        })
        .catch(function (error) {
          console.log(error);
          setError(error);
        });    
    }
  }
};


  // //for a user who is not a candidate.
  // if (params.id === undefined) {
  //     await axios.post(`https://localhost:7196/api/Candidate`, candidate)
  //         .then(function (response) {
  //             console.log(candidate)
  //             console.log(response);
  //         })
  //         .catch(function (error) {
  //             console.log(candidate)
  //             console.log(error);
  //         });
  // } else {
  //     await axios.put(`https://localhost:7196/api/Candidate/${params.id}`, candidate)
  //         .then(function (response) {
  //             console.log(response);
  //         })
  //         .catch(function (error) {
  //             console.log(error);
  //         });
  // }

  // navigate('/candidate')

  // console.log("THIS IS MINE ", candidate);


return (
  <div>
    {/* {error && <div>Passwords do not match</div>} */}
    <div>
      {error && <Errors error={error} />}
    </div>
    <Form onSubmit={handleSubmit} className="lead" >
      <Stack gap={3}>
        <Row>
          <Col>
            <Form.Group >
              <Form.Label>Username</Form.Label>
              <Form.Control type="text" name="userName" value={user.userName} onChange={handleChange} required />
            </Form.Group>
          </Col>
          <Col>
            <Form.Group >
              <Form.Label>Email</Form.Label>
              <Form.Control type="text" name="email" value={user.email} onChange={handleChange} />
            </Form.Group>
          </Col>
        </Row>
        <Row>
          <Row>
            Create Password
          </Row>
          <Col>
            <Form.Group >
              <Form.Label>Password</Form.Label>
              <Form.Control type="text" name="newPassword1" value={password} onChange={handleChange} required />
            </Form.Group>
          </Col>
          <Row>
            <Col>
              <Form.Group >
                <Form.Label>Confirm Password</Form.Label>
                <Form.Control type="text" name="newPassword2" value={confirmPassword} onChange={handleChange} required />
              </Form.Group>
            </Col>
          </Row>
        </Row>
        <Row>
          <Col>
              <Form.Label>Register As Candidate?</Form.Label>
              <Form.Check name="isCandidate" type="checkbox" defaultChecked={true} onChange={handleChange}/>
          </Col>
        </Row>


        <Button variant="primary" type="submit" >
          Save
        </Button>
      </Stack>
    </Form>
    <Button variant='dark' className='d-grid gap-2 col-12 mx-auto py-2 my-2' onClick={() => navigate(-1)}>Go back</Button>
  </div>
)
}


export default Register;


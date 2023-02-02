import React, { useEffect, useState } from "react";

import { ListGroup, ListGroupItem, Button, Table, Row, Col, Stack, Form } from 'react-bootstrap';

import { useNavigate, useParams } from "react-router-dom";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import axios from 'axios';

export default function CandidateEdit(props) {

    const params = useParams();
    const [genders, setGenders] = useState([]);
    const [languages, setLanguages] = useState([]);
    const [photoIdTypes, setPhotoIdTypes] = useState([]);
    //console.log(params.id);
    const [candidate, setCandidate] = useState({
        dateOfBirth: null,
        photoIdIssueDate: null,
        gender: [],
        language: [],
        photoIdType: [],
        address: []
    });

    useEffect(() => {
        axios.get(`https://localhost:7196/api/Candidate/${params.id}`).then((response) => {
            setCandidate(response.data.data);
        }).catch(function (error) {
            console.log(error);
        });

        axios.get(`https://localhost:7196/api/Genders`).then((response) => {
            setGenders(response.data.data);
        }).catch(function (error) {
            console.log(error);
        });

        axios.get(`https://localhost:7196/api/Languages`).then((response) => {
            setLanguages(response.data.data);
        }).catch(function (error) {
            console.log(error);
        });

        axios.get(`https://localhost:7196/api/PhotoIdTypes`).then((response) => {
            setPhotoIdTypes(response.data.data);
        }).catch(function (error) {
            console.log(error);
        });

    }, []);

    const handleSubmit = (event) => {
        event.preventDefault();

        //axios.put(`https://localhost:7196/api/Candidate/${params.id}`, candidate)
        //    .then(function (response) {
        //        console.log(response);
        //    })
        //    .catch(function (error) {
        //        console.log(error);
        //    });

        console.log(candidate);
    }

    const handleChange = (event) => {

        const { name, value } = event.target;
        console.log(event.target)
        console.log(name);
        console.log(value);
        if (name === "gender") {
            setCandidate({ ...candidate, [name]: genders.find(item => item.id === Number(value)) });
        } else if (name === "language") {
            setCandidate({ ...candidate, [name]: languages.find(item => item.id === Number(value)) });
        } else if (name === "photoIdType") {
            setCandidate({ ...candidate, [name]: languages.find(item => item.id === Number(value)) });
        } else {
            setCandidate({ ...candidate, [name]: value });
        }

        console.log(candidate);
    };
        const convertStringToDate = (dateString) => {
            //intial format 
            //2015-07-15
            const date = new Date(dateString);
            //Wed Jul 15 2015 00:00:00 GMT-0700 (Pacific Daylight Time)
            const finalDateString = date.toISOString(date)
            //2015-07-15T00:00:00.000Z

            console.log(finalDateString); // "1930-07-17T00:00:00.000Z"
            return finalDateString;
    }

    const convertDateToString = (date) => {
        //console.log(date);
        let kati = new Date(date);
        console.log(candidate.dateOfBirth)
        console.log(kati);

        let formattedDate = kati.toISOString().substr(0, 10);

        //console.log(formattedDate);


        return formattedDate;
    }

    //console.log(candidate)

    return (
        <div>edit page
            <p>{params.id}</p>
            <Form onSubmit={handleSubmit} className="lead">
                <Stack gap={3}>
                    <div className="display-6 fs-2" >Personal Details</div>

                    <Row>
                        <Col>
                            <Form.Group >
                                <Form.Label>First Name</Form.Label>
                                <Form.Control type="text" name="firstName" value={candidate.firstName} onChange={handleChange} />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group >
                                <Form.Label>Middle Name</Form.Label>
                                <Form.Control type="text" name="middleName" value={candidate.middleName} onChange={handleChange} />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group >
                                <Form.Label>Last Name</Form.Label>
                                <Form.Control type="text" name="lastName" value={candidate.lastName} onChange={handleChange} />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group >
                                <Form.Label>Gender</Form.Label>
                                <Form.Select as="select" name="gender"
                                    value={candidate.gender.id}
                                    onChange={handleChange}>
                                    {genders.map((gender, index) =>
                                        <option key={index}
                                            value={gender.id}
                                        >{gender.genderType}</option>
                                    )}
                                </Form.Select>
                            </Form.Group>
                        </Col>
                    </Row>
                    <hr />
                    <Row>
                        <Col>
                            <Form.Group >
                                <Form.Label>Date of Birth</Form.Label>
                                <Form.Control type="date"
                                    name="dateOfBirth"
                                    value={convertDateToString(candidate.dateOfBirth)}
                                    onChange={handleChange} />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group >
                                <Form.Label>Native Language</Form.Label>
                                <Form.Select as="select" name="language"
                                    value={candidate.language.id}
                                    onChange={handleChange}>
                                    {languages.map((lan, index) =>
                                        <option key={index}
                                            value={lan.id}
                                        >{lan.nativeLanguage}</option>
                                    )}
                                </Form.Select>
                            </Form.Group>
                        </Col>
                    </Row>
                    <hr />
                    <div className="display-6 fs-2" >Contact Details</div>
                    <div className="display-6 fs-2" >need to add addresses</div>

                    <Row>
                        <Col>
                            <Form.Group >
                                <Form.Label>Email</Form.Label>
                                <Form.Control type="email" name="email" value={candidate.email} onChange={handleChange} />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group >
                                <Form.Label>Candidate Number</Form.Label>
                                <Form.Control type="number" name="candidateNumber" value={candidate.candidateNumber} onChange={handleChange} />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group >
                                <Form.Label>Landline Number</Form.Label>
                                <Form.Control type="text" name="landline" value={candidate.landline} onChange={handleChange} />
                            </Form.Group>
                        </Col>

                        <Col>
                            <Form.Group >
                                <Form.Label>Mobile Number</Form.Label>
                                <Form.Control type="text" name="mobile" value={candidate.mobile} onChange={handleChange} />
                            </Form.Group>
                        </Col>
                    </Row>


                    <div className="display-6 fs-2" >Identification Details</div>

                    <Row>
                        <Col>
                            <Form.Group >
                                <Form.Label>Photo ID Number</Form.Label>
                                <Form.Control type="text" name="photoIdNumber" value={candidate.photoIdNumber} onChange={handleChange} />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group >
                                <Form.Label>Photo Issue Date</Form.Label>
                                <Form.Control type="date"
                                    name="photoIdIssueDate"
                                value={convertDateToString(candidate.photoIdIssueDate)}
                                    onChange={handleChange} />
                        </Form.Group>
                       
                        </Col>
                        <Col>
                            <Form.Group >
                                <Form.Label>Type of Id</Form.Label>
                                <Form.Select as="select" name="photoIdType"
                                    value={candidate.photoIdType.id}
                                    onChange={handleChange}>
                                    {photoIdTypes.map((pId, index) =>
                                        <option key={index}
                                            value={pId.id}
                                        >{pId.idType}</option>
                                    )}
                                </Form.Select>

                            </Form.Group>
                        </Col>

                        <Col>
                            <Form.Group >
                                <Form.Label>Mobile Number</Form.Label>
                                <Form.Control type="text" name="mobile" value={candidate.mobile} onChange={handleChange} />
                            </Form.Group>
                        </Col>
                    </Row>
                    <Button variant="primary" type="submit">
                        Save
                    </Button>
                </Stack>
            </Form>

        </div>
    )
}

//
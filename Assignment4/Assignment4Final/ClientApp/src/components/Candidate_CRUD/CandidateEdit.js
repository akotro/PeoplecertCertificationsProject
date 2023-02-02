import React, { useEffect, useState } from "react";

import { ListGroup, ListGroupItem, Button, Table, Row, Col, Stack, Form } from 'react-bootstrap';

import { useNavigate, useParams } from "react-router-dom";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import axios from 'axios';

export default function CandidateEdit(props) {

    const params = useParams();
    const [genders, setGenders] = useState([  ]);
    //console.log(params.id);
    const [candidate, setCandidate] = useState({
        dateOfBirth: new Date(),
        gender: [],
        language: [],
        photoIdType: [],
        address: []
    });


    //    "appUserId": "51298282-ae59-4a40-abc5-476829cb273c",
    //    "firstName": "Irwin",
    //    "middleName": "Margie",
    //    "lastName": "Aufderhar",
    //    "dateOfBirth": "1956-07-18T10:53:32.0145514",
    //    "email": "Nathaniel.MacGyver19@yahoo.com",
    //    "landline": "590-582-0873",
    //    "mobile": "513.394.7239 x203",
    //    "candidateNumber": "838770124",
    //    "photoIdNumber": "3qjrqa",
    //    "photoIdIssueDate": "2020-02-03T13:38:12.0597833",
    //    "gender": "{genderType: \"Male\", id: 2}",
    //    "language": "{id: 1, nativeLanguage: \"English\"}",
    //    "photoIdType": "{id: 3, idType: \"National\"}",
    //    "address": "[{…}, {…}]"


    useEffect(() => {
        axios.get(`https://localhost:7196/api/Candidate/${params.id}`).then((response) => {
            setCandidate(response.data.data);
            //console.log(candidate)
        }).catch(function (error) {
            console.log(error);
        });

        axios.get(`https://localhost:7196/api/Genders`).then((response) => {
            setGenders(response.data.data);
            console.log(genders)
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
            setCandidate({ ...candidate, [name]: genders.find(item => item.id === Number(value)) } );
        } else {
        setCandidate({ ...candidate, [name]: value });

        }

        console.log(candidate);
    };

    const convertDateToString = (date) => {
        //console.log(date);
        const kati = new Date(date);

        //console.log(kati);

        const formattedDate = kati.toISOString().substr(0, 10);

        //console.log(formattedDate);


        return formattedDate;
    }

    //console.log(candidate)

    return (
        <div>edit page
            <p>{params.id}</p>
            <Form onSubmit={handleSubmit}>
                <Stack gap={3}>
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
                                            value={gender.id }
                                        >{gender.genderType}</option>
                                        )}
                                </Form.Select>
                            </Form.Group>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                        </Col>
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
                                <Form.Label>Last Name</Form.Label>
                                <Form.Control type="text" name="lastName" value={candidate.lastName} onChange={handleChange} />
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
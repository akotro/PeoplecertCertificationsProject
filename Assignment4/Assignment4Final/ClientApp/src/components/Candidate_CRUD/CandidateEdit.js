import React, { useEffect, useState } from "react";

import { ListGroup, ListGroupItem, Button, Table, Row, Stack, Form } from 'react-bootstrap';

import { useNavigate, useParams } from "react-router-dom";

import axios from 'axios';

export default function CandidateEdit(props) {

    const params = useParams();
    //console.log(params.id);
    const [candidate, setCandidate] = useState();

    useEffect(() => {
        axios.get(`https://localhost:7196/api/Candidate/${params.id}`).then((response) => {
            setCandidate(response.data);
            console.log(candidate)
        }).catch(function (error) {
            console.log(error);
        });
    });

    const handleSubmit = (event) => {
        axios.put(`https://localhost:7196/api/Candidate/${params.id}`, candidate)
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });

    }

    return (
        <div>edit page
            <p>{params.id}</p>

            <Form onSubmit={handleSubmit}>
                <Stack gap={3}>

                    <Button variant="primary" type="submit">
                        Save
                    </Button>
                </Stack>
            </Form>
        </div>
    )
}
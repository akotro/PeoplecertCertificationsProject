
import React, { useEffect, useState, useContext } from 'react';
import { AuthenticationContext } from '../auth/AuthenticationContext'

import { ListGroup, ListGroupItem, Button, Table, Row, Col, Stack, Form, CloseButton, FloatingLabel } from 'react-bootstrap';

import { useNavigate, useParams } from 'react-router-dom';
import axios from 'axios';

import Multiselect from 'multiselect-react-dropdown';

function CertificateForm(props) {

    const params = useParams();
    const navigate = useNavigate();

    const [data, setData] = useState([]);
    const [allTopics, setallTopics] = useState([]);

    const { update, claims } = useContext(AuthenticationContext);
    const [role, setRole] = useState(claims.find(claim => claim.name === 'role').value)

    useEffect(() => {
        getData();
    }, [])


    const getData = () => {
        let id = props.id;
        // GET details for the certificate with current id

        if (params.id !== undefined) {
            axios.get(`https://localhost:7196/api/Certificates/${params.id}`).then((response) => {
                setData(response.data.data);
            }).catch(function (error) {
                console.log(error);
            });
        }

        // GET all the topics and places int the allTopics
        axios.get(`https://localhost:7196/api/Topics`)
            .then(res => {
                //console.log(res.data.data);
                setallTopics(res.data.data);
            })
            .catch(err => {
                console.error(err);
            });
    }

    // what called recalculates the maxMarks according to the selected topic options
    const CalculateMaxMarks = (selectedOptions) => {
        let total = 0;

        selectedOptions.forEach(element => {
            total += element.maxMarks;
        });
        setData({
            ...data, maxMark: total
        });
    }


    //adds the values selected to the list of topics 
    const onSelect = (selectedOptions) => {
        data.topics = selectedOptions
        setData({ data })
        CalculateMaxMarks(selectedOptions);
    }

    //removes the values un-selected from the list of topics 
    const onRemove = (selectedOptions, removedItem) => {
        data.topics = selectedOptions.filter(item => item !== removedItem)
        setData({ data })
        CalculateMaxMarks(selectedOptions);
    }

    // updates any change to the Certificate
    const handleChange = (event) => {
        const { name, value, type } = event.target;

        console.log("name",name);
        console.log("type", type);
        console.log("value", value);
        
        if (type === 'checkbox') {
            setData({ ...data, [name]: event.target.checked })
        } else if (type === 'number') {
            setData({ ...data, [name]: Number(value) })
        } else {
            setData({ ...data, [name]: value })
        }
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        if (params.id !== undefined) {

            //PUTs the updated data for the cert 
            axios.put(`https://localhost:7196/api/Certificates/${data.id}`, data)
                .then(function (response) {
                    console.log(response);
                })
                .catch(function (error) {
                    console.log(error);
                });
        } else {
            axios.post(`https://localhost:7196/api/Certificates`, data)
                .then(function (response) {
                    console.log(response);
                })
                .catch(function (error) {
                    console.log(error);
                });

        }        
    }

    return (
        <div>
            <fieldset disabled={role ? (role === "qualitycontrol") : false}>

                <Form onSubmit={handleSubmit} >
                    <Stack gap={3}>
                        <Row>
                            <Col md={10}>
                                <Form.Group >
                                    <Form.Label>Title</Form.Label>
                                    <Form.Control type="text" name="title" value={data.title} onChange={handleChange} />
                                </Form.Group>
                            </Col>
                            <Form.Group as={Col}>
                                <Form.Label>Passing Mark</Form.Label>
                                <Form.Control type="number" step="1" min="0"
                                    name='passingMark'

                                    max="100" value={data.passingMark} onChange={handleChange} />
                            </Form.Group>
                        </Row>
                        <Row>
                            <Col md={10}>
                                <Form.Group>
                                    <Form.Label>Category</Form.Label>
                                    <Form.Control type="text"
                                        name='category'
                                        value={data.category} onChange={handleChange} />
                                </Form.Group>

                            </Col>

                            <Form.Group as={Col}>
                                <Form.Label>Max Mark</Form.Label>
                                <Form.Control type="text" value={data.maxMark} disabled />
                            </Form.Group>
                        </Row>

                        <FloatingLabel label="Description" >
                            <Form.Control
                                as="textarea"
                                name='description'
                                style={{ height: '100px' }}
                                value={data.description} onChange={handleChange}
                            />
                        </FloatingLabel>
                        <Form.Group>
                            <Form.Label>Topics</Form.Label>
                            <Multiselect
                                name='topics'
                                options={allTopics} // Options to display in the dropdown
                                onSelect={onSelect} // Function will trigger on select event
                                onRemove={onRemove} // Function will trigger on remove event
                                selectedValues={data.topics}
                                displayValue="name" // Property name to display in the dropdown options
                                placeholder="Please select as many Topics as needed for the certificate"
                                hidePlaceholder="true"
                                showCheckbox="true"
                                closeIcon="cancel"
                                showArrow="true"
                                isMulti={true}
                                value={data.topics}
                            // onChange={handleChange}
                            />
                        </Form.Group>
                        <Col xs="auto" className="my-1">
                            <Form.Check
                                type="checkbox"
                                // defaultChecked={complete}
                                name='active'
                                label="Is the certificate available for puchase?"
                                defaultChecked={data.active}
                                onChange={handleChange}
                            />
                        </Col>
                        {role !== "qualitycontrol" &&

                            <Button variant="primary" type="submit">
                                Save
                            </Button>
                        }
                    </Stack>
                </Form >
            </fieldset>
            <Button variant='dark' className='d-grid gap-2 col-12 mx-auto py-2 my-2' onClick={() => navigate(-1)}> Go Back </Button>
        </div>

    )
}


export default CertificateForm;

import { Form, Button, Col, Row, FloatingLabel, Stack } from 'react-bootstrap';
import React, { Component, useState } from 'react';
import axios from 'axios';

import Multiselect from 'multiselect-react-dropdown';


class CreateCertificateForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            allTopics: [],
            newCert: {}
        }
    }

    componentDidMount() {
        axios.get(`https://localhost:7196/api/Topics`)
            .then(res => {

                console.log(res.data.data);
                this.setState({ allTopics: res.data.data });
            })
            .catch(err => {
                console.error(err);
            });
    }

    CalculateMaxMarks = (selectedTopics) => {
        let total = 0;
        selectedTopics.forEach((topic) => {
            total += topic.maxMarks;
        });
        this.setState(prevState => ({
            newCert: {
                ...prevState.newCert,
                maxMark: total
            }
        }));
    }



    //adds the values selectes to the list of topics 
    onSelect = (selectedTopics) => {

        this.setState(prevState => ({
            newCert: {
                ...prevState.newCert,
                topics: [...selectedTopics]
            }
        }));
        this.CalculateMaxMarks(selectedTopics);
        //}
    }

    //removes the values un-selected from the list of topics 
    onRemove = (selectedOptions, removedItem) => {

        this.setState(prevState => ({
            newCert: {
                ...prevState.newCert,
                topics: [...selectedOptions.filter(item => item !== removedItem)]
            }
        }));
        this.CalculateMaxMarks(selectedOptions);

    }

    handleChange = (event) => {

        if (event.target.name == 'active') {
            this.setState(prevState => ({
                newCert: {
                    ...prevState.newCert,
                    [event.target.name]: event.target.checked
                }
            }));
        } else {
            this.setState(prevState => ({
                newCert: {
                    ...prevState.newCert,
                    [event.target.name]: event.target.value
                }
            }));

        }
    }

    handleSubmit = (event) => {
        event.preventDefault();
        // handle form submit logic here with an axios post method

        console.log(this.state.newCert)
        axios.post('https://localhost:7196/api/Certificates', this.state.newCert)
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });


        console.log("Title = ", this.state.title,
            "desc = ", this.state.description,
            "passmark = ", this.state.passingMark,
            "maxmark = ", this.state.maxMark,
            "cat = ", this.state.category,
            "active = ", this.state.active,
            "selectedtopics = ", this.state.topics);

    }
    render() {
        return (
            <Form onSubmit={this.handleSubmit} >
                <Stack gap={3}>
                    <Row >
                        <Col md={10}>
                            <Form.Group >
                                <Form.Label>Title</Form.Label>
                                <Form.Control type="text"
                                    name='title'
                                    value={this.state.newCert.title} onChange={this.handleChange} />
                            </Form.Group>

                        </Col>

                        <Form.Group as={Col}>
                            <Form.Label>Passing Mark</Form.Label>
                            <Form.Control type="number" step="1" min="0"
                                name='passingMark'
                                max="100" value={this.state.newCert.passingMark} onChange={this.handleChange} />
                        </Form.Group>
                    </Row>
                    <Row>
                        <Col md={10}>
                            <Form.Group>
                                <Form.Label>Category</Form.Label>
                                <Form.Control type="text"
                                    name='category'
                                    value={this.state.newCert.category} onChange={this.handleChange} />
                            </Form.Group>

                        </Col>

                        <Form.Group as={Col}>
                            <Form.Label>Max Mark</Form.Label>
                            <Form.Control type="text" value={this.state.newCert.maxMark} disabled />
                        </Form.Group>
                    </Row>

                    <FloatingLabel label="Description" >
                        <Form.Control
                            as="textarea"
                            name='description'
                            style={{ height: '100px' }}
                            value={this.state.newCert.description} onChange={this.handleChange}
                        />
                    </FloatingLabel>
                    <Form.Group>
                        <Form.Label>Topics</Form.Label>
                        <Multiselect
                            name="topics"
                            options={this.state.allTopics} // Options to display in the dropdown
                            onSelect={this.onSelect} // Function will trigger on select event
                            onRemove={this.onRemove} // Function will trigger on remove event
                            displayValue="name" // Property name to display in the dropdown options
                            placeholder="Please select as many Topics as needed for the certificate"
                            hidePlaceholder="true"
                            showCheckbox="true"
                            closeIcon="cancel"
                            showArrow="true"
                            isMulti={true}
                            defaultValue={this.state.newCert.topics}
                            onChange={this.handleChange}
                        />
                    </Form.Group>
                    <Col xs="auto" className="my-1">
                        <Form.Check
                            name='active'
                            type="checkbox"
                            label="Is the certificate available for puchase?"
                            defaultChecked={this.state.newCert.active}
                            onChange={this.handleChange}
                        />
                    </Col>
                    <Button variant="primary" type="submit">
                        Create
                    </Button>
                </Stack>
            </Form>
        )
    }
}

export default CreateCertificateForm;

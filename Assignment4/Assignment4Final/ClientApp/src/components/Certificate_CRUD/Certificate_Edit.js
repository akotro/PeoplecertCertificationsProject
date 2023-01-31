
import { Form, Button, Col, Row, FloatingLabel, Stack } from 'react-bootstrap';
import React, { Component } from 'react';
import { useLocation } from 'react-router-dom';

import { withRouter } from './../Common/with-router';


import axios from 'axios';

import Multiselect from 'multiselect-react-dropdown';

class EditCertificateForm extends Component {

    constructor(props) {
        super(props);
        this.state = {
            allTopics: [],
            data: {}
        }
    }

    componentDidMount() {
        
    // using id whe can axios call for all the details we need,
        console.log(this.props.router.params.id);
        let id = this.props.router.params.id;

        // GET details for the certificate with current id
        axios.get(`https://localhost:7196/api/Certificates/${id}`)
            .then(res => {

                //console.log(res.data.data);
                this.setState({ data: res.data.data });
            })
            .catch(err => {
                console.error(err);
            });

        // GET all the topics and places int the this.state.allTopics
        axios.get(`https://localhost:7196/api/Topics`)
            .then(res => {
                //console.log(res.data.data);
                this.setState({ allTopics: res.data.data });
            })
            .catch(err => {
                console.error(err);
            });
    }

    // what called recalculates the maxMarks according to the selected topic options
    CalculateMaxMarks = (selectedOptions) => {
        let total = 0;
        selectedOptions.forEach(element => {
            total += element.maxMarks;
        });

        this.setState(prevState => ({
            data: {
                ...prevState.data,
                maxMark: total
            }
        }));
    }


    //adds the values selected to the list of topics 
    onSelect = (selectedOptions) => {

        this.setState(prevState => ({
            data: {
                ...prevState.data,
                topics: [...selectedOptions]
            }
        }));
        this.CalculateMaxMarks(selectedOptions);
    }

    //removes the values un-selected from the list of topics 
    onRemove = (selectedOptions, removedItem) => {
        this.setState(prevState => ({
            data: {
                ...prevState.data,
                topics: [...selectedOptions.filter(item => item !== removedItem)]
            }
        }));
        this.CalculateMaxMarks(selectedOptions);
    }

    // updates any change to the Certificate
    handleChange = (event) => {
        if (event.target.name == 'active') {
            this.setState(prevState => ({
                data: {
                    ...prevState.cert,
                    [event.target.name]: event.target.checked
                }
            }));
        } else {
            this.setState(prevState => ({
                data: {
                    ...prevState.cert,
                    [event.target.name]: event.target.value
                }
            }));

        }
    }
    

    handleSubmit = (event) => {
        event.preventDefault();

        //PUTs the updated data for the cert 
        axios.put(`https://localhost:7196/api/Certificates/${this.state.data.id}`, this.state.data)
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });


        //console.log("title = ", this.state.data.title ,
        //    "desc = ", this.state.data.description,
        //    "passmark = ", this.state.data.passingMark,
        //    "maxmark = ", this.state.data.maxMark,
        //    "cat = ", this.state.data.category,
        //    "active = ", this.state.data.active,
        //    "Topics = ", this.state.data.topics);
    }

    render() {
        return (
            <Form onSubmit={this.handleSubmit} >
                <Stack gap={3}>
                    <Row>
                        <Col md={10}>
                            <Form.Group >
                                <Form.Label>Title</Form.Label>
                                <Form.Control type="text" name="title" value={this.state.data.title} onChange={this.handleChange} />
                            </Form.Group>
                        </Col>
                        <Form.Group as={Col}>
                            <Form.Label>Passing Mark</Form.Label>
                            <Form.Control type="number" step="1" min="0"
                                name='passingMark'

                                max="100" value={this.state.data.passingMark} onChange={this.handleChange} />
                        </Form.Group>
                    </Row>
                    <Row>
                        <Col md={10}>
                            <Form.Group>
                                <Form.Label>Category</Form.Label>
                                <Form.Control type="text"
                                    name='category'
                                    value={this.state.data.category} onChange={this.handleChange} />
                            </Form.Group>

                        </Col>

                        <Form.Group as={Col}>
                            <Form.Label>Max Mark</Form.Label>
                            <Form.Control type="text" value={this.state.data.maxMark} disabled />
                        </Form.Group>
                    </Row>

                    <FloatingLabel label="Description" >
                        <Form.Control
                            as="textarea"
                            name='description'
                            style={{ height: '100px' }}
                            value={this.state.data.description} onChange={this.handleChange}
                        />
                    </FloatingLabel>
                    <Form.Group>
                        <Form.Label>Topics</Form.Label>
                        <Multiselect
                            name='topics'
                            options={this.state.allTopics} // Options to display in the dropdown
                            onSelect={this.onSelect} // Function will trigger on select event
                            onRemove={this.onRemove} // Function will trigger on remove event
                            selectedValues={this.state.data.topics}
                            displayValue="name" // Property name to display in the dropdown options
                            placeholder="Please select as many Topics as needed for the certificate"
                            hidePlaceholder="true"
                            showCheckbox="true"
                            closeIcon="cancel"
                            showArrow="true"
                            isMulti={true}
                            value={this.state.data.topics}
                            onChange={this.handleChange}
                        />
                    </Form.Group>
                    <Col xs="auto" className="my-1">
                        <Form.Check
                            type="checkbox"
                            // defaultChecked={this.state.complete}
                            name='active'
                            label="Is the certificate available for puchase?"
                            defaultChecked={this.state.data.active}
                            onChange={this.handleChange}
                        />
                    </Col>
                    <Button variant="primary" type="submit">
                        Save
                    </Button>
                </Stack>
            </Form >
        )
    }
}

export default withRouter(EditCertificateForm);

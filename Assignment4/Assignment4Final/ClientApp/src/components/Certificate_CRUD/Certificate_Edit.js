
import { Form, Button, Col, Row, FloatingLabel, Stack } from 'react-bootstrap';
import React, { Component } from 'react';

import Multiselect from 'multiselect-react-dropdown';

class EditCertificateForm extends Component {

    constructor(props) {
        super(props);
        this.state = {
            allTopics: [],
            cert: {
                Title: "",
                Description: "",
                PassingMark: 0,
                MaxMark: 0,
                Category: "",
                Active: false,
                Topics: [],
            }
            // this.handleChange = this.handleChange.bind(this);
        }
    }
    // using id whe can axios call for all the details we need,

    componentDidMount() {
        this.setState({
            cert: {
                "Id": 14,
                "Title": "this is a title for 14",
                "Description": "description of 14 ",
                "PassingMark": 65,
                "MaxMark": 600,
                "Category": "Coding2",
                "Active": false,
                "Topics": [
                    {
                        "Id": 1,
                        "MaxMarks": 200,
                        "Name": "Math",
                    },
                    {
                        "Id": 2,
                        "MaxMarks": 200,
                        "Name": "lol",
                    },
                    {
                        "Id": 3,
                        "MaxMarks": 200,
                        "Name": "smething"
                    }]
            }
        });
        this.setState({
            allTopics: [
                {
                    "Id": 1,
                    "MaxMarks": 100,
                    "Name": "Math",
                },
                {
                    "Id": 2,
                    "MaxMarks": 100,
                    "Name": "Science",
                },
                {
                    "Id": 3,
                    "MaxMarks": 100,
                    "Name": "History",
                },
                {
                    "Id": 4,
                    "MaxMarks": 100,
                    "Name": "English",
                }
            ]
        });
    }



    CalculateMaxMarks = (selectedOptions) => {
        let total = 0;
        selectedOptions.forEach(element => {
            total += element.MaxMarks;
        });

        this.setState(prevState => ({
            cert: {
                ...prevState.cert,
                MaxMark: total
            }
        }));
    }
    // fill the aboe with axios call

    getTopics = () => {
        // make axios call 
        //setTopics(...data);
    }


    //adds the values selectes to the list of topics 
    onSelect = (selectedOptions, selectedItem) => {

        this.setState(prevState => ({
            cert: {
                ...prevState.cert,
                Topics: [...selectedOptions]
            }
        }));
        this.CalculateMaxMarks(selectedOptions);
    }

    //removes the values un-selected from the list of topics 
    onRemove = (selectedOptions, removedItem) => {
        this.setState(prevState => ({
            cert: {
                ...prevState.cert,
                Topics: [...selectedOptions.filter(item => item !== removedItem)]
            }
        }));
        this.CalculateMaxMarks(selectedOptions);
    }
    handleChange = (event) => {
        if (event.target.name == 'Active') {
            this.setState(prevState => ({
                cert: {
                    ...prevState.cert,
                    [event.target.name]: event.target.checked
                }
            }));
        } else {
            this.setState(prevState => ({
                cert: {
                    ...prevState.cert,
                    [event.target.name]: event.target.value
                }
            }));

        }
    }
    handleSubmit = (event) => {
        event.preventDefault();
        // handle form submit logic here with an axios post method
        console.log("title = ", this.state.cert.Title,
            "desc = ", this.state.cert.Description,
            "passmark = ", this.state.cert.PassingMark,
            "maxmark = ", this.state.cert.MaxMark,
            "cat = ", this.state.cert.Category,
            "active = ", this.state.cert.Active,
            "Topics = ", this.state.cert.Topics);
    }

    render() {
        const { cert } = this.state;

        return (
            <Form onSubmit={this.handleSubmit} >
                <Stack gap={3}>
                    <Row>
                        <Col md={10}>
                            <Form.Group >
                                <Form.Label>Title</Form.Label>
                                <Form.Control type="text" name="Title" value={this.state.cert.Title} onChange={this.handleChange} />
                            </Form.Group>
                        </Col>
                        <Form.Group as={Col}>
                            <Form.Label>Passing Mark</Form.Label>
                            <Form.Control type="number" step="1" min="0"
                                name='PassingMark'

                                max="100" value={this.state.cert.PassingMark} onChange={this.handleChange} />
                        </Form.Group>
                    </Row>
                    <Row>
                        <Col md={10}>
                            <Form.Group>
                                <Form.Label>Category</Form.Label>
                                <Form.Control type="text"
                                    name='Category'
                                    value={this.state.cert.Category} onChange={this.handleChange} />
                            </Form.Group>

                        </Col>

                        <Form.Group as={Col}>
                            <Form.Label>Max Mark</Form.Label>
                            <Form.Control type="text" value={this.state.cert.MaxMark} disabled />
                        </Form.Group>
                    </Row>

                    <FloatingLabel label="Description" >
                        <Form.Control
                            as="textarea"
                            name='Description'
                            style={{ height: '100px' }}
                            value={this.state.cert.Description} onChange={this.handleChange}
                        />
                    </FloatingLabel>
                    <Form.Group>
                        <Form.Label>Topics</Form.Label>
                        <Multiselect
                            name='Topics'
                            options={this.state.allTopics} // Options to display in the dropdown
                            onSelect={this.onSelect} // Function will trigger on select event
                            onRemove={this.onRemove} // Function will trigger on remove event
                            displayValue="Name" // Property name to display in the dropdown options
                            placeholder="Please select as many Topics as needed for the certificate"
                            selectedValues={this.state.cert.Topics}
                            hidePlaceholder="true"
                            showCheckbox="true"
                            closeIcon="cancel"
                            showArrow="true"
                            isMulti={true}
                            value={this.state.cert.Topics}
                            onChange={this.handleChange}
                        />
                    </Form.Group>
                    <Col xs="auto" className="my-1">
                        <Form.Check
                            type="checkbox"
                            // defaultChecked={this.state.complete}
                            name='Active'
                            label="Is the certificate available for puchase?"
                            defaultChecked={this.state.cert.Active}
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

export default EditCertificateForm;

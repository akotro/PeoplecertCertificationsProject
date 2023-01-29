import { Form, Button, Col, Row, FloatingLabel, Stack } from 'react-bootstrap';
import React, { Component, useState } from 'react';

import Multiselect from 'multiselect-react-dropdown';


class CreateCertificateForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedTopics: [],
            Title: "",
            Description: "",
            PassingMark: 0,
            MaxMark: 0,
            Category: "",
            Active: false,
            Topics: [
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

        }
    }
    //const[selectedTopics, setselectedTopics] = useState([]);
    //const[Title, setTitle] = useState("");
    //const[description, setDescription] = useState("");
    //const[passingMark, setPassingMark] = useState("");
    //const[maxMark, setMaxMark] = useState(0);
    //const[category, setCategory] = useState("");
    //const[active, setActive] = useState(false);

    //const[topics, setTopics] = useState([
    //    {
    //        "Id": 1,
    //        "MaxMarks": 100,
    //        "Name": "Math",
    //    },
    //    {
    //        "Id": 2,
    //        "MaxMarks": 100,
    //        "Name": "Science",
    //    },
    //    {
    //        "Id": 3,
    //        "MaxMarks": 100,
    //        "Name": "History",
    //    },
    //    {
    //        "Id": 4,
    //        "MaxMarks": 100,
    //        "Name": "English",
    //    }
    //]);

    CalculateMaxMarks = (selectedTopics) => {
        let total = 0;
        selectedTopics.forEach((topic) => {
            total += topic.MaxMarks;
        });
        this.setState({ MaxMark: total });
    }

    getTopics = () => {
        // make axios call 
        //setTopics(...data);
    }



    //adds the values selectes to the list of topics 
    onSelect = (selectedTopics, selectedItem) => {
        //if (!selectedTopics.includes(selectedItem)) {

        this.setState(prevState => ({ selectedTopics: [...prevState.selectedTopics, selectedItem] }));
        this.CalculateMaxMarks(selectedTopics);
        //}
    }

    //removes the values un-selected from the list of topics 
    onRemove = (selectedTopics, removedItem) => {
        this.setState({ selectedTopics: selectedTopics.filter(item => item !== removedItem) });
        this.CalculateMaxMarks(selectedTopics);

    }

    handleChange = (event) => {

        if (event.target.name == 'Active'  ) {
            this.setState(prevState => ({
                ...prevState,
                [event.target.name]: event.target.checked

            }));
        } else {
            this.setState(prevState => ({
                ...prevState,
                [event.target.name]: event.target.value

            }));

        }
    }

    handleSubmit = (event) => {
        event.preventDefault();
        // handle form submit logic here with an axios post method
        console.log("Title = ", this.state.Title,
            "desc = ", this.state.Description,
            "passmark = ", this.state.passingMark,
            "maxmark = ", this.state.maxMark,
            "cat = ", this.state.category,
            "active = ", this.state.active,
            "selectedtopics = ", this.state.selectedTopics);

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
                                    name='Title'
                                    value={this.state.Title} onChange={this.handleChange} />
                            </Form.Group>

                        </Col>

                        <Form.Group as={Col}>
                            <Form.Label>Passing Mark</Form.Label>
                            <Form.Control type="number" step="1" min="0"
                                name='PassingMark'
                                max="100" value={this.state.PassingMark} onChange={this.handleChange} />
                        </Form.Group>
                    </Row>
                    <Row>
                        <Col md={10}>
                            <Form.Group>
                                <Form.Label>Category</Form.Label>
                                <Form.Control type="text"
                                    name='Category'
                                    value={this.state.Category} onChange={this.handleChange} />
                            </Form.Group>

                        </Col>

                        <Form.Group as={Col}>
                            <Form.Label>Max Mark</Form.Label>
                            <Form.Control type="text" value={this.state.MaxMark} disabled />
                        </Form.Group>
                    </Row>

                    <FloatingLabel label="Description" >
                        <Form.Control
                            as="textarea"
                            name='Description'
                            style={{ height: '100px' }}
                            value={this.state.Description} onChange={this.handleChange}
                        />
                    </FloatingLabel>
                    <Form.Group>
                        <Form.Label>Topics</Form.Label>
                        <Multiselect
                            name="Topics"
                            options={this.state.Topics} // Options to display in the dropdown
                            onSelect={this.onSelect} // Function will trigger on select event
                            onRemove={this.onRemove} // Function will trigger on remove event
                            displayValue="Name" // Property name to display in the dropdown options
                            placeholder="Please select as many Topics as needed for the certificate"
                            hidePlaceholder="true"
                            showCheckbox="true"
                            closeIcon="cancel"
                            showArrow="true"
                            isMulti={true}
                            value={this.state.selectedTopics}
                            onChange={this.handleChange}
                        />
                    </Form.Group>
                    <Col xs="auto" className="my-1">
                        <Form.Check
                        name='Active'
                            type="checkbox"
                            label="Is the certificate available for puchase?"
                            defaultChecked={this.state.Active}
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

import { Form, Button, Col, Row, FloatingLabel, Stack } from 'react-bootstrap';
import React, { useState } from 'react';

import Multiselect from 'multiselect-react-dropdown';


function CreateCertificateForm() {

    const [selectedTopics, setselectedTopics] = useState([]);
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [passingMark, setPassingMark] = useState("");
    const [maxMark, setMaxMark] = useState(0);
    const [category, setCategory] = useState("");
    const [active, setActive] = useState(false);

    const [topics, setTopics] = useState([
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
    ]);

    const CalculateMaxMarks = (selectedTopics) => {
        let total = 0;
        selectedTopics.forEach((topic) => {
            total += topic.MaxMarks;
        });
        setMaxMark(total);
    }

    const getTopics = () => {
        // make axios call 
        //setTopics(...data);
    }



    //adds the values selectes to the list of topics 
    const onSelect = (selectedTopics, selectedItem) => {
        setselectedTopics(selectedTopics => [...selectedTopics, selectedItem]);
        CalculateMaxMarks(selectedTopics);
    }

    //removes the values un-selected from the list of topics 
    const onRemove = (selectedTopics, removedItem) => {
        setselectedTopics(selectedTopics => selectedTopics.filter(item => item !== removedItem));
        CalculateMaxMarks(selectedTopics);
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        // handle form submit logic here with an axios post method

        console.log(title, "desc = " + description, passingMark, maxMark, category, active, selectedTopics);
    }

    return (
        <Form onSubmit={handleSubmit}>
            <Stack gap={3}>
                <Row >
                    <Col md={10}>
                        <Form.Group >
                            <Form.Label>Title</Form.Label>
                            <Form.Control type="text" value={title} onChange={(e) => setTitle(e.target.value)} />
                        </Form.Group>

                    </Col>

                    <Form.Group as={Col}>
                        <Form.Label>Passing Mark</Form.Label>
                        <Form.Control type="number" step="1" min="0"
                            max="100" value={passingMark} onChange={(e) => setPassingMark(e.target.value)} />
                    </Form.Group>
                </Row>
                <Row>
                    <Col md={10}>
                        <Form.Group>
                            <Form.Label>Category</Form.Label>
                            <Form.Control type="text" value={category} onChange={(e) => setCategory(e.target.value)} />
                        </Form.Group>

                    </Col>

                    <Form.Group as={Col}>
                        <Form.Label>Max Mark</Form.Label>
                        <Form.Control type="text" value={maxMark} disabled />
                    </Form.Group>
                </Row>

                <FloatingLabel label="Description" >
                    <Form.Control
                        as="textarea"
                        style={{ height: '100px' }}
                        value={description} onChange={(e) => setDescription(e.target.value)}
                    />
                </FloatingLabel>
                <Form.Group>
                    <Form.Label>Topics</Form.Label>
                    <Multiselect
                        options={topics} // Options to display in the dropdown
                        onSelect={onSelect} // Function will trigger on select event
                        onRemove={onRemove} // Function will trigger on remove event
                        displayValue="Name" // Property name to display in the dropdown options
                        placeholder="Please select as many Topics as needed for the certificate"
                        hidePlaceholder="true"
                        showCheckbox="true"
                        closeIcon="cancel"
                        showArrow="true"
                        isMulti={true}
                        value={topics}
                        onChange={(e) => setTopics(e.target.value)}
                    />
                </Form.Group>
                <Col xs="auto" className="my-1">
                    <Form.Check
                        type="checkbox"
                        label="Is the certificate available for puchase?"
                        checked={active}
                        onChange={(e) => setActive(e.target.checked)}
                    />
                </Col>
                <Button variant="primary" type="submit">
                    Create
                </Button>
            </Stack>
        </Form>
    )
}

export default CreateCertificateForm;

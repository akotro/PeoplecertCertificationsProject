import {
    Button,
    Col,
    Row,
    Stack,
    FormGroup,
    Dropdown,
    Container,
    Badge,
    FormCheck,
    radio,
    checkbox,
    Feedback,
} from "react-bootstrap";
import { Form } from "react-bootstrap";
// import Multiselect from "multiselect-react-dropdown";
import { React, useState, useEffect } from "react";
import { Link } from "react-router-dom";

import axios from "axios";

import MyEditor from "./Editor";
import Errors from '../Common/ErrorList'

function QuestionCreate() {
    const [error, setError] = useState(null);
    //------------------------------------------------Question state
    const [question, setQuestion] = useState({
        text: "string",
        topicId: 0,
        difficultyLevelId: 0,

        options: [],
    });
    //------------------------------------------------Topics state
    const [allTopics, setAllTopics] = useState([]);
    //------------------------------------------------Options state
    const [options, setOptions] = useState([
        {
            id: 0,
            text: "",
            correct: false,
        },
        {
            id: 1,
            text: "",
            correct: false,
        },
        {
            id: 2,
            text: "",
            correct: false,
        },
        {
            id: 3,
            text: "",
            correct: false,
        },
    ]);
    //------------------------------------------------Difficulty Levels state
    const [difficultyLevels, setLevels] = useState([]);
    //------------------------------------------------HANDLE CHANGE------------------------------------------------>>>>>>

    const handleChange = (event, name, data, optionId) => {
        //------------------------------------------------
        if (name === "QuestionText") {
            setQuestion((previousQuestion) => {
                return { ...previousQuestion, text: data };
            });
        }
        //------------------------------------------------
        else if (name === "Option0") {
            //--------------------->>>>>>
            setOptions(
                options.map((option) => {
                    if (option.id === 0) {
                        return { ...option, text: data };
                    }
                    return option;
                })
            );
        } else if (name === "Option1") {
            //--------------------->>>>>>
            setOptions(
                options.map((option) => {
                    if (option.id === 1) {
                        return { ...option, text: data };
                    }
                    return option;
                })
            );
        } else if (name === "Option2") {
            //--------------------->>>>>>
            setOptions(
                options.map((option) => {
                    if (option.id === 2) {
                        return { ...option, text: data };
                    }
                    return option;
                })
            );
        } else if (name === "Option3") {
            setOptions(
                options.map((option) => {
                    if (option.id === 3) {
                        return { ...option, text: data };
                    }
                    return option;
                })
            );
        }
        //------------------------------------------------
        else if (event.target.name === "checkbox0") {
            console.log("in checkbox0");
            console.log(event);

            setOptions(
                options.map((option) => {
                    if (option.id === 0) {
                        console.log("in");

                        return { ...option, correct: event.target.checked };
                        // console.log(event.target.checked);
                    }
                    return option;
                })
            );
        } else if (event.target.name === "checkbox1") {
            console.log("in checkbox1");

            setOptions(
                options.map((option) => {
                    if (option.id === 1) {
                        return { ...option, correct: event.target.checked };
                        // console.log(event.target.checked);
                        // console.log("in");
                    }
                    return option;
                })
            );
        } else if (event.target.name === "checkbox2") {
            console.log("in checkbox2");

            setOptions(
                options.map((option) => {
                    if (option.id === 2) {
                        return { ...option, correct: event.target.checked };
                        // console.log(event.target.checked);
                        // console.log("in");
                    }
                    return option;
                })
            );
        } else if (event.target.name === "checkbox3") {
            console.log("in checkbox3");

            setOptions(
                options.map((option) => {
                    if (option.id === 3) {
                        return { ...option, correct: event.target.checked };
                        // console.log(event.target.checked);
                        // console.log("in");
                    }
                    return option;
                })
            );
        }
        // console.log(options);
    };

    //------------------------------------------------HANDLE SUBMIT
    function handleSubmit(event) {
        event.preventDefault();
        console.log("On submit");

        const newOnSubmitQuestion = { ...question, options: [...options] };

        setQuestion(newOnSubmitQuestion);

        console.log(newOnSubmitQuestion);

        axios
            .post("https://localhost:7196/api/Questions", newOnSubmitQuestion)
            .then(function (response) {
                console.log("Inside response");
                console.log(response);
                setError([]);
            })
            .catch(function (error) {
                console.log("Inside error");
                console.log(error);
                setError(error);
            });
    }
    // const handleSubmit = (event) => {
    // };
    //------------------------------------------------ON SELECT (DROPDOWN)
    const onSelect = (selected, event) => {
        console.log("onSelect");
        console.log(selected);
        console.log(event.nativeEvent ?? "no event");
        let condition;
        var onSelectQuestion = {};
        // if(event.nativeEvent)
        // {
        //   event.persist();
        //    condition =   event.nativeEvent.srcElement.attributes[1].nodeValue ;
        // }
        // else
        // {
        //  condition = "topic";
        // }
        condition = event;
        if (condition == "topic") {
            console.log("is a topic");
            onSelectQuestion = { ...question, topicId: selected.id };
        } else if (condition === "level") {
            console.log("is not a level");
            onSelectQuestion = { ...question, difficultyLevelId: selected.id };
        }
        setQuestion(onSelectQuestion);
    };
    //------------------------------------------------//GET ALL TOPICS AND DIFFICULTY LEVELS
    useEffect(() => {
        console.log("componentDidMount in useEffect");
        axios
            .get(`https://localhost:7196/api/Topics`)
            .then((res) => {
                setAllTopics(res.data.data);
            })
            .catch((err) => {
                console.error(err.response.data);
            });

        axios
            .get(`https://localhost:7196/api/DifficultyLevels`)
            .then((res) => {
                setLevels(res.data.data);
                // console.log(res.data.data);
            })
            .catch((err) => {
                console.error(err.response.data);
            });
    }, []);
    //------------------------------------------------
    //------------------------------------------------ RETURN
    return (
        <Container>
            {error && <Errors error={error} />}
            <Stack gap={3}>
                <Row>
                    <Badge pill bg="primary">
                        <h4>Question's Topic</h4>
                    </Badge>
                </Row>
                <br />
            </Stack>
            <Stack gap={3}>
                {/* ||FORM------------------------------------------------->>>>>>> */}
                <Form noValidate validated={true} onSubmit={handleSubmit}>
                    <Form.Group>
                        <Row className="justify-content-center">
                            <Form.Select
                                as="select"
                                name="TopicSelect"
                                defaultValue={question.topicId} //1.triggers the controlled component error
                            // onChange={ handleChange  }    //2.stops the controlled component error
                            //3. the combination of 3 and 4 triggers again the error
                            //  required                                    //more study on This is required
                            >
                                <option value="" hidden>
                                    Please choose a topic{" "}
                                </option>
                                {allTopics.map((topic, index) => (
                                    <option
                                        key={index}
                                        onClick={() => {
                                            onSelect(topic, "topic");
                                        }} //4. this without 3. stops the error
                                        value={topic.id}
                                    >
                                        {topic.name}
                                    </option>
                                ))}
                            </Form.Select>
                        </Row>
                    </Form.Group>
                    <hr />
                    <Stack gap={5}>
                        {/*  DROPDOWN Difficulty levels */}
                        <Container className="">
                            <Row className="w-50 mb-3">
                                <Badge pill bg="primary">
                                    <h4>Question's Difficulty</h4>
                                </Badge>
                            </Row>
                            <Row className="w-50 mb-0">
                                <Form.Group>
                                    <Form.Select as="select"
                                        name="DifficultySelect"
                                        defaultValue={
                                            question.difficultyLevelId
                                        }                                                          //1.triggers the controlled component error
                                    // onChange={ handleChange  }    //2.stops the controlled component error
                                    //3. the combination of 3 and 4 triggers again the error
                                    //more study on This is required
                                    >
                                        <option value="" hidden>
                                            Please choose a level{" "}
                                        </option>
                                        {difficultyLevels.map(
                                            (level, index) => (
                                                <option
                                                    key={index}
                                                    onClick={() => {
                                                        onSelect(
                                                            level,
                                                            "level"
                                                        );
                                                    }} //4. this without 3. stops the error
                                                // value={}
                                                >
                                                    {level.difficulty}
                                                </option>
                                            )
                                        )}
                                    </Form.Select>
                                </Form.Group>
                            </Row>
                        </Container>

                        {/* <hr /> */}
                        <Row>
                            {/* Questions text */}
                            <Col md={10}>
                                <FormGroup required>
                                    <Form.Label><h4>Questions Text</h4></Form.Label>
                                    <MyEditor
                                        handleChange={handleChange}
                                        name={"QuestionText"}
                                    />
                                </FormGroup>
                            </Col>
                            {/* DROPDOWN TOPICS */}
                            {/* <Col md={3}>
            <Form.Group>
              <Form.Label></Form.Label>
              <Dropdown autoClose={"outside"} onSelect={onSelect} required>
                <Dropdown.Toggle variant="primary" id="dropdown-basic">
                  Question's Topic
                </Dropdown.Toggle>

                <Dropdown.Menu>
                  {allTopics.map((topic, index) => (
                    <Dropdown.Item
                      key={index}
                      value={topic.id}
                      eventKey={topic.id}
                      species={"topic"}
                    >
                      {topic.name}
                    </Dropdown.Item>
                  ))}
                </Dropdown.Menu>
              </Dropdown>
            </Form.Group>
          </Col>{" "} */}
                        </Row>

                        {/*   //OPTIONS// */}
                        <Row>
                            {/* 1st Option */}
                            <Col md={7}>
                                <FormGroup>
                                    <Form.Label><h5>First Option</h5></Form.Label>
                                    {/* Editor */}
                                    <MyEditor
                                        handleChange={handleChange}
                                        name={"Option0"}
                                    />
                                </FormGroup>
                            </Col>
                            <Col>
                                <Form.Check
                                    type={"checkbox"}
                                    id={"1stOptionCorrect"}
                                    label={"Is Correct"}
                                    onChange={(event, name) =>
                                        handleChange(event, name)
                                    }
                                    name="checkbox0"
                                />
                            </Col>
                        </Row>
                        <Row>
                            {/* 2nd Option */}
                            <Col md={7}>
                                <FormGroup>
                                    <Form.Label><h5>Second Option</h5></Form.Label>
                                    {/* Editor */}
                                    <MyEditor
                                        handleChange={handleChange}
                                        name={"Option1"}
                                    />
                                </FormGroup>
                            </Col>
                            <Col>
                                <Form.Check
                                    type={"checkbox"}
                                    id={"2ndOptionCorrect"}
                                    label={"Is Correct"}
                                    onChange={(event, name) =>
                                        handleChange(event, name)
                                    }
                                    name="checkbox1"
                                />
                            </Col>
                        </Row>
                        <Row>
                            {/* 3d Option */}
                            <Col md={7}>
                                <FormGroup>
                                    <Form.Label><h5>Third Option</h5></Form.Label>
                                    {/* Editor */}
                                    <MyEditor
                                        handleChange={handleChange}
                                        name={"Option2"}
                                    />
                                </FormGroup>
                            </Col>
                            <Col>
                                <Form.Check
                                    type={"checkbox"}
                                    id={"3dOptionCorrect"}
                                    label={"Is Correct"}
                                    onChange={(event, name) =>
                                        handleChange(event, name)
                                    }
                                    name="checkbox2"
                                />
                            </Col>
                        </Row>
                        <Row>
                            {/* 4th Option  (id=3)*/}
                            <Col md={7}>
                                <FormGroup>
                                    <Form.Label><h5>Fourth Option</h5></Form.Label>
                                    {/* Editor */}
                                    <MyEditor
                                        handleChange={handleChange}
                                        name={"Option3"}
                                    />
                                </FormGroup>
                            </Col>
                            <Col>
                                <Form.Check
                                    type={"checkbox"}
                                    id={"4thOptionCorrect"}
                                    label={"Is Correct"}
                                    onChange={(event, name) =>
                                        handleChange(event, name)
                                    }
                                    name="checkbox3"
                                />
                            </Col>
                        </Row>

                        <Row>
                            <Col md="auto">
                                <Button
                                    variant="primary"
                                    type="submit"
                                    value={"Submit"}
                                >
                                    Create Question
                                </Button>
                            </Col>
                        </Row>
                        <Row className="d-flex w-100">
                            <Badge pill >

                                <Link to={`/questions/`}>
                                    <Button variant="primary" className="w-100">Go Back</Button>
                                </Link>

                            </Badge>
                        </Row>
                    </Stack>
                </Form>
            </Stack>
        </Container>
    );
}
export default QuestionCreate;

import {Button,Col,Row,FloatingLabel,Stack,Table,FormGroup,Badge,Dropdown,FormCheck,radio,checkbox,Feedback} from "react-bootstrap";
import { Form } from "react-bootstrap";
import Multiselect from "multiselect-react-dropdown";
import { React, useState, useEffect } from "react";
import { Link } from "react-router-dom";

import axios from "axios";

// import { CKEditor } from "@ckeditor/ckeditor5-react";
// import EditorPlus from "ckeditor5-classic-plus";

import Editor from "./Editor";

function Create() {
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
      isCorrect: false,
    },
    {
      id: 1,
      text: "",
      isCorrect: false,
    },
    {
      id: 2,
      text: "",
      isCorrect: false,
    },
    {
      id: 3,
      text: "",
      isCorrect: false,
    },
  ]);
  //------------------------------------------------Difficulty Levels state
  const [difficultyLevels, setLevels] = useState([]);
  //------------------------------------------------HANDLE CHANGE
  const handleChange = (data, element) => {
    //------------------------------------------------
    if (element === "QuestionText") {
      setQuestion((previousQuestion) => {
        return { ...previousQuestion, text: data };
      });
    }
    //------------------------------------------------
    else if (element === "Option0") {
      //--------------------->>>>>>
      setOptions(
        options.map((option) => {
          if (option.id === 0) {
            return { ...option, text: data };
          }
          return option;
        })
      );
    } else if (element === "Option1") {
      //--------------------->>>>>>
      setOptions(
        options.map((option) => {
          if (option.id === 1) {
            return { ...option, text: data };
          }
          return option;
        })
      );
    } else if (element === "Option2") {
      //--------------------->>>>>>
      setOptions(
        options.map((option) => {
          if (option.id === 2) {
            return { ...option, text: data };
          }
          return option;
        })
      );
    } else if (element === "Option3") {
      //--------------------->>>>>>
      setOptions(
        options.map((option) => {
          if (option.id === 3) {
            return { ...option, text: data };
          }
          return option;
        })
      );
    }
  };
  //------------------------------------------------HANDLE SUBMIT
  function handleSubmit(event) {
    event.preventDefault();
    console.log("On submit");

    const newOnSubmitQuestion = { ...question, options: [...options] };

    setQuestion(newOnSubmitQuestion);

    // setQuestion((previousQuestion) => {
    //   return { ...previousQuestion, options: [...options] };
    // });

    console.log("1...2....3.....Boom");
    console.log(newOnSubmitQuestion);
    console.log("1...2....3.....Boom");

    axios
      .post("https://localhost:7196/api/Questions", newOnSubmitQuestion)
      .then(function (response) {
        console.log("Inside response");
        console.log(response);
      })
      .catch(function (error) {
        console.log("Inside error");
        console.log(error);
      });
  }
  // const handleSubmit = (event) => {
  // };
  //------------------------------------------------ON SELECT (DROPDOWN)
  const onSelect = (selected, event) => {
                    var onSelectQuestion = {};
                    event.persist();
                    // console.log(event.nativeEvent.srcElement.attributes[1].nodeValue);
                    const condition = event.nativeEvent.srcElement.attributes[1].nodeValue;

                  if (condition === "topic")
                   {
                    console.log("is a topic");
                        onSelectQuestion = { ...question, topicId: selected };
                  }
                  else if(condition === "level")
                  {
                    console.log("is not a level");
                  onSelectQuestion = { ...question, difficultyLevelId: selected };

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
        console.log(res.data.data);
      })
      .catch((err) => {
        console.error(err.response.data);
      });
  }, []);
  //------------------------------------------------
  //------------------------------------------------ RETURN
  return (
    <Form onSubmit={handleSubmit}>
      <Stack gap={5}>
        <Row>
          {" "}
          {/* Questions text */}
          <Col md={7}>
            <FormGroup>
              <Form.Label>Questions Text</Form.Label>
              <Editor handleChange={handleChange} element={"QuestionText"} />
            </FormGroup>
          </Col>{" "}
          {/* DROPDOWN TOPICS */}
          <Col md={3}>
            <Form.Group>
              <Form.Label></Form.Label>

                          <Dropdown autoClose={true} onSelect={onSelect}>
                            <Dropdown.Toggle variant="primary" id="dropdown-basic">
                              Question's Topic
                            </Dropdown.Toggle>

                            <Dropdown.Menu>
                              {allTopics.map((topic, index) => (
                                <Dropdown.Item  key={index} value={topic.id} eventKey={topic.id} species={"topic"} >
                                  {topic.name}
                                </Dropdown.Item>
                              ))}
                            </Dropdown.Menu>
                          </Dropdown>
            </Form.Group>
          </Col>{" "}
          {/*  DROPDOWN Difficulty levels */}
          <Col md={2}>
            <Form.Group>
              <Form.Label></Form.Label>
              <Dropdown autoClose={true} onSelect={onSelect}>
                <Dropdown.Toggle variant="primary" id="dropdown-basic">
                  Difficulty
                </Dropdown.Toggle>

                <Dropdown.Menu>
                  {difficultyLevels.map((level, index) => (
                    <Dropdown.Item
                      key={index}
                      value={level.id}
                      eventKey={level.id}
                      species={"level"}
                    >
                      {level.difficulty}
                    </Dropdown.Item>
                  ))}
                </Dropdown.Menu>
              </Dropdown>
            </Form.Group>
          </Col>
        </Row>

        <Row>
          {" "}
          {/* 1st Option */}
          <Col md={7}>
            <FormGroup>
              <Form.Label>First Option</Form.Label>
              {/* Editor */}
              <Editor handleChange={handleChange} element={"Option0"} />
            </FormGroup>
          </Col>
          <Col>

          <Form.Check 
            type={'checkbox'}
            id={2}
            label={"Is Correct"}
          /> 
            <Form.Group className="mb-3" id="formGridCheckbox">
        <Form.Check type="checkbox" label="Check me out" />
      </Form.Group>
          
          </Col>
        </Row>
        <Row>
          {" "}
          {/* 2nd Option */}
          <Col md={7}>
            <FormGroup>
              <Form.Label>Second Option</Form.Label>
              {/* Editor */}
              <Editor handleChange={handleChange} element={"Option1"} />
            </FormGroup>
          </Col>
        </Row>
        <Row>
          {" "}
          {/* 3d Option */}
          <Col md={7}>
            <FormGroup>
              <Form.Label>Third Option</Form.Label>
              {/* Editor */}
              <Editor handleChange={handleChange} element={"Option2"} />
            </FormGroup>
          </Col>
        </Row>
        <Row>
          {" "}
          {/* 4th Option */}
          <Col md={7}>
            <FormGroup>
              <Form.Label>Fourth Option</Form.Label>
              {/* Editor */}
              <Editor handleChange={handleChange} element={"Option3"} />
            </FormGroup>
          </Col>
        </Row>

        <Row>
          <Col md={30}>
            <Button variant="primary" type="submit" value={"Submit"}>
              Create Question
            </Button>
          </Col>
        </Row>
      </Stack>
    </Form>
  );
}

export default Create;

{
  /* <Multiselect
                name="topics"
                options={allTopics} // Options to display in the dropdown
                onSelect={onSelect} // Function will trigger on select event
                // onRemove={onRemove} // Function will trigger on remove event
                displayValue="name" // Property name to display in the dropdown options
                placeholder="Please select as many Topics as needed for the certificate"
                hidePlaceholder="true "
                showCheckbox="true"
                closeIcon="cancel"
                showArrow="true"
                isMulti={true}
                singleSelect={true} //Only one topic can be selected
                // defaultValue={this.state.question.topics}
                // onChange={handleChange}
              />

              {/* <Form.Select as="select" name="Topics"
                                                  value={question.topicId}
                                                  onChange={handleChange}>
                                                  {allTopics.map((topic, index) =>
                                                      <option key={index}
                                                          value={topic.id}
                                                      >{topic.name}</option>
                                                  )}
                                              </Form.Select> */
}

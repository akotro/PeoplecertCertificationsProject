import { Form, FormGroup,Dropdown,Button, Col, Row, FloatingLabel, Stack , Table, FormControl  } from 'react-bootstrap';

import {React,useState,useEffect,Component }from 'react';

import axios from 'axios';
import { useLocation } from 'react-router-dom';

import MyEditor from "./Editor";
//--------------------------------------------------QUESTION EDIT FUNCTION--------------------------------------------------
export default function QuestionEdit(event, name) 
{
    const [data, setData] = useState([]);
    //------------------------------------------------Question state
    const [question, setQuestion] = useState({
        text: "string",
        topicId: 0,
        difficultyLevelId: 0,

        options: [],
    });

    const [options, setOptions] = useState([{}, {}, {}, {}]);

    //------------------------------------------------Topics state
    const [allTopics, setAllTopics] = useState([]);
    //------------------------------------------------Difficulty levels state
    const [difficultyLevels, setLevels] = useState([]);

    const location = useLocation();
    const { questionIndex } = location.state;
    //Same outcome as above------------------------------------------------
    // const _params = useParams();
    // const params = _params.id;
    //--------------------------------------------------

    //------------------------------------------------//GET ALL TOPICS AND DIFFICULTY LEVELS
    const url = "https://localhost:7196/api/Questions/" + questionIndex;
    useEffect(() => {
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
        //------------------------------------------------//GET QUESTION BY ID
        axios.get(url).then((response) => {
            setQuestion(response.data.data);
            console.log(question);
            setOptions(response.data.data.options);
        });
    }, [url]);
    //------------------------------------------------//HANDLE SUBMIT
    const handleSubmit = (event) => {
        event.preventDefault();
        // console.log(question);
        const newQuestion = { ...question, options: options };
        console.log(newQuestion);
console.log(" Put!!!");
        // axios.put('https://localhost:7196/api/Questions/'+questionIndex,newQuestion)
        // .then((response) => { /*  setQuestion(response.data.data); */ console.log("response.data");
        // }).catch((err) => {
        //     console.error("err.response.data");
        // });
    };
    //------------------------------------------------HANDLE CHANGE------------------------------------------------>>>>>>------------------------------------   
    // event, name, data, optionId
    const handleChange = (event, name, data, questionOptionIndex) => {
        let newQuestion;
        let newOptions = [];
        const checkBoxKey = name;
        // console.log("In handleChange");
        //Condition which  assures that setQuestion is called only by the user's input------------------------->>>>>>
        if (question.text !== "string") 
        {
            if (name === "QuestionText") {
                console.log(data);
                newQuestion = { ...question, text: data };
                setQuestion(newQuestion);
            } else if (name === "OptionText") {
                newOptions = options.map((option, index) =>
                    index === questionOptionIndex
                        ? { ...option, text: data }
                        : option
                );
                setOptions(newOptions);
            } 
            else if (checkBoxKey === "checkbox" ) 
            {
                console.log("Trying to change the correct option");
                console.log(!data);
                setOptions(
                    options.map((option, index) =>
                        index === questionOptionIndex
                            ? { ...option, correct: !data }
                            : option
                    )
                );
                console.log(options);
            }
        }
    };
    //------------------------------------------------HANDLE SELECT------------------------------------------------>>>>>>
    const onSelect = (selectedList, selectedItem) => 
    {
            console.log(selectedItem.value);

        if (selectedItem.species === "topic") 
        {
            // setQuestion({ ...question, topicId: selectedItem.value });
        } 
        // else if (selectedItem.species === "difficultyLevel") 
        // {
        //     setQuestion({
        //         ...question,
        //         difficultyLevelId: selectedItem.value,
        //     });
        // }
        // console.log(question);
    };
    //------------------------------------------------//----------------------->>>>>>>

    return (
        //---||FORM------------------------------------------------->>>>>>>
        <Form noValidate validated={true} onSubmit={handleSubmit}>
            <Stack gap={5}>
                <Row key={"questionEditorAndDropdowns"}>
                    {/*-------------Questions text */}
                    <Col md={7}>
                        <FormGroup required>
                            <Form.Label>Questions Text</Form.Label>

                            <MyEditor
                                key={"questionEditor"}
                                handleChange={handleChange}
                                name={"QuestionText"}
                                text={question.text}
                            />
                        </FormGroup>
                    </Col>
                    {/* DROPDOWN TOPICS */}
                    <Col md={3}>
                        <Form.Group>
                            <Form.Label></Form.Label>

                            <Dropdown autoClose={"outside"} onSelect={onSelect} required
                            >
                                <Dropdown.Toggle
                                    variant="primary"
                                    id="dropdown-basic"
                                >
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
                    </Col>{" "}
                    {/*  DROPDOWN Difficulty levels */}
                    <Col md={2}>
                        <Form.Group>
                            <Form.Label></Form.Label>
                            <Dropdown autoClose={"outside"} onSelect={onSelect}>
                                <Dropdown.Toggle
                                    variant="primary"
                                    id="dropdown-basic"
                                >
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
                {/*   Question OPTIONS */}

                {options.map((option, index) => (
                    <Row key={"unique" + index}>
                        <Col md={7}>
                            <Form.Group>
                                <Form.Label>Option {index}</Form.Label>

                                <MyEditor
                                    key="index"
                                    handleChange={handleChange}
                                    name={"OptionText"}
                                    text={option.text}
                                    index={index}
                                />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Check
                                type={"checkbox"}
                                // id={index}
                                // label={"Is Correct"}
                                // onChange={handleChange}
                                //    onClick={(event) => handleChange(event)}
                                // name={"checkbox "}
                            >
                                <Form.Check.Label><strong>Is Correct</strong></Form.Check.Label>
                                <Form.Check.Input type={'checkbox'} 
                                isValid  checked={option.correct} onChange={() => {handleChange(event, "checkbox",option.correct,index)}}
                                 name='checkbox' id={index.toString()}
                                 /> 


                        </Form.Check>
                {/* <Form.Check type={'checkbox'} id={"0"+index}>

                            <Form.Check.Input type={'checkbox'} isValid />


                            {/* <Form.Control.Feedback type="invalid">
                            Succesfully added
                            </Form.Control.Feedback> 

                        </Form.Check> */}














                        </Col>
                    </Row>
                ))}

                {/* <Row key={"unique0"}>
                        <Col md={7}>
                          <Form.Group>
                            <Form.Label>Option 0</Form.Label>
                        
                        <MyEditor handleChange={handleChange} name={"OptionText0"} text={'option.text'} />

                          </Form.Group>
                        </Col>
                        <Col>
                              <Form.Check type={'checkbox'} id={1} label={"Is Correct"} 
                              onChange={(event,index) => handleChange(event,index)} name={"checkbox0"} checked={true}/> 
                              </Col>
                </Row> */}

                <Row key={"CreateButtonRow"}>
                    {/* <Col md={30}> */}
                    <Button variant="primary" type="submit" value={"Submit"}>
                        Create Question
                    </Button>
                    {/* </Col> */}
                </Row>
            </Stack>
        </Form>
    );
}
        


import { Form, FormGroup,Button, Col, Row, Badge, Stack   } from 'react-bootstrap';
import { Link } from "react-router-dom";
import {React,useState,useEffect }from 'react';

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
    const [allTopics, setAllTopics] = useState([
        { id: 0, name: "string", questions: [] },
    ]);
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
              
            })
            .catch((err) => {
                console.error(err.response.data);
            });
        //------------------------------------------------//GET QUESTION BY ID
        axios.get(url).then((response) => {
            setQuestion(response.data.data);
            setOptions(response.data.data.options);
        });
    }, [url]);//------------------------------------------------//GET QUESTION BY ID
    //------------------------------------------------//HANDLE SUBMIT
    const handleSubmit = (event) => {
        event.preventDefault();
        // console.log(question);
        const newQuestion = { ...question, options: options };
        console.log(newQuestion);
        setQuestion(newQuestion);
console.log(" Put!!!");

        axios.put('https://localhost:7196/api/Questions/'+questionIndex,newQuestion)
        .then((response) => {   console.log("Done!!!");
        }).catch((err) => {
            console.error(err);
            console.error(err.response);
            console.error(err.response.data);
            console.error(err.response.data.message);
        });
    };
    //------------------------------------------------HANDLE CHANGE------------------------------------------------>>>>>>------------------------------------   
    // event, name, data, optionId
    const handleChange = (event, name, data, questionOptionIndex) => {
        let newQuestion;
        let newOptions = [];
        const checkBoxKey = name;
        console.log("In handleChange");
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
            else if (name === "TopicSelect") 
            {
                console.log("Trying to change the topic");
                console.log(event);
                console.log(name);
                console.log(data);
                // console.log(data);
                // setQuestion({ ...question, topicId: data });
            }
        }
    };
    //------------------------------------------------HANDLE SELECT------------------------------------------------>>>>>>
    const onSelect = (event, selectedItem,species) => 
    {
        console.log(question.difficultyLevelId);
        console.log("IN SELECT");
        if (species === "topic") 
        {
           const  newQuestion = { ...question, topicId: selectedItem.id,topic:selectedItem };
            setQuestion(newQuestion);
        } 
        else if ( species === "difficultyLevel") 
        {
     
            const newQuestion = { ...question, difficultyLevelId: selectedItem.id,difficultyLevel:selectedItem };
        
            setQuestion(newQuestion);
        }
    };
    //------------------------------------------------//----------------------->>>>>>>

    return (
        //---||FORM------------------------------------------------->>>>>>>
        <Form noValidate validated={true} onSubmit={handleSubmit}>
            {/* DROPDOWN TOPICS */}
                <Form.Group className='mb-2'>
                                <h2>
                                    <Badge pill className='w-100' bg="primary">Question's Topic</Badge>
                                </h2>

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
                                                onSelect(event, topic, "topic");
                                            }} //4. this without 3. stops the error
                                            value={topic.id}
                                        >
                                            {topic.name}
                                        </option>
                                    ))}
                                </Form.Select>
                </Form.Group>
                        {/* <hr /> */}
                        <Form.Group>
                            <Form.Group>
                            <h2><Badge  pill className='w-50' bg="primary">Question's Difficulty</Badge></h2>
                            <Form.Select
                            className='w-50'
                                as="select"
                                name="DifficultySelect"
                                value={question.difficultyLevelId} //1.triggers the controlled component error
                                // onChange={ handleChange  }    //2.stops the controlled component error
                                //3. the combination of 3 and 4 triggers again the error
                                //  required                                    //more study on This is required
                            >
                                <option value={0} hidden>
                                    Please choose a level{" "}
                                </option>
                                {difficultyLevels.map((difficultyLevel, index) => (
                                    <option
                                        key={index}
                                        onClick={() => {
                                            onSelect(event, difficultyLevel, "difficultyLevel");
                                        }} //4. this without 3. stops the error
                                        value={difficultyLevel.id}
                                    >
                                        {difficultyLevel.difficulty}
                                    </option>
                                ))}
                            </Form.Select>
                        </Form.Group>







                        </Form.Group>
                        <hr />

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
                    
                    <Col md={3}>
                    </Col> 
                    {/*  DROPDOWN Difficulty levels */}
                    <Col md={2}>
                        {/* <Form.Group>
                            <Form.Group>
                            <h2><Badge bg="primary">Question's Difficulty</Badge></h2>
                            <Form.Select
                                as="select"
                                name="DifficultySelect"
                                value={question.difficultyLevelId} //1.triggers the controlled component error
                                // onChange={ handleChange  }    //2.stops the controlled component error
                                //3. the combination of 3 and 4 triggers again the error
                                //  required                                    //more study on This is required
                            >
                                <option value={0} hidden>
                                    Please choose a level{" "}
                                </option>
                                {difficultyLevels.map((difficultyLevel, index) => (
                                    <option
                                        key={index}
                                        onClick={() => {
                                            onSelect(event, difficultyLevel, "difficultyLevel");
                                        }} //4. this without 3. stops the error
                                        value={difficultyLevel.id}
                                    >
                                        {difficultyLevel.difficulty}
                                    </option>
                                ))}
                            </Form.Select>
                        </Form.Group>







                        </Form.Group> */}
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
                                <Form.Check.Label>
                                    <strong>Is Correct</strong>
                                </Form.Check.Label>
                                <Form.Check.Input
                                    type={"checkbox"}
                                    isValid
                                    checked={option.correct}
                                    onChange={() => {
                                        handleChange(
                                            event,
                                            "checkbox",
                                            option.correct,
                                            index
                                        );
                                    }}
                                    name="checkbox"
                                    id={index.toString()}
                                />
                            </Form.Check>
                        </Col>
                    </Row>
                ))}
                <Row key={"EditButtonRow"}>
                     <div className='w-40 mb-3 '>
                        <Button variant="primary" type="submit" value={"Submit"} >
                            Update Question
                        </Button>
                     </div>
                    <Badge pill bg='primary'>
                            <Link to={`/questions/`}>
                                <Button  variant="primary" className="w-100">Go Back</Button>
                            </Link>
                    </Badge>
                     
                </Row>
            </Stack>
        </Form>
    );
}
        


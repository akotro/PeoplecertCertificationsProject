import React, { useEffect, useState, useContext } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link, useParams, useLocation } from "react-router-dom";
import { AuthenticationContext } from '../auth/AuthenticationContext'

import { ListGroup, ListGroupItem, Button, Table, Row, Col, Stack, Form, CloseButton, FormGroup, InputGroup } from 'react-bootstrap';


import axios from 'axios';


function AddQuestionToExam() {
    const params = useParams();
    const location = useLocation();
    let navigate = useNavigate();
    const [topics, setTopics] = useState([])
    const [questions, setQuestions] = useState([])
    const [exam, setExam] = useState({
        questions: []
    })



    useEffect(() => {

        axios.get(`https://localhost:7196/api/Exam/${params.id}`).then((response) => {
            console.log("useeffect", response)
            setExam(response.data.data)
            setTopics(response.data.data.certificate.topics)
            console.log(response.data.data)
            console.log(response.data.data.certificate.topics)
            response.data.data.certificate.topics.map((question, index) => console.log('kati', question))
        })
    }, []);

    const assign = () => {
        setTopics(exam.certificate.topics)
        setQuestions(exam.certificate.topics)
    }
    function Replace(temp) {
        var parser = new DOMParser();
        var doc = parser.parseFromString(temp, 'text/html');
        return doc.body.innerText;
    }

    const handleAdd = (quest) => {

        var examUpdated = exam;
        var asd = exam.questions
        asd.push(quest)
        setExam({ ...exam, questions: asd })
        axios.put(`https://localhost:7196/api/Exam/${exam.id}`, exam).then()
            .catch(function (error) {
            });
    }

    const handleChangePassmark = (event) => {
        console.log('EXAAAAMMM', exam)
        console.log(event.target.value)
        setExam({ ...exam, passMark: Number(event.target.value) })
        console.log('examafterrr', exam)
    }

    const handleBack = async () => {
        console.log("before back", exam)
        await axios.put(`https://localhost:7196/api/Exam/${exam.id}`, exam).then(navigate(`/ExamQuestionList/${exam.id}`))
            .catch(function (error) {
            });

        // navigate(`/ExamQuestionList/${exam.id}`)



    }




    const makeButtons = (quest) => {
        return (
            <div>
                <Button onClick={() => handleAdd(quest)}>Add Question</Button>
            </div>
        )
    }

    return (
        <div>

            <div>
                <Row>
                    <Col>
                        <span class="p-3 mb-2 bg-info text-white">Total Questions In Exam: {exam.questions.length}&nbsp;</span>
                    </Col>
                    <Col>
                        <span class="p-3 mb-2 bg-white text-success" > #EASY: {exam.questions
                            .filter(quest => quest.difficultyLevel.difficulty !== "HARD")
                            .filter(quest => quest.difficultyLevel.difficulty !== "MEDIUM").length} </span>
                    </Col>

                    <Col>
                        <span class="p-3 mb-2 bg-white class=text-secondary">#MEDIUM:{exam.questions
                            .filter(quest => quest.difficultyLevel.difficulty !== "EASY")
                            .filter(quest => quest.difficultyLevel.difficulty !== "HARD").length}</span>
                    </Col>

                    <Col>
                        <span class="p-3 mb-2 bg-white  text-danger"> #HARD:{exam.questions
                            .filter(quest => quest.difficultyLevel.difficulty !== "EASY")
                            .filter(quest => quest.difficultyLevel.difficulty !== "MEDIUM").length} </span>
                    </Col>
                    <Col>
                        {exam != null && (
                            <InputGroup>
                                <InputGroup.Text>Set Passing Mark</InputGroup.Text>
                                <Form.Control
                                    placeholder="Set Passing Mark"
                                    type="number"
                                    value={exam.passMark}
                                    
                                    onChange={handleChangePassmark}
                                />

                            </InputGroup>
                        )}
                    </Col>
                </Row>
            </div>








            {topics.map((topic, index) =>

                <div key={index}>
                    <hr />
                    {console.log(topic)}
                    <div><h5>Topic Name: {topic.name}</h5></div>
                    {topic.questions.map((question, number) => exam.questions.findIndex(q => q.id === question.id) > -1 ? null : <div key={number}>
                        <div> Question: {Replace(question.text)}</div>
                        <div>Difficulty: {question.difficultyLevel.difficulty}</div>
                        <div>{makeButtons(question)}</div>
                    </div>

                    )}
                </div>
            )}
            <Button variant='dark' onClick={handleBack}>Go back</Button>

        </div>
    )
}
export default AddQuestionToExam

import React, { useEffect, useState, useContext } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link, useParams } from "react-router-dom";
import { AuthenticationContext } from '../auth/AuthenticationContext'

import { ListGroup, ListGroupItem, Button, Table, Row, Col, Stack, Form, CloseButton, FormGroup, InputGroup } from 'react-bootstrap';

import axios from 'axios';
import { useLocation } from 'react-router-dom'

function ExamQuestionList() {

    const params = useParams();
    const location = useLocation();
    let navigate = useNavigate();
    // const Data = location.state.data;

    const [questions, setQuestions] = useState([]);
    const [exam, setExam] = useState();
    const [mark, setMark] = useState(0)
    const { update, claims } = useContext(AuthenticationContext);
    const role = claims.find(claim => claim.name === 'role').value


    const [previousLocation, setPreviousLocation] = useState(location);

    useEffect(() => {
        axios.get(`https://localhost:7196/api/Exam/${params.id}`).then((response) => {
            console.log('useeffect resp', response)
            setExam(response.data.data)
            setQuestions(response.data.data.questions)
        })
            .catch(function (error) {
                console.log(error);
            });
    }, []);


    const handleAdd = (exam) => {
        axios.put(`https://localhost:7196/api/Exam/${exam.id}`, exam).then(setExam(exam))
        navigate(`/AddQuestionToExam/${exam.id}`)
    }

    const handleRemove = (questR) => {
        const confirmDelete = window.confirm("Are you sure you want to delete this question?");
        exam.questions = exam.questions.filter(q => q.id !== questR.id)
        if (confirmDelete) {
            axios.put(`https://localhost:7196/api/Exam/${exam.id}`, exam).then(setExam(exam))
            setQuestions(exam.questions)

        }
        console.log(questions)
        var kati = exam.questions;
    }

    const makeButtons = (exam, question) => {

        return (

            <div>
                <Button onClick={() => handleRemove(question)} variant="danger">Remove</Button>

            </div>
        )
    }



    function Replace(temp) {
        var parser = new DOMParser();

        var doc = parser.parseFromString(temp, 'text/html');

        return doc.body.innerText;

    }
    const handleChangePassmark = (event) => {
        console.log('EXAAAAMMM', exam)
        console.log(event.target.value)
        setMark(event.target.value)
        setExam({ ...exam, passMark: Number(event.target.value) })
        console.log('examafterrr', exam)
    }

    const handleBack = () => {
        console.log("before back", exam)
        axios.put(`https://localhost:7196/api/Exam/${exam.id}`, exam).then(navigate(-1))
            .catch(function (error) {
            });
    }

    return (
        <div>


            <fieldset disabled={role ? (role === "qualitycontrol") : false}>
                <div>
                    {/* <p hidden>{console.log('exam', exam)}</p> */}
                    <Button onClick={() => handleAdd(exam)}>Add Question</Button>
                    <div>
                        <Row>
                            <Col>
                            </Col>
                            <Col>
                                <span class="p-3 mb-2 bg-info text-white">questions in exam: {questions.length}</span>
                            </Col>
                            <Col>
                                <span class="p-3 mb-2 bg-white text-success">Num. Of EASY: {questions.filter(quest => quest.difficultyLevel.difficulty !== "HARD")
                                    .filter(quest => quest.difficultyLevel.difficulty !== "MEDIUM").length} </span>
                            </Col>
                            <Col>
                                <span class="p-3 mb-2 bg-white  class=text-secondary">Num. Of MEDIUM:{questions.filter(quest => quest.difficultyLevel.difficulty !== "EASY")
                                    .filter(quest => quest.difficultyLevel.difficulty !== "HARD").length}</span>
                            </Col>
                            <Col>
                                <span class="p-3 mb-2 bg-white  text-danger">Num. Of HARD:{questions.filter(quest => quest.difficultyLevel.difficulty !== "EASY")
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
                </div>

                <tbody>
                    {questions.map((quest, index) =>
                        <tr key={index}>

                            <td>{Replace(quest.text)}</td>
                            <td>{quest.difficultyLevel.difficulty}</td>
                            <td>{makeButtons(exam, quest)}</td>
                        </tr>
                    )}
                </tbody>
            </fieldset>
            <Button variant='dark' onClick={handleBack}>Go back</Button>

        </div>
    )
}
export default ExamQuestionList;
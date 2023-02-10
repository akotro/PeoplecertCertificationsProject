import React, { useEffect, useState, useContext } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link, useParams } from "react-router-dom";
import { AuthenticationContext } from '../auth/AuthenticationContext'

import { ListGroup, ListGroupItem, Button, Table, Row, Stack, Form } from 'react-bootstrap';

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
        console.log(exam)
        exam.questions = exam.questions.filter(q => q.id !== questR.id)
        axios.put(`https://localhost:7196/api/Exam/${exam.id}`, exam).then(setExam(exam))
        console.log(questions)
        setQuestions(exam.questions)
        console.log(questions)
        var kati = exam.questions;
    }

    const makeButtons = (exam, question) => {

        return (
            
            <div>
                <Button onClick={() => handleRemove(question)}>Remove</Button>

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



    return (
        <div>
            
                    <Button variant='dark' onClick={() => navigate(-1)}>Go back</Button>
            <fieldset disabled={role ? (role === "qualitycontrol") : false}>
                <p hidden>{console.log('exam', exam)}</p>
                <Table>
                <Button onClick={() => handleAdd(exam)}>Add Question</Button>
                    

                    <span>questions in exam: {questions.length}</span>
                    <span>Num. Of EASY: {questions.filter(quest => quest.difficultyLevel.difficulty !== "HARD")
                        .filter(quest => quest.difficultyLevel.difficulty !== "MEDIUM").length} </span>
                    <span>Num. Of HARD:{questions.filter(quest => quest.difficultyLevel.difficulty !== "EASY")
                        .filter(quest => quest.difficultyLevel.difficulty !== "MEDIUM").length} </span>
                    <span>Num. Of MEDIUM:{questions.filter(quest => quest.difficultyLevel.difficulty !== "EASY")
                        .filter(quest => quest.difficultyLevel.difficulty !== "HARD").length}</span>
                    {exam != null && (

                        <input
                            type="number"
                            value={exam.passMark}
                            placeholder="Enter a number..."
                            onChange={handleChangePassmark}
                        />)}

                    <thead>
                        <tr>
                            <th>Number</th>
                        </tr>
                    </thead>
                    <tbody>
                        {questions.map((quest, index) =>

                            <tr key={index}>
                                <td>{Replace(quest.text)}</td>
                                <td>{quest.difficultyLevel.difficulty}</td>
                                <td>{makeButtons(exam, quest)}</td>
                            </tr>

                        )}
                    </tbody>
                </Table>



            </fieldset>

        </div>
    )
}
export default ExamQuestionList;
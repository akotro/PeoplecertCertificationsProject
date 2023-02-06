import React, { useEffect, useState, useContext } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link } from "react-router-dom";
import { AuthenticationContext } from '../auth/AuthenticationContext'

import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';

import axios from 'axios';
import { useLocation } from 'react-router-dom'


function AddQuestionToExam() {
    const location = useLocation();
    let navigate = useNavigate();
    const Data = location.state.data;
    const [topics, setTopics] = useState([])
    const [questions, setQuestions] = useState([])
    const [exam, setExam] = useState([])

    useEffect(() => {
        setTopics(Data.certificate.topics)
        setQuestions(Data.certificate.topics.questions)
        setExam(Data)
    }
    )

    function Replace(temp) {
        var parser = new DOMParser();
        var doc = parser.parseFromString(temp, 'text/html');
        return doc.body.innerText;
    }

    const handleAdd = (quest) =>{
        var examQuestions = [...exam.questions,quest]
        var examUpdated = exam;
        examUpdated.questions = examQuestions
        console.log(questions)
        var questUpdated = questions.filter(q => q.id !== quest.id)
        console.log(questUpdated)
        setExam(examUpdated)
        
        console.log(examUpdated)
        // axios.put(`https://localhost:7196/api/Exam/${examR.id}`,examUpdated)
        // setExam(examUpdated)

    }

    const makeButtons = (quest) => {
        console.log(topics)
        console.log(questions)
        return(
            <div>
                <Button onClick={() => handleAdd(quest) }></Button>
            </div>
        )
    }



    return (
        <div>
            {topics.map((topic, index) =>

                <div key={index}>
                    <hr />
                    <div><h5>Topic Name: {topic.name}</h5></div>
                    {topic.questions.map((question, number) => true? <div key={number}>
                            <div> Question: { Replace(question.text)}</div>
                            <div>Difficulty: {question.difficultyLevel.difficulty}</div>
                            <div>{makeButtons(question)}</div>
                        </div> : null
                       
                    )}
                </div>
            )}


        </div>
    )


}
export default AddQuestionToExam
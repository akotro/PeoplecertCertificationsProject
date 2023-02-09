import React, { useEffect, useState, useContext } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link, useParams } from "react-router-dom";
import { AuthenticationContext } from '../auth/AuthenticationContext'

import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';

import axios from 'axios';
import { useLocation } from 'react-router-dom'


function AddQuestionToExam() {
    const params = useParams();
    const location = useLocation();
    let navigate = useNavigate();
    // const Data = location.state.data;
    const [topics, setTopics] = useState([])
    const [questions, setQuestions] = useState([])
    const [exam, setExam] = useState({
        questions:[]
    })
    

    
    useEffect(() => {

        axios.get(`https://localhost:7196/api/Exam/${params.id}`).then((response) => {
            console.log(response.data.data)
            console.log(response.data.data.questions)
            setExam(response.data.data)
            setQuestions(response.data.data.questions)
            setTopics(exam.certificate.topics)
            setQuestions(exam.certificate.topics.questions)
          })
    },[]);

    function Replace(temp) {
        var parser = new DOMParser();
        var doc = parser.parseFromString(temp, 'text/html');
        return doc.body.innerText;
    }

    const handleAdd = (quest) =>{
        
        var examUpdated = exam;
        console.log('before',exam)
        // exam.questions.push(quest)
        var asd = exam.questions
        asd.push(quest)
        setExam({...exam,questions : asd})

        

        // setExam({...exam,questions : [...exam.questions,quest]})
        // setExam((prev) =>  [...prev, questions : exam.questions])
        console.log(exam)
        axios.put(`https://localhost:7196/api/Exam/${exam.id}`,exam).then()
        .catch(function (error) {
        //     console.log(error);
        });
        
        
        
        // axios.put(`https://localhost:7196/api/Exam/${examR.id}`,examUpdated)

    }

    const makeButtons = (quest) => {
        return(
            <div>
                <Button onClick={() => handleAdd(quest) }>Add Question</Button>
            </div>
        )
    }



    return (
        <div>
            
            {topics.map((topic, index) =>

                <div key={index}>
                    <hr />
                    <div><h5>Topic Name: {topic.name}</h5></div>
                    {topic.questions.map((question, number) =>  exam.questions.findIndex(q => q.id === question.id) > -1? null: <div key={number}>
                            <div> Question: { Replace(question.text)}</div>
                            <div>Difficulty: {question.difficultyLevel.difficulty}</div>
                            <div>{makeButtons(question)}</div>
                        </div>
                       
                    )}
                </div>
            )}


        </div>
    )


}
export default AddQuestionToExam
// exam.questions.filter(q => q.id !== question.id) !== exam.questions ?   null :

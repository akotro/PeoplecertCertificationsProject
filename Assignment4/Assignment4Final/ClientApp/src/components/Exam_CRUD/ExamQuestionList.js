import React, { useEffect, useState, useContext } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link, useParams } from "react-router-dom";
import { AuthenticationContext } from '../auth/AuthenticationContext'

import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';

import axios from 'axios';
import { useLocation } from 'react-router-dom'

function ExamQuestionList() {

    const params = useParams();
    const location = useLocation();
    let navigate = useNavigate();
    // const Data = location.state.data;
    
    const [questions, setQuestions] = useState([]);
    const [exam, setExam] = useState();

    const [previousLocation, setPreviousLocation] = useState(location);

    useEffect(() => {
        axios.get(`https://localhost:7196/api/Exam/${params.id}`).then((response) => {
            console.log(response.data.data)
            console.log(response.data.data.questions)
            setExam(response.data.data)
            console.log(exam)
            setQuestions(response.data.data.questions)
          })
          .catch(function (error) {
            console.log(error);
          });
    },[]);

    
    const handleAdd =(exam) => {
        navigate(`/AddQuestionToExam/${exam.id}`)
    }

    const handleRemove = (questR) =>{
        console.log(exam)
        exam.questions= exam.questions.filter( q => q.id !== questR.id )
         axios.put(`https://localhost:7196/api/Exam/${exam.id}`,exam).then(setExam(exam))
         console.log(questions)
         setQuestions(exam.questions)
         console.log(questions)
         var kati =exam.questions;
    }

    const makeButtons = (exam,question) =>{
        return(
            <div>
                <Button onClick= { () => handleRemove(question)}>Remove</Button>
                
            </div>
        )
    }



    function Replace(temp) {
        var parser = new DOMParser();

        var doc = parser.parseFromString(temp, 'text/html');

        return doc.body.innerText;

    }



    return (
    <div>
        <Table>
            <Button onClick = { () =>handleAdd(exam) }>Add Question</Button>
            <p>Number Of Questions : {questions.length}</p>
            <thead>
                <tr>
                    <th>Number</th>
                    <th>text</th>
                </tr>
            </thead>
            <tbody>
                {questions.map((quest,index) =>
                    
                    <tr key={index}>
                        <td>{Replace(quest.text)}</td>
                        <td>{makeButtons(exam,quest)}</td>
                    </tr>
                   
                )}
            </tbody>
        </Table>
    </div>
    )
}
export default ExamQuestionList;
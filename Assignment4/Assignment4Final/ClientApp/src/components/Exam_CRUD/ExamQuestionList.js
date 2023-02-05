import React, { useEffect, useState } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link } from "react-router-dom";
import { useLocation } from 'react-router-dom'
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';

import axios from 'axios';






function ExamQuestionList() {


    const location = useLocation()
    const Exam = location.state.data;
    const questions = Exam.questions;
    const [data, setData] = useState([Exam.questions])

    console.log(Exam);
    console.log('its here')
    console.log(questions);
    function Replace(temp) {
        var parser = new DOMParser();

        var doc = parser.parseFromString(temp, 'text/html');

        return doc.body.innerText;

    }

    return (
        <div>
            <Table>
                <thead>
                    <tr>
                        <th>Text</th>
                        <th>Topic</th>
                        <th>DifficultyLevel</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map((question, index) => {
                        <div key ={index}>
                            { question.map((koukou, index) => {
                            <tr key={index}>
                                <td>{koukou.text}</td>
                               <td>{index}</td>
                                <td>{koukou.topic.id}</td>
                            </tr>

                        })
                        }

                        </div>
                       
                    })}




                </tbody>
            </Table>
        </div>

    )



}
export default ExamQuestionList;
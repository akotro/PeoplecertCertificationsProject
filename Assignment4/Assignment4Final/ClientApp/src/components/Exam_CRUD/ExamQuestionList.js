import React, { useEffect, useState } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link } from "react-router-dom";
import { useLocation } from 'react-router-dom'
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';

import axios from 'axios';






function ExamQuestionList(){


    const location = useLocation()
    const Exam = location.state.data;
    const Questions = Exam.Quenstions;
    function Replace(temp)
    {
      var parser = new DOMParser();

      var doc = parser.parseFromString(temp,'text/html');

      return doc.body.innerText;

    }
    console.log(Data)

    return(
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
                    {data.map((Questions,index) => 
                    <tr key = {index}>
                        <td>{Replace(Questions.text)}</td>
                        <td>Questions.topic.name</td>
                        <td>Questions.DifficultyLevel</td>

                    </tr>
                    )}
                </tbody>
            </Table>
        </div>
       
    )



}
export default ExamQuestionList;
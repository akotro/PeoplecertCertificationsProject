import React, { useEffect, useState, useContext } from "react";
import { AuthenticationContext } from '../auth/AuthenticationContext'
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';
import { BrowserRouter, Route, useParams } from "react-router-dom";

import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function MarkerList(props) {

    const navigate = useNavigate();
    const [data, setData] = useState([]);
    const [exams, setExams] = useState([]);
    const { update, claims } = useContext(AuthenticationContext);
    // const [role, setRole] = useState(claims.find(claim => claim.name === 'role').value)
    // const [markerId, setMarkerId] = useState(claims.find(claim => claim.name === 'userId').value)
    const markerId = claims.find(data => data.name === "userId").value;
    const role = claims.find(data => data.name === "role").value;

    useEffect(() => {


        axios.get(`https://localhost:7196/api/Markers/${markerId}`).then((response) => {
            setData(response.data.data);
            setExams(response.data.data.candidateExams);
            console.log(response.data.data);
        }).catch(function (error) {
            console.log(error);
        });
    }, []);

    return (
        <div className='container-fluid'>
            <Table striped borderless hover>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Score</th>
                        <th>Mark Until</th>
                        <th>Passed?</th>
                    </tr>
                </thead>
                <tbody>
                    {exams.map((CandidateExam, index) => (
                            <tr key={index}>
                                <td>{CandidateExam.exam.certificateTitle}</td>
                                <td>{CandidateExam.candidateScore}</td>
                                <td>{CandidateExam.markerAssignedDate}</td>
                                <td>
                                {CandidateExam.result ===true ? 
                                <input class="form-check-input" type="checkbox" checked disabled /> : 
                                <input class="form-check-input" type="checkbox" disabled />
                                }
                                   </td>
                                <td>
                                    <Button onClick={() => navigate(`/marker/markexam`,{state : { data : CandidateExam }})}>Mark Exam</Button>
                                </td>
                            </tr>
                        ))}
                </tbody>
            </Table>
        </div>
    );
};

export default MarkerList;

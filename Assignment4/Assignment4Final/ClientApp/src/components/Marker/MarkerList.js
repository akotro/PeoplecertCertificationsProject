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
    const [markedExams, setmarkedExams] = useState([]);
    const { update, claims } = useContext(AuthenticationContext);
    // const [role, setRole] = useState(claims.find(claim => claim.name === 'role').value)
    // const [markerId, setMarkerId] = useState(claims.find(claim => claim.name === 'userId').value)
    const markerId = claims.find(data => data.name === "userId").value;
    const role = claims.find(data => data.name === "role").value;

    useEffect(() => {

        console.log(role)
        if (role === "marker") {
            axios.get(`https://localhost:7196/api/Markers/${markerId}`).then((response) => {
                setData(response.data.data);
                setExams([...response.data.data.candidateExams.filter(x => x.isModerated === null)]);
                setmarkedExams([...response.data.data.candidateExams.filter(x => x.isModerated === true)])
                // console.log(response.data.data);
                // console.log(response.data.data.candidateExams.filter(x => x.isModerated === true));
                // console.log(response.data.data.candidateExams.filter(x => x.isModerated === null));
            }).catch(function (error) {
                console.log(error);
            });
        } else if (role === "admin") {
            axios.get(`https://localhost:7196/api/Markers`).then((response) => {
                // console.log(response.data.data)
                // console.log(response.data.data.map(marker => marker.candidateExams).flat().filter(x => x.isModerated === null))
                // console.log(response.data.data.map(marker => marker.candidateExams).flat().filter(x => x.isModerated === true))
                // setData(response.data.data);
                setExams([...response.data.data.map(marker => marker.candidateExams).flat().filter(x => x.isModerated === null)]);
                setmarkedExams([...response.data.data.map(marker => marker.candidateExams).flat().filter(x => x.isModerated === true)])

            }).catch(function (error) {
                console.log(error);
            });
        }
    }, []);

    const makeDate = (AssignDate) => {
        // let dateTime = "2023-02-10T11:46:07.3120706";
        let date = new Date(AssignDate);
        let options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };

       return date.toLocaleDateString('en-US', options);
    }

    return (
        <div className='container-fluid'>
            <div>
                <div>
                    <div>Exams to be Marked!</div>
                    <Table striped borderless hover>
                        <thead>
                            <tr>
                                <th style={{ width: "50%" }}>Title</th>
                                <th style={{ width: "8%" }}>Score</th>
                                <th style={{ width: "22%" }}>Mark Until</th>
                                <th>Passed?</th>
                            </tr>
                        </thead>
                        <tbody>
                            {exams.map((CandidateExam, index) => (
                                <tr key={index}>
                                    <td>{CandidateExam.exam.certificateTitle}</td>
                                    <td>{CandidateExam.candidateScore}</td>
                                    <td>{makeDate(CandidateExam.markerAssignedDate)}
                                    {/* <Button onClick={()=> makeDate(CandidateExam.markerAssignedDate)}>print date</Button> */}
                                    </td>
                                    <td>
                                        {CandidateExam.result === true ?
                                            <input class="form-check-input" type="checkbox" checked disabled /> :
                                            <input class="form-check-input" type="checkbox" disabled />
                                        }
                                    </td>
                                    <td>
                                        <Button onClick={() => navigate(`/marker/markexam`, { state: { data: CandidateExam } })}>Mark Exam</Button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </div>

            </div>
            <div>Already marked Exams</div>
            <Table striped borderless hover>
                <thead>

                    <tr>
                        <th style={{ width: "50%" }}>Title</th>
                        <th style={{ width: "8%" }}>Score</th>
                        <th style={{ width: "22%" }}>Marked on</th>
                        <th>Passed?</th>
                    </tr>
                </thead>
                <tbody>
                    {markedExams.map((CandidateExam, index) => (
                        <tr key={index}>
                            <td >{CandidateExam.exam.certificateTitle}</td>
                            <td>{CandidateExam.candidateScore}</td>
                            <td>{makeDate(CandidateExam.markingDate)}</td>
                            <td>
                                {CandidateExam.result === true ?
                                    <input class="form-check-input" type="checkbox" checked disabled /> :
                                    <input class="form-check-input" type="checkbox" disabled />
                                }
                            </td>
                            <td>
                                <Button onClick={() => navigate(`/marker/markexam`, { state: { data: CandidateExam } })}>View Marking</Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
        // </div>
    );
};

export default MarkerList;

import React from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { Table } from 'react-bootstrap';
import BackButton from '../Common/Back'

export default function Results() {

    const location = useLocation();
    const navigate = useNavigate();

    const incomingData = location.state.data;
    // console.log(incomingData);

    return (
        <div>
            <h4>Results</h4>
            <div className='container-fluid'>
                <Table>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Exam Date</th>
                            <th>Max Score</th>
                            <th>Passing Score</th>
                            <th>My Score</th>
                            <th>My Percentage Score</th>
                            <th>Result</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>{incomingData.exam.certificateTitle}</td>
                            <td>{incomingData.examDate}</td>
                            <td>{incomingData.maxScore}</td>
                            <td>{incomingData.exam.passMark}</td>
                            <td>{incomingData.candidateScore}</td>
                            <td>{incomingData.percentScore} %</td>
                            <td style={{ color: incomingData.result ? 'green' : 'red' }}>
                                {incomingData.result ? "Passed" : "Failed"}
                            </td>
                        </tr>
                    </tbody>
                </Table>
                {location.state && location.state.from === '/candidate/availableexams' && (
                    <BackButton />
                )}
            </div>
        </div>
    )
}
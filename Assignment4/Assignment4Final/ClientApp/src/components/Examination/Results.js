import React from "react";
import { useLocation } from "react-router-dom";
import { Table } from 'react-bootstrap';

export default function Results() {

    const location = useLocation();

    const incomingData = location.state.data;
    console.log(incomingData);

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
                            <td>{incomingData.exam.certificate.maxMark}</td>
                            <td>{incomingData.exam.certificate.passingMark}</td>
                            <td>{incomingData.candidateScore}</td>
                            <td>{incomingData.percentScore0} %</td>
                            <td>
                                {incomingData.result ? "Passed" : "Failed"}
                            </td>
                        </tr>
                    </tbody>
                </Table>
            </div>
        </div>
    )
}
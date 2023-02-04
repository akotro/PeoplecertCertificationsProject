import React, { useEffect, useState } from "react";
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { withRouter } from './../Common/with-router';
import { BrowserRouter, Route, useParams } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function AvailableExams(props) {

    const [data, setData] = useState([]);
    const [user, setUser] = useState();
    let navigate = useNavigate();

    useEffect(() => {
        axios.get('https://localhost:7196/api/CandidateExam/notTaken').then((response) => {
            setData(response.data);
        }).catch(function (error) {
            console.log(error);
        });
        if (!user) {
            setUser("admin");
        }
    }, []);

    const takeExam = (id) => {
        navigate(`/candidate/Examination/${1020}`);
    };

    return (
            <div className='container-fluid'>
                <Table striped borderless hover>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Voucher</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map((CandidateExam, index) => (
                            <tr key={index}>
                                {/*<td>{CandidateExam.Exam.CertificateTitle}</td>*/}
                                <td>{CandidateExam.Voucher}</td>
                                <td>
                                    <Button variant="success" onClick={() => takeExam(CandidateExam.Id)} >Take Exam</Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </div>
        );
    };

export default AvailableExams;
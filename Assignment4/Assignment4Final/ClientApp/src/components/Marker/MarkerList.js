import React, { useEffect, useState } from "react";
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { withRouter } from './../Common/with-router';
import { BrowserRouter, Route, useParams } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function MarkerList(props) {

    const [data, setData] = useState([]);
    // const [user, setUser] = useState();
    let navigate = useNavigate();

    useEffect(() => {
        axios.get('https://localhost:7196/api/CandidateExam').then((response) => {
            setData(response.data);
            console.log(response);
        }).catch(function (error) {
            console.log(error);
        });
        // if (!user) {
        //     setUser("admin");
        // }
    }, []);

    const takeExam = (id) => {
        console.log('Id of candidateExam:' + id);
        navigate(`/candidate/Examination/${id}`);
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
                                <td>{CandidateExam.exam.certificateTitle}</td>
                                <td>{CandidateExam.Voucher}</td>
                                <td>
                                    <Button variant="success" onClick={() => takeExam(CandidateExam.id)} >Take Exam</Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </div>
        );
    };

export default MarkerList;

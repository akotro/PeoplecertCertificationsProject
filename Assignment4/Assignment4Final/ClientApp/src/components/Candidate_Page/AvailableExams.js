import React, { useEffect, useState } from "react";
import { ListGroup, ListGroupItem, Button, Table, Row, Stack, Form } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { withRouter } from './../Common/with-router';
import { BrowserRouter, Route, useParams } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function AvailableExams(props) {

    const [data, setData] = useState([]);
    const [exams, setExams] = useState([]);
    const [takenExams, setTakenExams] = useState([]);
    const [user, setUser] = useState();
    let navigate = useNavigate();

    useEffect(() => {
        axios.get('https://localhost:7196/api/CandidateExam').then((response) => {
            setData(response.data);

            setExams([...response.data.filter(exam => exam.result === null)])
            setTakenExams([...response.data.filter(exam => exam.result !== null)])
            console.log(response.data);
            console.log(...response.data.filter(exam => exam.result === null));
            console.log(...response.data.filter(exam => exam.result !== null));
        }).catch(function (error) {
            console.log(error);
        });
        if (!user) {
            setUser("admin");
        }
    }, []);

    const handleChange = (event) => {
        const { name, value, type } = event.target;

        console.log("name",name);
        console.log("type", type);
        console.log("value", value);
        console.log(exams.examDate)



    }

    const convertDateToString = (date) => {
        //console.log(date);
        let kati = new Date(date);
    
        let formattedDate = kati.toISOString().substr(0, 10);
    
        return formattedDate;
      };

    const makebuttons = (CandExam) => {

        if (CandExam.result !== null) {
            return (
                <td>
                    <div className='d-flex '>
                        <Button variant="success" >View Result</Button>
                    </div>
                </td>
            );
        } else {
            return (
                <td>
                    <div className='d-flex gap-2'>
                        <Button onClick={() => takeExam(CandExam.id)}>Take exam now!</Button>

                        <Form.Group >
                                    <Form.Control type="date"
                                        name="examDate"
                                        value={convertDateToString(CandExam.examDate)}
                                        onChange={handleChange} />
                                </Form.Group>
                                
                        <Button>Book Exam</Button>
                    </div>
                </td>
            );
        }


    };

    const takeExam = (id) => {
        console.log('Id of candidateExam:' + id);
        navigate(`/candidate/Examination/${id}`);
    };

    const makeDate = (examDate) => {
        let date = new Date(examDate);
        let options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };

        return date.toLocaleDateString('en-US');
    }
    const newLocal = "success";
    return (
        <div className='container-fluid'>
            <div>

                <h1>available exams</h1>
                <Table striped borderless hover>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Voucher</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {exams.map((CandidateExam, index) => (
                            <tr key={index}>
                                <td>{CandidateExam.exam.certificate.title}</td>
                                <td>{CandidateExam.exam.certificate.title}</td>
                                <td>{CandidateExam.Voucher}</td>
                                <td>
                                    {makebuttons(CandidateExam)}

                                    {/* <Button variant="success" onClick={() => takeExam(CandidateExam.id)} >Take Exam</Button> */}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </div>
            <div>
                <h1>taken exams</h1>
                <Table striped borderless hover>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Exam Date</th>
                            <th>Score</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {takenExams.map((CandidateExam, index) => (
                            <tr key={index}>
                                <td>{CandidateExam.exam.certificate.title}</td>
                                <td>{makeDate(CandidateExam.examDate)}</td>
                                <td>{CandidateExam.percentScore}&nbsp;%</td>
                                <td>
                                    {makebuttons(CandidateExam)}
                                    {/* <Button variant={newLocal} onClick={() => takeExam(CandidateExam.id)} >Take Exam</Button> */}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </div>
        </div>
    );
};

export default AvailableExams;

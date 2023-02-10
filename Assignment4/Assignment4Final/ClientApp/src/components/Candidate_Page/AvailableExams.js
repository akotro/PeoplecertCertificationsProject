import React, { useEffect, useState } from "react";
import { ListGroup, ListGroupItem, Button, Table, Row, Stack, Form } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { withRouter } from './../Common/with-router';
import { BrowserRouter, Route, useParams } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { Modal, DatePicker } from 'antd';

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

    const [showModal, setShowModal] = useState(false);
    const [selectedDate, setSelectedDate] = useState(null);

    const handleOk = (CandExam) => {
        setShowModal(false);
        setSelectedDate(new Date());

        console.log(CandExam);

        const updatedExams = exams.map(exam => {
            if (exam === CandExam) {
                exam.examDate = selectedDate;
                // return { ...exam, examDate: selectedDate };
            }
            // return exam;
        });
        
        // const exams2 = {...exams.map(exam => exam.id === CandExam.id ? exam.examDate = selectedDate : null)}
        // console.log(exams2)

        console.log(updatedExams);
        // setExams(updatedExams);
    };

    const handleCancel = () => {
        setShowModal(false);
    };

    const handleDateChange = (dateString) => {
        setSelectedDate(dateString);
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
                        <Button onClick={() => takeExam(CandExam)}>Take Exam</Button>

                        <Button onClick={() => setShowModal(true)}>Book Date</Button>
                        <Modal
                            title="Select a date"
                            open={showModal}
                            onOk={() => handleOk(CandExam)}
                            onCancel={handleCancel} >
                            <DatePicker onChange={handleDateChange} />
                        </Modal>
                    </div>
                </td>
            );
        }
    };

    const takeExam = (CandExam) => {
        const currentDate = new Date();
        const examDate = new Date(CandExam.examDate);

        if (examDate.getTime() < currentDate.getTime()) {
            alert("The exam date has passed.");
            return;
        }

        navigate(`/candidate/Examination/${CandExam.id}`);
    };

    const makeDate = (examDate) => {
        if (!examDate) {
            return "";
        }

        let date = new Date(examDate);
        let options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };

        if (date && date.toString() !== "Invalid Date") {
            return date.toLocaleDateString('en-US', options);
        } else {
            return "";
        }
    }

    return (
        <div className='container-fluid'>
            <div>

                <h1>available exams</h1>
                <Table striped borderless hover>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Voucher</th>
                            <th>Exam Date</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {exams.map((CandidateExam, index) => (
                            <tr key={index}>
                                <td>{CandidateExam.exam.certificate.title}</td>
                                <td>{CandidateExam.exam.certificate.title}</td>
                                <td>{makeDate(CandidateExam.examDate)}</td>
                                <td>{CandidateExam.Voucher}</td>
                                <td>
                                    {makebuttons(CandidateExam)}
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

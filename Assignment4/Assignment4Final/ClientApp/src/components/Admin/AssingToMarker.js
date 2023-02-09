import axios from "axios"
import { useState, useEffect, useContext } from "react";
import { Form, Row, Col, Button } from "react-bootstrap";
import { AuthenticationContext } from '../auth/AuthenticationContext'
import MarkerList from "../Marker/MarkerList";


function AssignToMarker() {
    const { update, claims } = useContext(AuthenticationContext);
    const [markers, setMarkers] = useState([]);
    const [exams, setExams] = useState([]);
    const [newCandidateExam, setnewCandidateExam] = useState({marker:[]});

    useEffect(() => {
        axios.get(`https://localhost:7196/api/Markers`).then((response) => {
            console.log(response.data.data)
            setMarkers(response.data.data);
        }).catch(function (error) {
            console.log(error);
        });
        axios.get(`https://localhost:7196/api/Markers/getallcandidateexams/`).then((response) => {
            setExams(response.data.data);
        }).catch(function (error) {
            console.log(error);
        });
    }, []);

    const convertDateToString = (date) => {
        let kati = new Date(date);
        let formattedDate = kati.toISOString().substr(0, 10);
        return formattedDate;
    };

      const handleChange = (event) => {
        // edit the CandidateExam to add the Marker ID
        const { name, value, type } = event.target;
        console.log(name);
        // console.log(type);
        console.log(value);
        // console.log(exams.find(item => item.id === Number(value)))
        if (name === "id"){
            setnewCandidateExam({ ...newCandidateExam, [name]: value })
        }else if (name === "marker") {
            setnewCandidateExam({ ...newCandidateExam, [name]: {appUserId: value}  })
            // setnewCandidateExam({ ...newCandidateExam,  })
        }
    }

    const handleSubmit = async (event) => {
        event.preventDefault();
        await axios.put(`https://localhost:7196/api/Markers/assign/${newCandidateExam.id}`, newCandidateExam)
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error.messages);
        });
    }

    return (
        <div>
            <h1>AssignToMarker</h1>
            <Form onSubmit={handleSubmit}>
                <Row>
                    <Col xs={4}>
                        <Form.Group >
                            <Form.Label>Select Marker</Form.Label>
                            <Form.Select as="select" name="marker"
                                value={newCandidateExam.marker.appUserId}
                                onChange={handleChange}
                                required>
                                <option value="" hidden>Please choose a Marker </option>
                                {markers.map((marker, index) =>
                                    <option key={index}
                                        value={marker.appUserId}
                                    >{marker.appUser.email}</option>
                                )}
                            </Form.Select>
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group >
                            <Form.Label>Select Exam</Form.Label>
                            <Form.Select as="select" name="id"
                                value={newCandidateExam.exam}
                                onChange={handleChange}
                                required>
                                <option value="" hidden>Please choose an exam </option>
                                {exams.map((exam, index) =>
                                    <option key={index}
                                        value={exam.id}
                                    >{exam.candidate.firstName}&nbsp;
                                        {exam.candidate.lastName}&nbsp;|&nbsp;
                                        Exam date : {convertDateToString(exam.examDate)}&nbsp;|&nbsp;
                                        Voucher : {exam.voucher}
                                    </option>
                                )}
                            </Form.Select>
                        </Form.Group>
                    </Col>
                </Row>
                <Button variant="primary" type="submit" >
                    Save
                </Button>
            </Form>
        </div>
    );
}

export default AssignToMarker

import axios from "axios"
import { useState, useEffect, useContext } from "react";
import { Form, Row, Col, Button } from "react-bootstrap";
import { AuthenticationContext } from '../auth/AuthenticationContext'
import MarkerList from "../Marker/MarkerList";


function AssignToMarker() {
    const { update, claims } = useContext(AuthenticationContext);
    const [markers, setMarkers] = useState([]);
    const [exams, setExams] = useState([]);
    const [newCandidateExam, setnewCandidateExam] = useState({});

    useEffect(() => {
        // console.log(data)
        //axios call for markers
        //axios call for exams


        axios.get(`https://localhost:7196/api/Markers`).then((response) => {
            console.log(response.data.data)
            // console.log(response.data.data.map(marker => marker.candidateExams).flat().filter(x => x.isModerated === null))
            // console.log(response.data.data.map(marker => marker.candidateExams).flat().filter(x => x.isModerated === true))
            // setData(response.data.data);
            // .filter(x => x.isModerated === null)]
            setMarkers(response.data.data);

        }).catch(function (error) {
            console.log(error);
        });

        axios.get(`https://localhost:7196/api/Markers/getallcandidateexams/`).then((response) => {
            // console.log(response.data.data)
            // console.log(response.data.data.map(marker => marker.candidateExams).flat().filter(x => x.isModerated === null))
            // console.log(response.data.data.map(marker => marker.candidateExams).flat().filter(x => x.isModerated === true))
            // setData(response.data.data);
            // .filter(x => x.isModerated === null)]
            setExams(response.data.data);

        }).catch(function (error) {
            console.log(error);
        });

    }, []);


    const convertDateToString = (date) => {
        //console.log(date);
        let kati = new Date(date);

        let formattedDate = kati.toISOString().substr(0, 10);

        return formattedDate;
    };

    // axios.get('https://localhost:7196/api/Markers')
    // .then(res => {
    //             // if the user is a candidate, show only active products
    //             console.log(res.data.data.filter(item => item.active === true))
    //             setData([...res.data.data.filter(item => item.active === true)])
    //             // () => { console.log(data) })
    //             console.log(res.data.data)
    //             //if none of the above, show all products
    //             setData(res.data.data)
    //             console.log(res.data.data)
    //     })
    //     .catch(err => {
    //         console.error(err);
    //     });

    //     console.log(data)
    // }, [])

    const handleChange = (event) => {
        // edit the CandidateExam to add the Marker ID
        const { name, value, type } = event.target;
        console.log(name);
        // console.log(type);
        console.log(value);
        // console.log(exams.find(item => item.id === Number(value)))
 
        if (name === "candidateExams"){
            setnewCandidateExam({ ...newCandidateExam, [name]: [exams.find(item => item.id === Number(value))] })
        }else if (name === "appUserId") {
            setnewCandidateExam({ ...newCandidateExam, [name]: value,appUser: markers.find(item => item.appUser.id === value).appUser  })
            // setnewCandidateExam({ ...newCandidateExam,  })
        }
        
    }

    const handleSubmit = async (event) => {
        event.preventDefault();

        // await axios.put(`https://localhost:7196/api/Marker/${newCandidateExam.appUserId}`, newCandidateExam)
        // .then(function (response) {
        //     console.log(response);
        // })
        // .catch(function (error) {
        //     console.log(error.response);
        //     console.log(error.messages);
        //     console.log(error.config);
        // });
        // // send put request with changed data
        fetch(`https://localhost:7196/api/Marker/${newCandidateExam.appUserId}`, {
  method: 'PUT',
  headers: {
    'Content-Type': 'application/json'
  },
  body: JSON.stringify(newCandidateExam)
})
.then(response => response.json())
.then(data => console.log(data))
.catch(error => {
  console.error('There was a problem with the fetch operation:', error);
});

        console.log(markers)
        console.log(exams)
        
// /api/Marker/${id}
    }
    // {/* console.log(marker.appUserId);
    // console.log(marker.appUser.email); */}

    return (
        <div>
            <h1>AssignToMarker</h1>
            <Form onSubmit={handleSubmit}>
                <Row>
                    <Col xs={4}>
                        <Form.Group >
                            <Form.Label>Select Marker</Form.Label>
                            <Form.Select as="select" name="appUserId"
                                value={newCandidateExam.marker}
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
                            <Form.Select as="select" name="candidateExams"
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
            {/* have 2 dropdown menus here */}
        </div>
    );
}

export default AssignToMarker

import React, { useEffect, useState, useContext } from "react";
import axios from 'axios';
import { ListGroup, ListGroupItem, Button, Table, Row, Stack, Form } from 'react-bootstrap';
import { useNavigate, Link } from "react-router-dom";
import { AuthenticationContext } from '../auth/AuthenticationContext'

function ExamList(props) {
    const [exams, setExams] = useState([]);
    const [showForm, setShowForm] = useState(false);
    const [certificates, setCertificates] = useState([]);
    const [certId, setCertId] = useState('');
    let navigate = useNavigate();
    // const { update, claims } = useContext(AuthenticationContext);
    // const [role, setRole] = useState(claims.find(claim => claim.name === 'role').value)
    // const [user, setUser] = useState();
    // let navigate = useNavigate();

    useEffect(() => {
        axios.get('https://localhost:7196/api/Exam').then((response) => {
            setExams(response.data)
        }).catch(function (error) {
            console.log(error)
        })

    }, []);


    const getCertificates =  async () => {
        {
            console.log('form get')
            await axios.get(`https://localhost:7196/api/Certificates`).then((response) =>{
                console.log('its there',response.data.data)
                setCertificates(response.data.data)
            })
        }
    }

    const handleDelete = (examId) => {
        setExams(exams.filter(exam => exam.id !== examId));
        axios.delete(`https://localhost:7196/api/Exam/${examId}`)
            .then(response => {
                console.log(response)
            })
    }



    const handleEdit = (examEdit) => {
        console.log(examEdit)
        navigate(`/ExamQuestionList/${examEdit.id}`)
    }

    const makeButtons = (examButtons) => {

        return ( // default do we need this??
            <div>
                <Button onClick={() => handleDelete(examButtons.id)}>Delete</Button>
                <Button onClick={() => handleEdit(examButtons)}>Edit</Button>
            </div>
        )
    }

    const calculateCount = (questionsArray) => {
        return (<>{questionsArray.length}</>)
    }


    const handleChange = event => {
        console.log(event.target.value)
        setCertId(event.target.value)
    }

    const handleSubmitExam = async event => {
        event.preventDefault();
        console.log('certId',certId)
        console.log(certificates)
        var certif = certificates.find(certificate => certificate.id == certId)
        console.log("certif",certif)
        console.log({certificate : certif})
        await axios.post(`https://localhost:7196/api/Exam`,{certificate : certif}).then((response) =>{
                console.log(response)
                navigate(`/AddQuestionToExam/${response.data.data.id}`)
            })
            

        console.log("certif",certif)
        
    }

    const createCertificateButton = async () => {
        console.log(certificates)
        await getCertificates();
        setShowForm(!showForm)
        console.log('from button',certificates)
    }

    return (
        <div>
            <button onClick={() => createCertificateButton()}>
                {showForm ? "Close Form":"Create New Exam"}
            </button>
            {showForm && (
                <Form onSubmit={handleSubmitExam}>
                    <p>katiii</p>

                    <Form.Select as="select" name="Certificate"
                    onChange={handleChange} required>
                    {certificates.map((certificate, index) =>
                        <option key={index} value={certificate.id}>{certificate.title}</option>
                    )}
                </Form.Select>
                    <button type="submit">"Save Exam & Add Answers"</button>
                </Form>
            )}
            




            <Table striped borderless hover id='list_Of_Exams'>
                <thead>
                    <th>Certificate Title</th>
                    <th>Number Of Questions</th>
                </thead>

                <tbody>
                    {exams.map((exam, index) =>
                        <tr key={index}>
                            <td>{exam.certificate.title}</td>
                            <td>{calculateCount(exam.questions)}</td>
                            <td>{makeButtons(exam)}</td>
                        </tr>
                    )
                    }
                </tbody>
            </Table>
        </div>
    )

}
export default ExamList

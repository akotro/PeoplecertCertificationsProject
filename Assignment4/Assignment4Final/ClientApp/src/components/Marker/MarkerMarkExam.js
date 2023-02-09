import { useNavigate, Link, useLocation } from "react-router-dom";
import React, { useEffect, useState, useContext } from "react";
import axios from 'axios';
import { Col, Row, Stack, Button, Table } from "react-bootstrap";


function MarkExam(props) {

    const navigate = useNavigate();
    const location = useLocation();

    const [exam, setExam] = useState(location.state.data);
    const initialScore = location.state.data.candidateScore;

    const incomingData = location.state.data;
    const role = location.state.role;

    useEffect(() => {
        // initialScore = exam.candidateScore;
        // console.log(incomingData)
        // setExam(incomingData)
        // console.log(exam.exam.certificateTitle)
        // console.log(exam.candidateExamAnswers)
    }, []);


    const handleChange = (event, queIndex) => {
        const { name, value, type, checked } = event.target;
        // console.log(name);
        // console.log(event.target.checked);
        // console.log("type", type);
        // console.log(value);
        if (type === 'checkbox') {
            setExam({
                ...exam, candidateExamAnswers: exam.candidateExamAnswers.map((canAn, Index) => {
                    if (Index === queIndex) {
                        return {
                            ...canAn, [name]: checked
                        };
                    } return canAn;
                })
            })
        }
        // if (initialScore !== exam.candidateScore) {
        // setExam({...exam , candidateScore: exam.candidateExamAnswers.filter(ans=> ans.isCorrectModerated).count()})
        console.log(exam.candidateExamAnswers.filter(ans => ans.isCorrectModerated === true).length)
        // }
        // const updatedExam = {...exam, isModerated: true};
        // setFinalScore();
        // exam.isModerated = true;
        console.log(exam)
        // setExam(exam)
    }

    function Replace(temp) {
        return (
            <td
                dangerouslySetInnerHTML={{
                    __html: temp,
                }}
            ></td>
        )
    }

    const handleSubmit = (canExamId) => {
        exam.isModerated = true;
        setExam(exam);

        axios.put(`https://localhost:7196/api/Markers/mark/${canExamId}`, exam)
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
    }


    const setFinalScore = () => {

        console.log(exam.candidateScore)
        setExam({ ...exam, candidateScore: exam.candidateExamAnswers.filter(answer => answer.isCorrectModerated === false).length })
        console.log(...exam.candidateExamAnswers.filter(answer => answer.isCorrectModerated === true))
        console.log(...exam.candidateExamAnswers.filter(answer => answer.id === 1))
    }

    return (
        <div>
            <div>
                <Row>
                    <Col xs={8}>
                        <h4>Title: {exam.exam.certificateTitle}</h4>
                    </Col>
                    <Col>
                        {initialScore !== exam.candidateScore &&
                            <div>
                                <Row>
                                    <Col>
                                        Initial Score ({(initialScore / exam.maxScore) * 100}%) :
                                    </Col>
                                    <Col>
                                        {initialScore}/{exam.maxScore}
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        Score After Marking ({(exam.candidateScore / exam.maxScore) * 100}%) :
                                    </Col>
                                    <Col>
                                        {exam.candidateScore}/{exam.maxScore}
                                    </Col>
                                </Row>
                            </div>
                        }
                    </Col>
                </Row>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Question</th>
                        <th>Marked As</th>
                    </tr>
                </thead>
                <tbody>
                    {exam.candidateExamAnswers.map((que, index) =>
                        <tr key={index}>
                            <td xs={1}>
                                {index + 1}
                            </td>
                            <td>
                                {Replace(que.questionText)}
                                <div>
                                    <ul>
                                        <li>
                                            {Replace(que.correctOption)}
                                        </li>
                                        <li>
                                            {Replace(que.chosenOption)}
                                        </li>
                                    </ul>
                                    {/* <details className="display-6 fs-4">
                                                    <summary>
                                                        Click here if you want to see all the options
                                                    </summary>
                                                    {que.map((option)=> {
                                                        <ol>
                                                            <li>

                                                            </li>
                                                        </ol>
                                                    })}
                                                    </details> */}
                                </div>
                            </td>
                            <td>
                                {que.isCorrectModerated}
                                <input
                                    type="checkbox"
                                    name='isCorrectModerated'
                                    label="Is the certificate available for puchase?"
                                    defaultChecked={que.isCorrectModerated}
                                    onChange={(event) => handleChange(event, index)}
                                    disabled={exam.isModerated === true || role === "qualitycontrol" ? true : false}
                                />
                            </td>
                        </tr>
                    )}
                </tbody>
            </Table>
            <Stack gap={3}>
                {role !== "qualitycontrol" &&
                    <Button onClick={() => handleSubmit(exam.id)}>
                        Save & Submit Marking
                    </Button>}
                <Button variant='dark' className='d-grid col-12 mx-auto mb-2' onClick={() => navigate(-1)}> Go Back </Button>
            </Stack>
        </div>
    );
}


export default MarkExam;

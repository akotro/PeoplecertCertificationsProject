import { useNavigate, Link, useLocation } from "react-router-dom";
import React, { useEffect, useState, useContext } from "react";
import axios from 'axios';
import parse from 'html-react-parser';
import { Col, Row, Stack, Button, Table } from "react-bootstrap";
import { AiOutlineCheck, AiOutlineClose } from "react-icons/ai";

function MarkExam(props) {

    const navigate = useNavigate();
    const location = useLocation();

    // const [exam, setExam] = useState(location.state.data);
    const [data, setData] = useState([]);
    const initialScore = location.state.data.candidateScore;

    // const incomingData = location.state.data;
    // const role = location.state.role;

    console.log(location.state.data);

    useEffect(() => {
        axios.get(`https://localhost:7196/api/getCandExamById/${location.state.data}`)
          .then((response) => {
            console.log(response);
            setData(response);
          })
          .catch((error) => {
            console.log("I am in error");
            console.log(error);
          });
      }, []);


    const handleChange = (event, queIndex) => {
        const { name, value, type, checked } = event.target;
        // console.log(name);
        // console.log(event.target.checked);
        // console.log("type", type);
        // console.log(value);
        if (type === 'checkbox') {
            setData({
                ...data, candidateExamAnswers: data.candidateExamAnswers.map((canAn, Index) => {
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
        console.log(data.candidateExamAnswers.filter(ans => ans.isCorrectModerated === true).length)
        // }
        // const updatedExam = {...exam, isModerated: true};
        // setFinalScore();
        // exam.isModerated = true;
        console.log(data)
        // setExam(exam)
    }
    //--------------------------------------------------//filters the text from the raw html
    function Replace(temp) {
        return (
            <td
                dangerouslySetInnerHTML={{
                    __html: temp,
                }}
            ></td>
        )
    }

    function ReplaceV2(temp) {
        return (
            <p>{parse(temp)}</p>
        )
    }
    //--------------------------------------------------

    const handleSubmit = (canExamId) => {
        data.isModerated = true;
        setData(data);

        axios.put(`https://localhost:7196/api/Markers/mark/${canExamId}`, data)
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
    }


    const setFinalScore = () => {

        console.log(data.candidateScore)
        setData({ ...data, candidateScore: data.candidateExamAnswers.filter(answer => answer.isCorrectModerated === false).length })
        console.log(...data.candidateExamAnswers.filter(answer => answer.isCorrectModerated === true))
        console.log(...data.candidateExamAnswers.filter(answer => answer.id === 1))
    }

    return (
        <div>
            <div>
                <Row>
                    <Col xs={8}>
                        {/* <h4>Title: {data.exam.certificateTitle}</h4> */}
                    </Col>
                    <Col>
                        {initialScore !== data.candidateScore && (
                            <div>
                                <Row>
                                    <Col>
                                        Initial Score (
                                        {(initialScore / data.maxScore) * 100}%)
                                        :
                                    </Col>
                                    <Col>
                                        {initialScore}/{data.maxScore}
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        Score After Marking (
                                        {(data.candidateScore / data.maxScore) *
                                            100}
                                        %) :
                                    </Col>
                                    <Col>
                                        {data.candidateScore}/{data.maxScore}
                                    </Col>
                                </Row>
                            </div>
                        )}
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
                    {data.candidateExamAnswers.map((que, index) => (
                        <tr key={index}>
                            <td xs={1}>{index + 1}</td>
                            <td>
                                {Replace(que.questionText)}
                                <div>
                                    <ul>
                                        <li>{Replace(que.correctOption)}</li>
                                        <li>{Replace(que.chosenOption)}</li>
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
                                    {/* //  ------- ------- ------- OPTIONS------- -------  ------- ------- */}
                                    <div>
                                        <hr />
                                        <div
                                            key={index}
                                            name={que.id}
                                            className="my-1 "
                                        >
                                            <Row>
                                                <details className="display-6 fs-4">
                                                    <summary>Options</summary>
                                                    <div className="card card-body ">
                                                        <div className="justify-content-end"></div>
                                                        <Table>
                                                            <thead>
                                                                <th>Id</th>
                                                                <th>Text</th>
                                                                <th>
                                                                    Correct{" "}
                                                                </th>
                                                            </thead>
                                                            <tbody>
                                                                {que.question.options.map(
                                                                    (option,
                                                                        index) => (
                                                                        <tr key={index}>
                                                                            <td>
                                                                                {option.id}
                                                                            </td>
                                                                            <td>{ReplaceV2(
                                                                                option.text
                                                                            )}</td>
                                                                            <td>{option.correct ? (
                                                                                <AiOutlineCheck />) : (
                                                                                <AiOutlineClose />
                                                                            )}
                                                                            </td>
                                                                        </tr>
                                                                    )
                                                                )}
                                                            </tbody>
                                                        </Table>
                                                    </div>
                                                </details>
                                            </Row>
                                        </div>

                                        <hr />
                                    </div>
                                </div>
                                {/* //  ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- ------- */}
                            </td>
                            <td>
                                {que.isCorrectModerated}
                                <input
                                    type="checkbox"
                                    name="isCorrectModerated"
                                    label="Is the certificate available for puchase?"
                                    defaultChecked={que.isCorrectModerated}
                                    onChange={(event) =>
                                        handleChange(event, index)
                                    }
                                    // disabled={
                                    //     data.isModerated === true ||
                                    //         role === "qualitycontrol"
                                    //         ? true
                                    //         : false
                                    // }
                                />
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            <Stack gap={3}>
                {/* {role !== "qualitycontrol" && (
                    <Button onClick={() => handleSubmit(data.id)}>
                        Save & Submit Marking
                    </Button>
                )} */}
                <Button
                    variant="dark"
                    className="d-grid col-12 mx-auto mb-2"
                    onClick={() => navigate(-1)}
                >
                    {" "}
                    Go Back{" "}
                </Button>
            </Stack>
        </div>
    );
}


export default MarkExam;

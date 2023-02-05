import React, { useEffect, useState } from "react";
import axios from 'axios';
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';
import { useNavigate, Link } from "react-router-dom";
function ExamList(props){

    const [data, setData] = useState([]);
    let navigate = useNavigate();
    // const [user, setUser] = useState();
    // let navigate = useNavigate();

    useEffect(() => {
        axios.get('https://localhost:7196/api/Exam').then((response)=>{
            setData(response.data)
        }).catch(function (error){
            console.log(error)
        })
        // if (!user) {
        //     setUser("admin");

        // }

    },[]);

    const handleDelete = (examId) =>{
        axios.delete(`https://localhost:7196/api/Exam/${examId}`)
        .then(response => {
            console.log(response)
        })
    }

    const handleEdit = (exam) => {
        navigate('/ExamQuestionList',{state : { data : exam }})
    }

    const makeButtons = (exam) => {
        if(true) {      //admin
            return(
                <div>
                    <Button onClick={() => handleDelete(exam.id)}>Delete</Button>
                    <Button onClick = {() => handleEdit(exam)}>Edit</Button>
                </div>
            )
        }  
    }

    const calculateCount = (questionsArray) => {
        console.log(questionsArray)
        return(<>{questionsArray.length}</>)
    }

    return(
        <div>   
            <Table striped borderless hover id='list_Of_Exams'>
                <thead>
                    <th>Certificate Title</th>
                    <th>Number Of Questions</th>
                </thead>

                <tbody>
                    {data.map((exam,index) => 
                    <tr key = {index}>
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

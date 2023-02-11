// import {Form,Button,Col,Row,FloatingLabel,Stack,Table,Container,} from "react-bootstrap";

import {Button,Table,Container} from "react-bootstrap";
import  React, {useState, useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";
import parse from "html-react-parser";
// import QuestionEdit from "./QuestionEdit";

function Questions() {
    const [data, setData] = useState([]);

    useEffect(() => {
        axios
            .get("https://localhost:7196/api/questions")
            .then((response) => {
                console.log(response.data.data)
                setData(response.data.data);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);

    //--------------------------------------------------//filters the text from the raw html
    function Replace(temp) {
        return (
            <td>{parse(temp)}</td>
        )
    }
    //--------------------------------------------------HANDLE DELETE
    const  handleDelete = (event) => {
        // Asks user if they are sure
        const localId = event.target.dataset.id;

        const confirmDelete = window.confirm("Are you sure you want to delete this this question?");

        if (confirmDelete) {
            //send axios call with the request to delete using Id
            axios
            .delete(`https://localhost:7196/api/questions/${localId}`)
            .then((response) => {
                // console.log("Delete response");
            })
            .catch(function (error) {
                console.log(error);
            });

            const newData = data.filter((item) => { return item.id != localId;},localId);
            setData( newData);
        }
    }

    //-----------------------------------------------------------
    return (
        <Container fluid="md">
            <Link to="/questions/create">
                <Button variant="dark">Create new Question</Button>
            </Link>
            <div>
                <Table hover striped>
                    <thead>
                        <tr>
                            <th scope="Col">Id</th>
                            <th scope="col">MainText</th>
                            <th scope="col">Topic</th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                        </tr>
                    </thead>

                    <tbody>
                        {data.map((item, index) => (
                            <tr key={item.id}>
                                <td>{item.id != null && item.id}</td>
                                {Replace(item.text)}
                                {/* //--TOPIC--// */}
                                <td>
                                    {item.topic === null
                                        ? "No topic selected"
                                        : item.topic.name}
                                </td>
                                    {/* //--EDIT BUTTON--// */}
                                <td>
                                    <Link to={`/questions/edit/${item.id}`}    state={{questionIndex:item.id}}>
                                            <Button variant="dark">Edit</Button>
                                    </Link>
                                </td>
                                    {/* //--DELETE BUTTON--// */}
                                <td>
                                    <Button
                                        variant="dark"
                                        onClick={ handleDelete}
                                        data-id={item.id}
                                    >
                                        Delete
                                    </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </div>
        </Container>
    );
}

export default Questions;

import React, { useEffect, useState, useContext } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link } from "react-router-dom";
import {AuthenticationContext} from '../auth/AuthenticationContext'

import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';

import axios from 'axios';


function CandidateList(props) {

    const [data, setData] = useState([]);
    //const [buttons, setButtons] = useState();
    const [user, setUser] = useState();
    let navigate = useNavigate();
    const con = useContext(AuthenticationContext);

    useEffect(() => {
       console.log(con.claims.findIndex(claim => claim.name === 'role' && claim.value === 'candidate'))
       console.log(con.claims.findIndex(claim => claim.name === 'role' && claim.value === 'admin'))

    
        axios.get('https://localhost:7196/api/Candidate').then((response) => {
            setData(response.data);
            //console.log(data)
        }).catch(function (error) {
            console.log(error);
        });
        if (!user) {
            setUser("admin");

        }

        //setButtons(makeButtons());
    }, []);

    const handleDelete = (candId) => {
        console.log("delete for id  = ", candId)

        const confirmDelete = window.confirm("Are you sure you want to delete this certificate?");


        axios.delete(`https://localhost:7196/api/Candidate/${candId}`).then(response => {
            console.log(response)
            setData(prevData => prevData.filter(item => item.appUserId !== candId));
        }).catch(response => {
            console.log(response)
        });


    }

    const handleEdit = (candId) => {
        //console.log("edit for id  = ", candId);

        navigate(`/admin/candidate/${candId}`);


    }

const handleDetails = (candId) => {
    console.log("details for id  = ", candId);



}

const makeButtons = (candId) => {
    if (user) {
        if (user === "admin") {
            return (
                <div>
                    <Button onClick={() => handleDelete(candId)}>Delete</Button>
                    <Button onClick={() => handleEdit(candId)}>Edit</Button>
                </div>
            );
        } else if (user === "qc") {
            return <Button onClick={() => handleDetails(candId)}>no action</Button>;
        } else {
            return <div> no buttons for you</div>
        }
    }
}

const convertDateToString = (date) => {
    date = new Date(date);
    const formattedDate = date.toLocaleDateString()
    //console.log(formattedDate);
    return formattedDate;
}

return (
    <div>
        {user === "admin" &&
            <Link to='/admin/candidate/create'>
            <Button> create</Button>
            
            </Link>
        }
        <Table striped borderless hover id='list_of_allcands'>
            <thead>
                <tr>
                    <th>Candidate Number</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Date of Birth</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {data.map((candidate, index) =>
                    <tr key={index}>
                        <td>{candidate.candidateNumber}</td>
                        <td>{candidate.firstName}</td>
                        <td>{candidate.lastName}</td>
                        <td>{candidate.email}</td>
                        <td>{convertDateToString(candidate.dateOfBirth)}</td>
                        <td>{makeButtons(candidate.appUserId)}</td>
                    </tr>
                )}
            </tbody>
        </Table>
    </div>
);

}

export default CandidateList;

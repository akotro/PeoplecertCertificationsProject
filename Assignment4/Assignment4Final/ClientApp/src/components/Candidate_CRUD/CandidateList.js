import React, { useEffect, useState, useContext } from "react";
import CandidateEdit from "../Candidate_CRUD/CandidateEdit";
import { useNavigate, Link } from "react-router-dom";
import { AuthenticationContext } from '../auth/AuthenticationContext'

import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';

import axios from 'axios';


function CandidateList(props) {

    const [data, setData] = useState([]);
    //const [buttons, setButtons] = useState();
    const [user, setUser] = useState();
    let navigate = useNavigate();
    const { update, claims } = useContext(AuthenticationContext);
    const [role, setRole] = useState(claims.find(claim => claim.name === 'role').value)

    useEffect(() => {
        console.log(claims.findIndex(claim => claim.name === 'role' && claim.value === 'candidate'))
        console.log(claims.findIndex(claim => claim.name === 'role' && claim.value === 'admin'))
        console.log(update)
        console.log(claims)
        console.log(role)


        axios.get('https://localhost:7196/api/Candidate').then((response) => {
            setData(response.data);
            //console.log(data)
        }).catch(function (error) {
            console.log(error);
        });
        // if (!user) {
        //     setUser("admin");

        // }

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

        navigate(`/candidate/${candId}`);


    }

    const handleDetails = (candId) => {
        console.log("details for id  = ", candId);
        navigate(`/candidate/${candId}`);



    }

    const makeButtons = (candId) => {
        if (role === "admin") {
            return (
                <div className='d-flex gap-2'>

                    <Button onClick={() => handleEdit(candId)}>Edit</Button>
                    <Button variant="dark" onClick={() => handleDelete(candId)}>Delete</Button>
                </div>
            );
        } else if (role === "qualitycontrol") {
            return <Button onClick={() => handleEdit(candId)}>Details</Button>

        } else {
            return <div> no buttons for you</div>
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
            {role === "admin" ?
                <Button variant='dark'
                    className='d-grid gap-2 col-6 mx-auto py-2 my-2'
                    onClick={() => navigate('/candidate/create')}
                > Add a Candidate </Button>
                : null}
            <Table striped hover borderless className="text-center" id='list_of_allcands'>
                <thead >
                    <tr>
                        <th>Candidate Number</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email</th>
                        <th>Date of Birth</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody >
                    {data.map((candidate, index) =>
                        <tr key={index}>
                            <td>{candidate.candidateNumber}</td>
                            <td>{candidate.firstName}</td>
                            <td>{candidate.lastName}</td>
                            <td>{candidate.email}</td>
                            <td>{convertDateToString(candidate.dateOfBirth)}</td>
                            <td className="d-flex justify-content-center">{makeButtons(candidate.appUserId)}</td>
                        </tr>
                    )}
                </tbody>
            </Table>
        </div>
    );

}

export default CandidateList;

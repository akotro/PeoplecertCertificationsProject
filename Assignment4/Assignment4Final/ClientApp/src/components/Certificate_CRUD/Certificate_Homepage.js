import React, { Component, useState } from 'react';
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { withRouter } from './../Common/with-router';
import { BrowserRouter, Route, useParams } from "react-router-dom";
import Certificate_Create from './Certificate_Create'
import Certificate_Edit from './Certificate_Edit'
import { useNavigate } from 'react-router-dom';
import axios from 'axios';


import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faEnvelope, faTrashCan } from '@fortawesome/free-solid-svg-icons'


class Cert_homepage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: []
        }
    }

    //---------------------------------------
    //need to implement random select for examIds
    //-----------------------------------
    //const generateRandomNumber = () => {
    //    const randomNumber = Math.floor(Math.random() * questionAnswer.length);
    //    setRandomNumber(randomNumber)
    //}
    // --------------------------------

    componentDidMount() {
        // GETs all the certificates and places it is the this.state.data
        axios.get('https://localhost:7196/api/Certificates')
            .then(res => {
                if (this.props.user) {
                    // if the user is a candidate, show only active products
                    if (this.props.user.usertype === "candidate") {
                        this.setState({ data: res.data.data.filter(item => item.active === true) },
                            () => { console.log(this.state.data) }
                        );
                    } else if ((this.props.user.usertype === "placeholder")) {
                        //show data for placeholder
                    }
                } else {
                    //if none of the above, show all products
                    this.setState({ data: res.data.data })
                }
            })
            .catch(err => {
                console.error(err);
            });

        console.log(this.state.data)



        // do i need to make the special call?
        // or should back end figure out what user is making the call?
    }


    handleBuy = (id) => {
        //console.log("handle buy")
        const cert = this.state.data.filter(item => item.id === id)[0];
        //console.log(cert);
        //console.log(cert.exams[0].id);

        const examDTO = { id: cert.exams[0].id, cert }
        console.log(JSON.stringify(examDTO))

        axios.post(`https://localhost:7196/api/CandidateExam`, examDTO)
            .then(res => {
                console.log(res);
                //this.setState({ data: res.data.data });
            })
            .catch(err => {
                console.error(err);
            });
    }

    EditButton = (id) => {
        return (
            <Link to={`/admin/certificate/edit/` + id} >
                <Button className="mx-1">Edit</Button>
            </Link>
        )
    };

    handleDelete = (id) => {
        // Asks user if they are sure
        const confirmDelete = window.confirm("Are you sure you want to delete this certificate?");

        if (confirmDelete) {
            //send axios call with the request to delete using Id
            axios.delete(`https://localhost:7196/api/Certificates/${id}`)
                .then(response => {
                    //console.log(response.data.data);
                    this.setState(prevState => ({
                        data: prevState.data.filter(item => item.id !== id)
                    }));
                })
                .catch(function (error) {
                    console.log(error);
                });
        }
    };

    createCertButton = () => {
        return (
            <Link to="/admin/certificate/create">
                <Button variant='dark' > Create a new Certificate </Button>
            </Link>
        )
    };

    makebuttons = (certId) => {

        if (this.props.user) {
            if (this.props.user.usertype === "candidate") {
                return (
                    <td>
                        <div className='d-flex '>
                        <Button variant="success" onClick={() => this.handleBuy(certId)} >buy</Button>
                        <Button>details</Button>
                        </div>
                    </td>
                );
            } else if ((this.props.user.usertype === "placeholder")) {
                return (
                    <td>
                        {/*some other buttons */}
                    </td>
                );
            }
        }
        return (
            <td>
                <div className='d-flex'>
                    {this.EditButton(certId)}
                    <Button variant="dark" className="mx-1" onClick={() => this.handleDelete(certId)}>
                        {/*<FontAwesomeIcon icon={['fa', 'trash-can']} />*/}
                        {/*<FontAwesomeIcon icon="fa-solid fa-trash-can" />*/}
                        Delete
                    </Button>
                </div>
            </td>
        );

    };

    render() {
        return (
            <div className='container-fluid'>
                {this.props.user ? null : this.createCertButton()}
                <Table striped borderless hover id='list_of_allcerts'>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Description</th>
                            {/*<th>PassingMark</th>*/}
                            <th>Category</th>
                            {/*<th>Topics</th>*/}
                            {/*<th></th>*/}
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.data.map((certificate, index) => (
                            <tr key={index}>
                                <td>{certificate.title}</td>
                                <td>{certificate.description}</td>
                                {/*<td>{certificate.passingMark}</td>*/}
                                <td>{certificate.category}</td>
                                {/*<td>*/}
                                {/*    {certificate.topics.map((topic, i) => (*/}
                                {/*        <ol key={i}>{topic.name}</ol>*/}
                                {/*    ))}*/}
                                {/*</td>*/}
                                {this.makebuttons(certificate.id)}
                                <td>
                                </td>

                            </tr>

                        ))}
                    </tbody>
                </Table>
            </div>
        );
    };

}


export default withRouter(Cert_homepage);

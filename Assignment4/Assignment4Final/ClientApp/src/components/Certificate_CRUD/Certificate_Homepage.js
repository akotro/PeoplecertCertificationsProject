import React, { Component, useState } from 'react';
import { ListGroup, ListGroupItem, Button, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { BrowserRouter, Route } from "react-router-dom";
import Certificate_Create from './Certificate_Create'
import Certificate_Edit from './Certificate_Edit'
import { useNavigate } from 'react-router-dom';


class Cert_homepage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            certificates: [
                {
                    "Id": 12,
                    "Title": "this is a title",
                    "Description": "DEscription for 12",
                    "PassingMark": 65,
                    "MaxMark": 225,
                    "Category": "Coding",
                    "Active": true,
                    "Topics": [
                        {
                            "Id": 1,
                            "MaxMarks": 100,
                            "Name": "Math",
                        },
                        {
                            "Id": 2,
                            "MaxMarks": 100,
                            "Name": "Science",
                        },
                        {
                            "Id": 3,
                            "MaxMarks": 100,
                            "Name": "smething"
                        }
                    ]

                },
                {
                    "Id": 14,
                    "Title": "this is a title for 14",
                    "Description": "description of 14 ",
                    "PassingMark": 65,
                    "MaxMark": 600,
                    "Category": "Coding2",
                    "Active": false,
                    "Topics": [
                        {
                            "Id": 1,
                            "MaxMarks": 200,
                            "Name": "Math",
                        },
                        {
                            "Id": 2,
                            "MaxMarks": 200,
                            "Name": "lol",
                        },
                        {
                            "Id": 3,
                            "MaxMarks": 200,
                            "Name": "smething"
                        }
                    ]

                }
            ]

        }
    }

    // make an axios call once the page is open and fill the certificates const


    //const [certificates, setCertificates] = useState([

    //]);


    EditButton = (id) => {
        //<Route path="/admin/certificate/edit" component={<Certificate_Edit {...this.state.certificates[id]} />} />
        return (
            <Link to={`/admin/certificate/edit/${id}`} >
                <Button> edit it</Button>
            </Link>
        )

        // handle edit logic here
        // console.log(`Edit certificate with id: ${id}`);
        // return (
        //     <Link to="/admin/certificate/create"
        //         state={{ cert: certificates[id] }}
        //     >
        //         <Button> Edit </Button>

        //     </Link>
        // )
        //let props = certificates[id]
        //<Route path"/admin/certificate/create";, render={(props) => <Certificate_Create {...props }/> }/>
        //history({
        //    pathname: '',
        //    state: {object: certificates[id]}
        //});
    };


    handleDelete = (id) => {
        // handle delete logic here
        //send axios call with the request to delete using Id
        console.log(`Delete certificate with id: ${id}`)
    };

    createCertButton = () => {
        return (
            <Link to="/admin/certificate/create">
                <Button> Create a new Certificate </Button>
            </Link>
        )
    };

    render() {

        return (
            <div>
                {this.createCertButton()}
                <Table striped borderless hover id='list_of_allcerts'>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Description</th>
                            <th>PassingMark</th>
                            <th>Category</th>
                            <th>Topics</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.certificates.map((certificate, index) => (
                            <tr key={index}>
                                <td>{certificate.Title}</td>
                                <td>{certificate.Description}</td>
                                <td>{certificate.PassingMark}</td>
                                <td>{certificate.Category}</td>
                                <td>
                                    {certificate.Topics.map((topic, i) => (
                                        <ol key={i}>{topic.Name}</ol>
                                    ))}
                                </td>
                                <td>
                                    {this.EditButton(certificate.Id)}
                                    <Button variant="danger" onClick={() => this.handleDelete(certificate.Id)}>Delete</Button>

                                </td>

                            </tr>

                        ))}
                    </tbody>
                </Table>

            </div>
        );
    }

}

export default Cert_homepage;

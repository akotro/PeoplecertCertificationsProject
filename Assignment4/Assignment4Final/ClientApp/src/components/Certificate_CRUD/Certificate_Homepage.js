import React, { Component, useState } from 'react';
import { ListGroup, ListGroupItem, Button, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { withRouter } from './../Common/with-router';
import { BrowserRouter, Route, useParams } from "react-router-dom";
import Certificate_Create from './Certificate_Create'
import Certificate_Edit from './Certificate_Edit'
import { useNavigate } from 'react-router-dom';
import axios from 'axios';


class Cert_homepage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: []
        }
    }

//      {
//    "Id": 12,
//        "Title": "this is a title",
//            "Description": "DEscription for 12",
//                "PassingMark": 65,
//                    "MaxMark": 225,
//                        "Category": "Coding",
//                            "Active": true,
//                                "Topics": [
//                                    {
//                                        "Id": 1,
//                                        "MaxMarks": 100,
//                                        "Name": "Math",
//                                    },
//                                    {
//                                        "Id": 2,
//                                        "MaxMarks": 100,
//                                        "Name": "Science",
//                                    },
//                                    {
//                                        "Id": 3,
//                                        "MaxMarks": 100,
//                                        "Name": "smething"
//                                    }
//                                ]

//},
//{
//    "Id": 14,
//        "Title": "this is a title for 14",
//            "Description": "description of 14 ",
//                "PassingMark": 65,
//                    "MaxMark": 600,
//                        "Category": "Coding2",
//                            "Active": false,
//                                "Topics": [
//                                    {
//                                        "Id": 1,
//                                        "MaxMarks": 200,
//                                        "Name": "Math",
//                                    },
//                                    {
//                                        "Id": 2,
//                                        "MaxMarks": 200,
//                                        "Name": "lol",
//                                    },
//                                    {
//                                        "Id": 3,
//                                        "MaxMarks": 200,
//                                        "Name": "smething"
//                                    }
//                                ]

//}
    componentDidMount() {
        axios.get('https://localhost:7196/api/Certificates')
            .then(res => {

                console.log(res.data.data);
                this.setState({ data: res.data.data });
            })
            .catch(err => {
                console.error(err);
            });

        //console.log(this.state.data)
    }
    

    // make an axios call once the page is open and fill the certificates const


    //const [certificates, setCertificates] = useState([

    //]);


    EditButton = (id) => {
        //<Route path="/admin/certificate/edit" component={<Certificate_Edit {...this.state.certificates[id]} />} />
        return (
            <Link to={`/admin/certificate/edit/`+ id} >
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
                        {this.state.data.map((certificate, index) => (
                            <tr key={index}>
                                <td>{certificate.title}</td>
                                <td>{certificate.description}</td>
                                <td>{certificate.passingMark}</td>
                                <td>{certificate.category}</td>
                                <td>
                                    {certificate.topics.map((topic, i) => (
                                        <ol key={i}>{topic.name}</ol>
                                    ))}
                                </td>
                                <td>
                                    {this.EditButton(certificate.id)}
                                    <Button variant="danger" onClick={() => this.handleDelete(certificate.id)}>Delete</Button>

                                </td>

                            </tr>

                        ))}
                    </tbody>
                </Table>

            </div>
        );
    }

}

export default withRouter( Cert_homepage ) ;

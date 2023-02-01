import React, { Component, useState } from 'react';
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';
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

    componentDidMount() {
        // GETs all the certificates and places it is the this.state.data
        axios.get('https://localhost:7196/api/Certificates')
            .then(res => {

                console.log(res.data.data);
                this.setState({ data: res.data.data });
            })
            .catch(err => {
                console.error(err);
            });

        //if (this.props.user) {
        //    if (this.props.user.usertype === "candidate") {

        //        );
        //    } else if ((this.props.user.usertype === "placeholder")) {
        //        return (
        //            <td>
        //                {/*some other buttons */}
        //            </td>
        //        );
        //    }

        // do i need to make the special call?
        // or should back end figure out what user is making the call?
    }
    //console.log(this.state.data)


handleBuy = (id) => {
    console.log("handle buy")
    const cert = this.state.data.filter(item => item.id === id)[0];
    console.log(cert);

    axios.post(`https://localhost:7196/api/CandidateExam/${id}`)
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
            <Button>Edit</Button>
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
                    <Button variant="success" onClick={() => this.handleBuy(certId)} >buy</Button>
                    <Button>details</Button>
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
            {this.EditButton(certId)}
            <Button variant="dark" onClick={() => this.handleDelete(certId)}>Delete</Button>
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

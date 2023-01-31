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

        //console.log(this.state.data)
    }
 

    EditButton = (id) => {
        //<Route path="/admin/certificate/edit" component={<Certificate_Edit {...this.state.certificates[id]} />} />
        return (
            <Link to={`/admin/certificate/edit/`+ id} >
                <Button>Edit</Button>
            </Link>
        )
        // <Link to="/" component={<Certificate_Edit {...props.id}/>}

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
    };

    createCertButton = () => {
        return (
            <Link to="/admin/certificate/create">
                <Button variant='dark' > Create a new Certificate </Button>
            </Link>
        )
    };

    render() {
        return (
            <div className='container-fluid'>

                {this.createCertButton()}
                <Table striped borderless hover id='list_of_allcerts'>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Description</th>
                            {/*<th>PassingMark</th>*/}
                            <th>Category</th>
                            {/*<th>Topics</th>*/}
                            <th>Actions</th>
                            <th></th>
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
                                <td>
                <Stack gap={1}>
                                    {this.EditButton(certificate.id)}

                                    <Button variant="dark" onClick={() => this.handleDelete(certificate.id)}>Delete</Button>
                    </Stack>
                                </td>
                                <td>
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

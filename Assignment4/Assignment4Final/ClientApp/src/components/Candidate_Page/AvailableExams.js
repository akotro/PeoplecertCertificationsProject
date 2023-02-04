import React, { Component, useState } from 'react';
import { ListGroup, ListGroupItem, Button, Table, Row, Stack } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { withRouter } from './../Common/with-router';
import { BrowserRouter, Route, useParams } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

class AvailableExams extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: []
        }
    }

    componentDidMount() {
        axios.get('https://localhost:7196/api/CandidateExam/notTaken')
            .then(res => {
                if (this.props.user) {
                    // if the user is a candidate, show only active products
                    if (this.props.user.usertype === "candidate") {
                            this.setState({ data: res.data.data }
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
    }

    takeExam = (id) => {

    };

    render() {
        return (
            <div className='container-fluid'>
                <Table striped borderless hover>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Voucher</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.data.map((CandidateExam, index) => (
                            <tr key={index}>
                                <td>{CandidateExam.Exam.CertificateTitle}</td>
                                <td>{CandidateExam.Voucher}</td>
                                <td>
                                    <Button variant="success" onClick={() => this.takeExam(CandidateExam.id)} >Take Exam</Button>
                                </td>
                            </tr>

                        ))}
                    </tbody>
                </Table>
            </div>
        );
    };

}

export default withRouter(AvailableExams);
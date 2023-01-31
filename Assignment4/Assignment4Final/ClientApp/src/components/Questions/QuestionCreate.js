import { Form, Button, Col, Row, FloatingLabel, Stack , Table, FormGroup  } from 'react-bootstrap';

import {React,useState,useEffect,Component} from 'react';

import axios from 'axios';
import { Link } from 'react-router-dom';





class Create extends Component
{
    // axios.post("https://localhost:7196/api/Questions");
    constructor(props)
    {
        super(props);
        this.state = {
                questionText: "Test question text 1"

        }
        this.handleChange =  this.handleChange.bind(this);
        this.handleSubmit =  this.handleSubmit.bind(this);
    }
   //------------------------------------------------
    handleChange = (event) => 
    {
            this.setState({questionText:event.target.value});
    }
   //------------------------------------------------
   handleSubmit = (event) => 
   {
       alert("A text was submitted:"+this.state.questionText)
       event.preventDefault();
   }
   //------------------------------------------------
render()
{

    return(

        <Form onSubmit={this.handleSubmit}>
            <Stack gap={5}>
                <Row>
                    <Col md={10}>
                        <FormGroup>
                            <Form.Label>Questions Text2</Form.Label>
                            <Form.Control type="text"
                                    name='QuestionText'
                                    value={this.state.questionText} onChange={this.handleChange} />
                        </FormGroup>
                    </Col>

                </Row>

                <Button variant="primary" type="submit" value={"Submit"} >Create Question</Button>

            </Stack>


        </Form>
    )



}

   



}



export default Create;
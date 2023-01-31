import { Form, Button, Col, Row, FloatingLabel, Stack , Table, FormGroup,Badge } from 'react-bootstrap';

import {React,useState,useEffect,Component} from 'react';

import axios from 'axios';
import { Link } from 'react-router-dom';

import { CKEditor } from '@ckeditor/ckeditor5-react';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';


class Create extends Component
{
    // axios.post("https://localhost:7196/api/Questions");
    constructor(props)
    {
        super(props);
        this.state = {
                questionText: "Test question text 1"

        }
        // this.handleChange =  this.handleChange.bind(this);
        // this.handleSubmit =  this.handleSubmit.bind(this);
     
    }
   //------------------------------------------------
    handleChange = (event) => 
    {       
        // console.log(this.state.questionText);
        // console.log(event);
        this.setState({questionText:event});
        console.log(  this.state.questionText);
        console.log(  this.state.questionText);
        console.log(  this.state.questionText);
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
                       
                        <Form.Label >Questions Text</Form.Label>
                        <CKEditor
                                editor={ ClassicEditor }
                                data={this.state.q  }
                                onReady={ editor => { 
                                    // You can store the "editor" and use when it is needed.
                                    // console.log( 'Editor is ready to use!', editor );
                                } }
                                // onChange={ this.handleChange }
                                onChange={ ( event, editor ) => {
                                    const data = editor.getData();
                                    this.handleChange(data);
                                    // console.log( { event, editor, data } );
                                    // console.log( { event } );
                                    // console.log( {  editor } );
                                    // console.log( {  data } );

                                } }
                                // onBlur={ ( event, editor ) => {
                                //     console.log( 'Blur.', editor );
                                // } }
                                // onFocus={ ( event, editor ) => {
                                //     console.log( 'Focus.', editor );
                                // } }
                        />
                        {/* ------------------------------------------------ */}

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
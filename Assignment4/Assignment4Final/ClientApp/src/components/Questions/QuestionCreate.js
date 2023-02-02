import { Form, Button, Col, Row, FloatingLabel, Stack , Table, FormGroup,Badge } from 'react-bootstrap';
import Multiselect from 'multiselect-react-dropdown';
import {React,useState,useEffect,Component} from 'react';

import axios from 'axios';
import { Link } from 'react-router-dom';


import { CKEditor } from '@ckeditor/ckeditor5-react';
import EditorPlus from 'ckeditor5-classic-plus'; 

import Editor from './Editor';




function Create ()
{
    const [question,setQuestion] = useState(
                                                                                  {
                                                                                    "text": "string",
                                                                                    "topicId": 0,
                                                                                    "difficultyLevelId": 0,
                                                                                    "difficultyLevel": {
                                                                                                                    "id": 0,
                                                                                                                    "difficulty": 0
                                                                                                                  },
                                                                                    "options": [ ]
                                                                                  }
                                                                      ); 
    const [allTopics,setAllTopics] = useState([]);

    const[options,setOptions] = useState([
                                                                                      { 
                                                                                      "id": 0,  
                                                                                      "text": "",
                                                                                      "isCorrect": false,},
                                                                                      { 
                                                                                        "id": 1,  
                                                                                        "text": "",
                                                                                        "isCorrect": false,},
                                                                                        { 
                                                                                          "id": 2,  
                                                                                          "text": "",
                                                                                          "isCorrect": false,},
                                                                                          { 
                                                                                            "id": 3,  
                                                                                            "text": "",
                                                                                            "isCorrect": true,},
                                                                  ]);

   //------------------------------------------------HANDLE CHANGE
    const handleChange = (data,element) => 
    {       
                        //------------------------------------------------
                      if(element ==="QuestionText")
                      {
                          setQuestion( 
                            previousQuestion => 
                            {
                                return { ...previousQuestion, text: data };
                              },
                          ); 
                        }
                        //------------------------------------------------
                        else if(element ==="Option0")//--------------------->>>>>>  
                        {
                              setOptions( options.map( option => 
                                                  {
                                                    if(option.id === 0)
                                                    {
                                                      return { ...option, text: data };
                                                    }
                                                    return option;
                                                  }
                                              ));
                        }
                        else if(element ==="Option1")//--------------------->>>>>>  
                        {
                                        setOptions( options.map( option => 
                                                                        {
                                                                          if(option.id === 1)
                                                                          {
                                                                            return { ...option, text: data };
                                                                          }
                                                                          return option;
                                                                        }
                                                            ));
                        }
                        else if(element ==="Option2")//--------------------->>>>>>  
                        {
                                        setOptions( options.map( option => 
                                                                        {
                                                                          if(option.id === 2)
                                                                          {
                                                                            return { ...option, text: data };
                                                                          }
                                                                          return option;
                                                                        }
                                                            ));
                        }
                        else if(element ==="Option3")//--------------------->>>>>>  
                        {
                                        setOptions( options.map( option => 
                                                                        {
                                                                          if(option.id === 3)
                                                                          {
                                                                            return { ...option, text: data };
                                                                          }
                                                                          return option;
                                                                        }
                                                            ));
                        }
        }
        
   
   //------------------------------------------------HANDLE SUBMIT 
   const  handleSubmit = (event) => {
                                                                            event.preventDefault();
                                                                            console.log("On submit");

                                                                            console.log(options);
                                                                            setQuestion (previousQuestion =>
                                                                                                      {
                                                                                                        return { ...previousQuestion, options: options }; 
                                                                                                      }
                                                                                                 );
                                                                            console.log(question);
                                                                            axios.post('https://localhost:7196/api/Questions',question )
                                                                                .then(function (response) {
                                                                                    console.log("Inside response");
                                                                                    console.log(response);
                                                                                })
                                                                                .catch(function (error) {
                                                                                    console.log("Inside error")
                                                                                    console.log(error);
                                                                                    
                                                                                });
                                                            }
   //------------------------------------------------ON SELECT (MULTISELECT)
    //adds the values selected to the list of topics 

        const  onSelect = (selectedTopics) => {
             
                              
          console.log(selectedTopics);


              setQuestion(previousQuestion=> ({
                                                                                ...previousQuestion,
                                                                                topicId: selectedTopics[0].id,
                                                                        }
                                                                       )
                                );


                               
                                console.log(question);
              
              }
    

  
   //------------------------------------------------
        useEffect(
                    () =>
                              {       
                                      console.log("componentDidMount in useEffect");
                                      // GET all the topics and places int the this.state.allTopics
                                      axios.get(`https://localhost:7196/api/Topics`)
                                          .then(res => {
                                              setAllTopics( res.data.data );
                                          })
                                          .catch(err => {
                                              console.error(err.response.data);
                                          });
                                  },[]
            )
   //------------------------------------------------
   //------------------------------------------------
    return (
      <Form onSubmit={handleSubmit}>
        <Stack gap={5}>
                                <Row>             {/* Questions text */}
                                  <Col md={7}>
                                    <FormGroup>
                                      <Form.Label>Questions Text</Form.Label>
                                                <Editor handleChange={handleChange} element={"QuestionText"} />
                                    </FormGroup>
                                  </Col>

                                  <Col md={3}>            {/* MULTISELECT */}
                                    <Form.Group>
                                      <Form.Label>Topics</Form.Label>
                                              <Multiselect
                                                        name="topics"
                                                        options={allTopics} // Options to display in the dropdown
                                                        onSelect={onSelect} // Function will trigger on select event
                                                        // onRemove={onRemove} // Function will trigger on remove event
                                                        displayValue="name" // Property name to display in the dropdown options
                                                        placeholder="Please select as many Topics as needed for the certificate"
                                                        hidePlaceholder="true "
                                                        showCheckbox="true"
                                                        closeIcon="cancel"
                                                        showArrow="true"
                                                        isMulti={true}
                                                        singleSelect={true} //Only one topic can be selected
                                                        // defaultValue={this.state.question.topics}
                                                        onChange={handleChange}
                                              />
                                    </Form.Group>
                                  </Col>

                                </Row>

                                                        <Row>     {/* 1st Option */}
                                                                          <Col md={7}>
                                                                            <FormGroup>
                                                                              <Form.Label>First Option</Form.Label>
                                                                         {/* Editor */}
                                                                              <Editor handleChange={handleChange} element={"Option0"}  />
                                                                            </FormGroup>
                                                                          </Col>
                                                        </Row>
                                                        <Row>     {/* 2nd Option */}
                                                                          <Col md={7}>
                                                                            <FormGroup>
                                                                              <Form.Label>Second Option</Form.Label>
                                                                         {/* Editor */}
                                                                              <Editor handleChange={handleChange} element={"Option1"} />
                                                                            </FormGroup>
                                                                          </Col>
                                                        </Row>
                                                        <Row>     {/* 3d Option */}
                                                                          <Col md={7}>
                                                                            <FormGroup>
                                                                              <Form.Label>Third Option</Form.Label>
                                                                         {/* Editor */}
                                                                              <Editor handleChange={handleChange} element={"Option2"}  />
                                                                            </FormGroup>
                                                                          </Col>
                                                        </Row>
                                                        <Row>     {/* 4th Option */}
                                                                          <Col md={7}>
                                                                            <FormGroup>
                                                                              <Form.Label>Fourth Option</Form.Label>
                                                                         {/* Editor */}
                                                                              <Editor handleChange={handleChange} element={"Option3"}  />
                                                                            </FormGroup>
                                                                          </Col>
                                                        </Row>
                                                                                                                             
        
        
        <Row>

          <Col md={30}>
            <Button variant="primary" type="submit" value={"Submit"}>
              Create Question
            </Button>
          </Col>
        </Row>

        </Stack>
      </Form>
    );
                                          
                                              }
                                              


   







export default Create;
import { Form, Button, Col, Row, FloatingLabel, Stack , Table  } from 'react-bootstrap';

import {React,useState,useEffect} from 'react';

import axios from 'axios';
import { Link } from 'react-router-dom';








function Questions()
{
    const[data,setData] = useState([]);

    // let response = axios.get('https://localhost:7196/api/Questions');
    // var data = [];

    useEffect(() => {
        axios.get('https://localhost:7196/api/Questions').then((response) => {  setData(response.data.data);
        });
      }, []);
   
      console.log("Testing in Questions");
      console.log(data[0]);
      // resp.data.data[0].options[0].text

      function Replace(temp)
      {
        let finalText = temp.replace(<>,"");
        return finalText

      }

    return (

        <div className='container-fluid'>
            <Link to="/admin/Questions/QuestionCreate"><Button variant='dark'>Create new Question</Button></Link> 
            <div>
                <Table hover striped >
                                <thead>
                                    <th scope='Col'>Id</th>
                                    <th scope='col'>MainText</th>
                                    <th scope='col'>Topic</th>
                                    <th scope='col'></th>
                                    <th scope='col'></th>
                                </thead>

                                <tbody>
                        
                                        {data.map((item,index) => (
                                            <tr>
                                                <td>{item.id}</td>
                                                <td>{item.text}</td>
                                                <td>{item.topic.name}</td>
                                                <td>
                                                        <Link to="/admin/Questions/QuestionEdit"><Button>Edit</Button></Link>  
                                                </td>
                                                <td>
                                                <Link to=""><Button variant='dark'>Delete</Button></Link> 

                                                </td>
                                            </tr>
                                            
                                            ))}
                                </tbody>
                    </Table>
            </div>
          
              
        </div>
    )
    


}



















export default Questions;
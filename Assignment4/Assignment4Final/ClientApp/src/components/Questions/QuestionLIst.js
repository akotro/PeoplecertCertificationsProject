import { Form, Button, Col, Row, FloatingLabel, Stack , Table  } from 'react-bootstrap';

import {React,useState,useEffect} from 'react';

import axios from 'axios';



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

    return (

        <div className='container-fluid'>
            <Table hover striped >
                <thead>
                    <th scope='Col'>Id</th>
                    <th scope='col'>MainText</th>
                    <th scope='col'>Topic</th>
                    <th scope='col'>--------</th>
                </thead>


                        {data.map((item,index) => (
                            <tr>
                            <td>{item.id}</td>
                            <td>{item.text}</td>
                            <td>{item.topic.name}</td>
                            <td>
                                <button >Edit</button>
                                <button >Delete</button>


                            </td>
                            
                            
                            
                            
                            
                            
                            
                            
                            </tr>
                            
                            ))}
            </Table>
                <button >Test_Button</button>
        </div>
    )
    


}




export default Questions;
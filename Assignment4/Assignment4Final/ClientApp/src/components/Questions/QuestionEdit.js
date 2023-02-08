import { Form, Button, Col, Row, FloatingLabel, Stack , Table  } from 'react-bootstrap';

import {React,useState,useEffect,Component }from 'react';

import axios from 'axios';
import { useLocation } from 'react-router-dom';
import { useParams } from 'react-router-dom';

export default function QuestionEdit(event, name) {

    const [data, setData] = useState([]);
    // const [question, setQuestion] =useState({
    //     text: "string",
    //     topicId: 0,
    //     difficultyLevelId: 0,
    
    //     options: [],
    //   });
       //------------------------------------------------Topics state
  const [allTopics, setAllTopics] = useState([]);

    const location = useLocation();
    const { questionIndex } = location.state;
    console.log(questionIndex);
    //Same outcome as above------------------------------------------------
    // const _params = useParams();
    // const params = _params.id;
    // console.log(params);
//--------------------------------------------------



//------------------------------------------------//GET ALL TOPICS AND DIFFICULTY LEVELS
const url = "https://localhost:7196/api/Questions/" + questionIndex;
useEffect(() => { 
    axios
      .get(`https://localhost:7196/api/Topics`)
      .then((res) => {
        setAllTopics(res.data.data);
      })
      .catch((err) => {
        console.error(err.response.data);
      });

    }

















    return 
    (

        <div>


        <p>test</p>






        </div>
    )


}
            


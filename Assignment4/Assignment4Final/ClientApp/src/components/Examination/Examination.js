import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import Pagination from 'react-bootstrap/Pagination';
import PageItem from 'react-bootstrap/PageItem'
import axios from 'axios';

function Examination(props) {

    const params = useParams();
    const [data, setData] = useState([]);
    const [user, setUser] = useState();
    const [currentPage, setCurrentPage] = useState(1);
    let navigate = useNavigate();

    useEffect(() => {
        axios.get('https://localhost:7196/api/CandidateExam/StartExam').then((response) => {
            setData(response.data);
        }).catch(function (error) {
            console.log(error);
        });
        if (!user) {
            setUser("admin");
        }
    }, []);

    return (
        <>
        <Pagination
          className="pagination-bar"
          currentPage={1}
          totalCount={data.length}
          pageSize={10}
          onPageChange={page => setCurrentPage(1)}
        />
      </>
    );
};

export default Examination;
import React, { useState, useEffect } from 'react';
import axios from 'axios'
import { Button } from 'react-bootstrap'
import Cert_homepage from '../Certificate_CRUD/Certificate_Homepage'


const CandidateHomepage = () => {
    //const [products, setProducts] = useState([]);

    //useEffect(() => {
    //    const fetchCertificates = async () => {
    //        try {
    //            const response = await axios.get('https://localhost:7196/api/Certificates');
    //            setProducts(response.data.data);
    //        } catch (error) {
    //            console.error(error);
    //        }
    //    };
    //    fetchCertificates();
    //});


    const print = () => {
        //console.log(products);
    }
    return (
        <div>
            <div>
                <Cert_homepage user={{ usertype:"candidate", userId:"someId" }} />
            </div>
        </div>
    )
}

export default CandidateHomepage;

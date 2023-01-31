import React, { useState } from 'react';

const CandidateHomepage = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        const fetchCertificates = async () => {
            try {
                const response = await axios.get('https://localhost:7196/api/Certificates');
                setProducts(response.data.data);
            } catch (error) {
                console.error(error);
            }
        };
        fetchCertificates();
    }, []);

    return (
        <div>
            List of certs
        </div>
    )
}

import axios from "axios"
import { useState, useEffect, useContext } from "react";
import { AuthenticationContext } from '../auth/AuthenticationContext'


function AssignToMarker() {
    const { update, claims } = useContext(AuthenticationContext);
    const [markers, setMarkers] = useState([]);
    const [exams, setExams] = useState([]);

    useEffect(() => {
        // console.log(data)
        //axios call for markers
        //axios call for exams

        // axios.get('https://localhost:7196/api/Markers')
        // .then(res => {
        //             // if the user is a candidate, show only active products
        //             console.log(res.data.data.filter(item => item.active === true))
        //             setData([...res.data.data.filter(item => item.active === true)])
        //             // () => { console.log(data) })
        //             console.log(res.data.data)
        //             //if none of the above, show all products
        //             setData(res.data.data)
        //             console.log(res.data.data)
        //     })
        //     .catch(err => {
        //         console.error(err);
        //     });

        //     console.log(data)
    }, [])

    const handleChange = () => {
        // edit the CandidateExam to add the Marker ID
    }

    const handleSubmit = () => {
        // send put request with changed data
    }

    return (
        <div>
        <h1>AssignToMarker</h1>
            {/* have 2 dropdown menus here */}
        </div>
    );
}

export default AssignToMarker

import React from 'react';
import ReactDOM from 'react-dom';
import { useLocation, useNavigate } from "react-router-dom";
import { Button, Navbar, Table } from 'react-bootstrap';
import BackButton from '../Common/Back'
 

import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
 




export default function Results() 
{

    const location = useLocation();
    const navigate = useNavigate();
    const incomingData = location.state.data;
    // console.log(incomingData);

  
     // ----------------------------------------------------------------------Create Document Component
const handleClick = () => 
{
    console.log("Clicked");
//----------------------PDF-------------------------------------------->>>>>>>>>>>
var doc = new jsPDF();

var element = (<div><h1>Testing</h1></div>);

var wrapper = document.createElement("div");
document.body.appendChild(wrapper);

var newElement = new DOMParser().parseFromString(element, 'text/html').body.firstChild;
wrapper.appendChild(newElement);

$(document).ready(function() {
  html2canvas(newElement).then(canvas => {
      var imgData = canvas.toDataURL("image/jpeg", 1.0);
      doc.addImage(imgData, 'JPEG', 15, 15, 170, 0);
      doc.save('single-page-pdf.pdf');
  });
});














}


// ---------------------------------------------------------------------------------    
    return (


      
        <div id='jsPdf' >
            <h4>Results</h4>
            <div className='container-fluid'>
                <Table>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Exam Date</th>
                            <th>Max Score</th>
                            <th>Passing Score</th>
                            <th>My Score</th>
                            <th>My Percentage Score</th>
                            <th>Result</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>{incomingData.exam.certificateTitle}</td>
                            <td>{incomingData.examDate}</td>
                            <td>{incomingData.maxScore}</td>
                            <td>{incomingData.exam.passMark}</td>
                            <td>{incomingData.candidateScore}</td>
                            <td>{incomingData.percentScore} %</td>
                            <td style={{ color: incomingData.result ? 'green' : 'red' }}>
                                {incomingData.result ? "Passed" : "Failed"}
                            </td>
                        </tr>
                    </tbody>
                </Table>
                <Button onClick={handleClick}>Download Results</Button>
                {location.state && location.state.from === '/candidate/availableexams' && (
                    <BackButton />
                )}
            </div>
            {/* <div>PDF Output <button onClick={handleClick}>Download</button></div> */}
            <iframe width="100%" height="800px" title='Testing!!!'>
            </iframe>
        
        </div>
    )


  
}


  

 



















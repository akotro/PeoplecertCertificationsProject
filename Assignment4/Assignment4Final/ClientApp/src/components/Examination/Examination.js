import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import axios from 'axios';

export default function Examination(props) {

    const params = useParams();
    // const [candidateExam, setCandidateExam] = useState({ exam: { questions: [] } })
    const [user, setUser] = useState();
    const candExamId = params.id;

    const [candidateExam, setCandidateExam] = useState({
        exam: { questions: [] },
        CandidateExamAnswers: { ChoosenOptions: [] },
    });
    const [selectedOption, setSelectedOption] = useState();

    useEffect(() => {
        axios.put(`https://localhost:7196/api/CandidateExam/StartExam/${candExamId}`).then((response) => {
            setCandidateExam(response.data);
            console.log(response.data);
        }).catch(function (error) {
            console.log(error);
        });
        if (!user) {
            setUser("admin");
        }
    }, []);

    function Replace(temp) {
        var parser = new DOMParser();

        var doc = parser.parseFromString(temp, 'text/html');

        return doc.body.innerText;
    }

    const handleOptionChange = (event, questionIndex) => {
        const chosenOption = event.target.value;
        const updatedCandidateExamAnswers = candidateExam.candidateExamAnswers.map((answer, index) => {
            if (index === questionIndex) {
                return { ...answer, chosenOption };
            }
            return answer;
        });
        setCandidateExam({ ...candidateExam, candidateExamAnswers: updatedCandidateExamAnswers });
    };

    // Note(vmavraganis): Code used to slice the array of questions and make them 1 per page (with each question having an array of their options)
    const [currentPage, setCurrentPage] = useState(1);
    const questionsPerPage = 1;
    const questions = candidateExam?.exam?.questions;
    const totalPages = questions ? Math.ceil(questions.length / questionsPerPage) : 0;

    const indexOfLastQuestion = currentPage * questionsPerPage;
    const indexOfFirstQuestion = indexOfLastQuestion - questionsPerPage;
    const currentQuestions = questions ? questions.slice(indexOfFirstQuestion, indexOfLastQuestion) : [];

    return (
        <div>
            <h1>Question {currentPage}</h1>
            <hr></hr>

            {currentQuestions.map((question, index) => (
                <div key={index}>

                    <h3>{Replace(question.text)}</h3>

                    <ol>
                        {question.options.map((option, index) => (
                            <li key={option.text}>{Replace(option.text)}</li>
                        ))}
                    </ol>

                    <select
                        id="option"
                        value={candidateExam?.candidateExamAnswers[indexOfFirstQuestion]?.chosenOption || ""}
                        onChange={(event) => handleOptionChange(event, indexOfFirstQuestion)}
                    >
                        <option value="" disabled>Choose option</option>
                        {question.options.map((option, index) => (
                            <option key={index} value={option.text}>
                                {index + 1}
                            </option>
                        ))}
                    </select>

                </div>
            ))}

            <hr></hr>

            <div>
                {currentPage !== 1 && <button onClick={() => setCurrentPage(currentPage - 1)}>Previous</button>}
                &nbsp;
                {currentPage < totalPages && <button onClick={() => setCurrentPage(currentPage + 1)}>Next</button>}
            </div>
        </div>
    );
};


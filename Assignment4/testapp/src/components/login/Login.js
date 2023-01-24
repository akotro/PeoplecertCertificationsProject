import React from 'react';
import SideBar from '../sidebar/SideBar';
import { useState } from 'react';
import axios from 'axios';

function Login(props) {

    const [error, setError] = useState(null)
    const message = props.message
    const userRole = props.userRole
    const [inputFields, setInputFields] = useState([
        { username: '', password: '' }
    ])

    const handleFormChange = (index, event) => {
        let data = [...inputFields];
        data[index][event.target.name] = event.target.value;
        setInputFields(data)
        console.log(inputFields)
    }

    const submit = (e) => {
        e.preventDefault();
        // to test out why this will not print 
        console.log(inputFields) // here for testing 
        axios.post('api/users/', inputFields).then(response => {
            console.log(response);
            if (response.data.status === 'success') {
                if (response.data.userRole === 'admin') {
                    return <SideBar userRole={'admin'} />
                } else if (response.data.userRole === 'qc') {
                    return <SideBar userRole={'qc'} />
                } else if (response.data.userRole === 'marker') {
                    return <SideBar userRole={'marker'} />
                } else {
                    return <SideBar userRole={'candidate'} />
                }
            } else {
                return <Login message={"Log in Failed"} />
            }
        }
        ).catch(error => {
            // console.log(error)// for debugging 
            console.log(error)
            if (error.response.status === 404) {
                setError("Server not found");
                // return <SideBar />
            }
        });
    }

    // <SideBar />
    return (
        <div className="Login" id='login'>
            <form onSubmit={submit}>
                {inputFields.map((input, index) => {
                    return (
                        <div key={index}>
                            <div className='mb-3 row' >
                                <label htmlFor='username' className='col-sm-2 col-form-label'>Username</label>
                                <div className='col-sm-10'  >
                                    <input
                                        id='username'
                                        key={index}
                                        name='username'
                                        className='form-control'
                                        placeholder='email@example.com'
                                        value={input.username}
                                        onChange={event => handleFormChange(index, event)}
                                    />
                                </div>
                                <label htmlFor='password' className='col-sm-2 col-form-label'>Password</label>
                                <div className='col-sm-10'>
                                    <input
                                        id='password'
                                        key={index}
                                        name='password'
                                        type='password'
                                        className='form-control'
                                        value={input.password}
                                        onChange={event => handleFormChange(index, event)}
                                    />
                                </div>
                            </div>
                        </div>
                    )
                })}
            </form>
            <div className="col-auto">
                <button onClick={submit} className='btn btn-primary mb-3'>Login !</button>
            </div>
            {/* <button onClick={submit}>Submit</button> */}
            {/* <div>{message && message}</div> */}
            <div>{error}</div>
            <SideBar />
        </div>
    );
}

export default Login;

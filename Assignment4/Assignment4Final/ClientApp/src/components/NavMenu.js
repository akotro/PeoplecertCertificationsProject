import React, { Component, useState, useContext, useEffect } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { NavDropdown, Nav, Button } from 'react-bootstrap';
import { AuthenticationContext } from "./auth/AuthenticationContext";
import Authorized from './auth/Authorized';

import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';
import { logout } from './auth/handleJWT';
import { useNavigate } from 'react-router-dom';

//import { TiHome } from "react-icons/ti";

function NavMenu() {
    // static displayName = NavMenu.name;
    const { update, claims } = useContext(AuthenticationContext);
    const [claim, setClaim] = useState(claims.filter(x => x.name === "role")[0]?.value);

    const getUserEmail = () => {
        return claims.filter(x => x.name === "email")[0]?.value;
    }



    const [collapsed, setCollapsed] = useState(true);

    const toggleNavbar = () => {
        setCollapsed(!collapsed);
    }


    const navForRole = (claims) => {
        // edw elega na kanei to check kanei return to component
    }


    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
                <NavbarBrand tag={Link} to="/">HomePage</NavbarBrand>
                <NavbarToggler onClick={toggleNavbar} className="mr-2" />


                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                    <ul className="navbar-nav flex-grow">

                        <div className="d-flex">
                            <Authorized
                                role="admin"
                                authorized={<>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/certificate">Certificates</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/Questions/QuestionHomePage">Questions</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/candidate">CandidatesCrud</NavLink>
                                    </NavItem>
                                </>}
                            />

                            <Authorized
                                role="candidate"
                                authorized={<>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/certificate">Certificates</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/Questions/QuestionHomePage">Questions</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/candidate">Candidates</NavLink>
                                    </NavItem>
                                </>}
                            />

                            <Authorized
                                role="qualitycontrol"
                                authorized={<>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/certificate">Certificates</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/Questions/QuestionHomePage">Questions</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/candidate">Candidates</NavLink>
                                    </NavItem>
                                </>}
                            />
                            <Authorized
                                role="marker"
                                authorized={<>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/certificate">marker links</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/Questions/QuestionHomePage">i need to make </NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/candidate">Candidates</NavLink>
                                    </NavItem>
                                </>}
                            />

                            <Authorized
                                authorized={<>
                                    <span className="nav-link">Hello, {getUserEmail()}</span>
                                    <Button
                                        onClick={() => {
                                            logout();
                                            update([]);
                                        }}
                                        className="nav-link btn btn-link"
                                    >Log out</Button>
                                </>}
                                notAuthorized={<>
                                    <Link to="/register"
                                        className="nav-link btn btn-link">Register</Link>
                                    <Link to="/login"
                                        className="nav-link btn btn-link">Login</Link>
                                </>}
                            />
                        </div>


                        {/* 
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/login">MyLogin</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/admin/certificate">Certificates</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/admin/Questions/QuestionHomePage">Questions</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/admin/candidate">CandidatesCrud</NavLink>
                            </NavItem>
                            <NavItem>
                                <Button onClick={() => logout(useNavigate)}>Log me out</Button>
                            </NavItem>
                            <NavDropdown title="Candidate">
                                <NavDropdown.Item>
                                    <NavLink tag={Link} className="text-dark" to="/candidate">Candidate Homepage</NavLink>
                                </NavDropdown.Item>
                                <NavDropdown.Item>
                                    <NavLink tag={Link} className="text-dark" to="/candidate/AvailableExams">Available Exams</NavLink>
                                </NavDropdown.Item>
                            </NavDropdown> */}
                        {/* <LoginMenu>
                            </LoginMenu> */}
                    </ul>
                </Collapse>
            </Navbar>
        </header>
    );
}
export default NavMenu;

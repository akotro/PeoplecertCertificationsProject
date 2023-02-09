import React, { useState, useContext } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Button } from 'react-bootstrap';
import { AuthenticationContext } from "./auth/AuthenticationContext";
import Authorized from "./auth/Authorized";

import { Link, useNavigate } from 'react-router-dom';
import './NavMenu.css';
import { logout } from './auth/handleJWT';

//import { TiHome } from "react-icons/ti";

function NavMenu() {
    const navigate = useNavigate();
    const { update, claims } = useContext(AuthenticationContext);
    const [claim, setClaim] = useState(claims.filter(x => x.name === "role")[0]?.value);

  const getUserEmail = () => {
    return claims.filter((x) => x.name === "email")[0]?.value;
  };

    const [collapsed, setCollapsed] = useState(true);

  const toggleNavbar = () => {
    setCollapsed(!collapsed);
  };

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
                                        <NavLink tag={Link} className="text-dark" to="/marker">mark an exam</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/assigntomarker">Assign</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/certificate">Certificates</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/questions">Questions</NavLink>
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
                                        <NavLink tag={Link} className="text-dark" to="/certificate">Get started!</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/candidate/availableexams">Available Exams</NavLink>
                                    </NavItem>
                                </>}
                            />

                            <Authorized
                                role="qualitycontrol"
                                authorized={<>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/certificate">List of All Certificates</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/questions">List of All Questions</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/candidate">List of All Candidates</NavLink>
                                    </NavItem>
                                </>}
                            />
                            <Authorized
                                role="marker"
                                authorized={<>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/marker">Things</NavLink>
                                    </NavItem>
                                </>}
                            />

                            <Authorized
                                authorized={<>
                                    <span className="nav-link">Hello, {getUserEmail()}</span>
                                    <Button
                                        onClick={() => {
                                            navigate('/')
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
                    </ul>
                </Collapse>
            </Navbar>
        </header>
    );
}
export default NavMenu;

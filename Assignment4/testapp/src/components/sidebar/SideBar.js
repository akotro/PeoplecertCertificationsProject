import React from 'react';
import './SideBar.css'
// Bootstrap CSS
import "bootstrap/dist/css/bootstrap.min.css";
// Bootstrap Bundle JS
import "bootstrap/dist/js/bootstrap.bundle.min";

class SideBar extends React.Component {

    // constructor(props){
    //     super(props);
    //         this.state.userType = "none";
    //     }

    makelist(num) {
        const list = [];

        for (let i = 0; i < num; i++) {
            list.push(i)
        }
        return (
            <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                {list.map((item, index) => <li key={index}><a href="#" className="link-dark rounded">{item}</a></li>)}

            </ul>
        )
    }

    render() {
        return (
            <div id='sidebar'>
                <div className="flex-shrink-0 p-1 col-2" >
                    <a href="/" className="d-flex align-items-center p-1 m-1 link-dark text-decoration-none border-bottom">
                        <span className="fs-5 fw-semibold">Assignemnt4_Final</span>
                    </a>
                    <ul className="list-unstyled align-left ps-0">
                        <li className="mb-1">
                            <button className="btn btn-toggle align-items-left rounded collapsed" data-bs-toggle="collapse" data-bs-target="#home-collapse" aria-expanded="true">
                                Home
                            </button>
                            <div className="collapse show" id="home-collapse">
                                <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                    <li><a href="#" className="link-dark rounded">Overview</a></li>
                                    <li><a href="#" className="link-dark rounded">Updates</a></li>
                                    <li><a href="#" className="link-dark rounded">Reports</a></li>
                                </ul>
                            </div>
                        </li>
                        <li className="mb-1">
                            <button className="btn btn-toggle align-items-center rounded collapsed" data-bs-toggle="collapse" data-bs-target="#dashboard-collapse" aria-expanded="false">
                                Dashboard
                            </button>
                            <div className="collapse" id="dashboard-collapse">
                                <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                    <li><a href="#" className="link-dark rounded">Overview</a></li>
                                    <li><a href="#" className="link-dark rounded">Weekly</a></li>
                                    <li><a href="#" className="link-dark rounded">Monthly</a></li>
                                    <li><a href="#" className="link-dark rounded">Annually</a></li>
                                </ul>
                            </div>
                        </li>
                        <li className="mb-1">
                            <button className="btn btn-toggle align-items-center rounded collapsed" data-bs-toggle="collapse" data-bs-target="#orders-collapse" aria-expanded="false">
                                Orders
                            </button>
                            <div className="collapse" id="orders-collapse">
                                <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                    <li><a href="#" className="link-dark rounded">New</a></li>
                                    <li><a href="#" className="link-dark rounded">Processed</a></li>
                                    <li><a href="#" className="link-dark rounded">Shipped</a></li>
                                    <li><a href="#" className="link-dark rounded">Returned</a></li>
                                </ul>
                            </div>
                        </li>
                        <li className="border-top my-3"></li>
                        <li className="mb-1">
                            <button className="btn btn-toggle align-items-center rounded collapsed" data-bs-toggle="collapse" data-bs-target="#account-collapse" aria-expanded="false">
                                Account
                            </button>
                            <div className="collapse" id="account-collapse">
                                <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                    {this.makelist(8)}
                                    <li><a href="#" className="link-dark rounded">New...</a></li>
                                    <li><a href="#" className="link-dark rounded">Profile</a></li>
                                    <li><a href="#" className="link-dark rounded">Settings</a></li>
                                    <li><a href="#" className="link-dark rounded">Sign out</a></li>
                                </ul>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        );
    }
}


export default SideBar;


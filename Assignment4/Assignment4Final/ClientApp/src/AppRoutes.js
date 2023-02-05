import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import Home from "./components/Home";

import CreateCertificateForm from './components/Certificate_CRUD/Certificate_Create'
import EditCertificateForm from './components/Certificate_CRUD/Certificate_Edit'
import Cert_homepage from './components/Certificate_CRUD/Certificate_Homepage'
import NotFound from './components/Common/NotFound';
import NotAuth from './components/auth/NotAuth';

import Questions from './components/Questions/QuestionHomePage';
import QuestionEdit from './components/Questions/QuestionEdit';
import QuestionCreate from './components/Questions/QuestionCreate';

import CandidateList from './components/Candidate_CRUD/CandidateList'
import CandidateEdit from "./components/Candidate_CRUD/CandidateEdit";

import CandidateHomepage from './components/Candidate_Page/CandidateHomepage';
import AvailableExams from './components/Candidate_Page/AvailableExams';
import Examination from './components/Examination/Examination';

import Login from './components/auth/Login'
import Register from './components/auth/Register'

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/login',
        element: <Login />
    },
    {
        path: '/register',
        element: <Register />
    },
    {
        path: '/certificate',
        needsAdmin: true,
        needsQc: true,
        needsCand: true,
        element: <Cert_homepage />
    },
    {
        path: '/certificate/create',
        needsAdmin: true,
        element: <CreateCertificateForm />
    },

    {
        path: '/certificate/edit/:id',
        needsAdmin: true,
        element: <EditCertificateForm />
    },
    //-----------------Questions-------------------
    {
        path: '/Questions/QuestionHomePage',
        needsAdmin: true,
        needsQc: true,
        element: <Questions />
    },
    {
        path: '/Questions/QuestionEdit',
        needsAdmin: true,
        element: <QuestionEdit />
    },
    {
        path: '/Questions/QuestionCreate',
        needsAdmin: true,
        element: <QuestionCreate />
    },

    // -----------------Candidate-------------------
    {
        path: '/candidate',
        needsAdmin: true,
        needsQc: true,

        element: <CandidateList />
    },
    {
        path: '/candidate/create',
        // needsAdmin: true,
        // needsCand:true,
        element: <CandidateEdit />
    },
    {
        path: '/candidate/:id',
        needsAdmin: true,
        element: <CandidateEdit />
    },
    {
        path: '/candidate',
        // requireAuth: true,
        element: <CandidateHomepage />
    },
    {
        path: '/candidate/AvailableExams',
        needsCand: true,

        element: <AvailableExams />
    },
    // -----------------Candidate-------------------
    {
        path: '/candidate/Examination/:id',
        needsCand: true,
        element: <Examination />
    },

    //this needs to stay as the last path
    {
        path: '/notauth',
        element: <NotAuth />
    },
    {
        path: '*',
        element: <NotFound />
    },
    // ...ApiAuthorzationRoutes
];

export default AppRoutes;

import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import CreateCertificateForm from './components/Certificate_CRUD/Certificate_Create'
import EditCertificateForm from './components/Certificate_CRUD/Certificate_Edit'
import Cert_homepage from './components/Certificate_CRUD/Certificate_Homepage'

import Questions from './components/Questions/QuestionHomePage';
import Edit from './components/Questions/QuestionEdit';
import Create from './components/Questions/QuestionCreate';

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        requireAuth: true,
        element: <FetchData />
    },
    {
        path: '/admin/certificate',
        //requireAuth: true,
        element: <Cert_homepage />
    },
    {
        path: '/admin/certificate/create',
        // requireAuth: true,
        element: <CreateCertificateForm />
    },

    {
        path: '/admin/certificate/edit/:id',
        // requireAuth: true,
        element: <EditCertificateForm />
    },
    {
        path: '/admin/Questions/QuestionHomePage',
        // requireAuth: true,
        element: <Questions />
    }, 
    {
        path: '/admin/Questions/QuestionEdit',
        // requireAuth: true,
        element: <Edit />
    },
    {
        path: '/admin/Questions/QuestionCreate',
        // requireAuth: true,
        element: <Create />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;

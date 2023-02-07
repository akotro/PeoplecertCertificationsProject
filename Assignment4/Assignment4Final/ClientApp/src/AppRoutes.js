import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import Home from "./components/Home";

import CertificateForm from './components/Certificate_CRUD/CertificateForm'
import CertificateList from './components/Certificate_CRUD/CertificateList'
import NotFound from './components/Common/NotFound';
import NotAuth from './components/auth/NotAuth';

import Questions from "./components/Questions/QuestionHomePage";
import QuestionEdit from "./components/Questions/QuestionEdit";
import QuestionCreate from "./components/Questions/QuestionCreate";

import CandidateList from "./components/Candidate_CRUD/CandidateList";
import CandidateEdit from "./components/Candidate_CRUD/CandidateEdit";

import CandidateHomepage from "./components/Candidate_Page/CandidateHomepage";
import AvailableExams from "./components/Candidate_Page/AvailableExams";
import Examination from "./components/Examination/Examination";
import ExamList from "./components/Exam_CRUD/ExamList";
import ExamQuestionList from "./components/Exam_CRUD/ExamQuestionList";

import Login from './components/auth/Login'
import Register from './components/auth/Register'
import AddQuestionToExam from './components/Exam_CRUD/AddQuestionToExam';

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/login",
    element: <Login />,
  },
  {
    path: "/register",
    element: <Register />,
  },
  {
    path: "/certificate",
    needsAdmin: true,
    needsQc: true,
    needsCand: true,
    element: <CertificateList />,
  },
  {
    path: "/certificate/create",
    needsAdmin: true,
    element: <CertificateForm />,
  },
  {
    path: "/certificate/edit/:id",
    needsAdmin: true,
    element: <CertificateForm />,
  },
  //-----------------Questions-------------------
  {
    path: "/questions",
    needsAdmin: true,
    needsQc: true,
    element: <Questions />,
  },
  {
    path: "/questions/edit/:id",
    needsAdmin: true,
    element: <QuestionEdit />,
  },
  {
    path: "/questions/create",
    needsAdmin: true,
    element: <QuestionCreate />,
  },

  // -----------------Candidate-------------------
  {
    path: "/candidate",
    needsAdmin: true,
    needsQc: true,

    element: <CandidateList />,
  },
  {
    path: "/candidate/create",
    // needsAdmin: true,
    // needsCand:true,
    element: <CandidateEdit />,
  },
  {
    path: "/candidate/:id",
    needsAdmin: true,
    element: <CandidateEdit />,
  },
  {
    path: "/candidate/AvailableExams",
    needsCand: true,

        element: <AvailableExams />
    },
    // -----------------Candidate-------------------
    {
        path: '/candidate/Examination/:id',
        needsCand: true,
        element: <Examination />
    },
    {
        path: '/ExamsList',
        // requireAuth: true,
        element: <ExamList/>
    },
    {
        path: '/ExamQuestionList',
        // requireAuth: true,
        element: <ExamQuestionList/>
    },
    {
        path: '/AddQuestionToExam',
        element: <AddQuestionToExam />
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
    element: <AvailableExams />,
  },
  // -----------------Candidate-------------------
  {
    path: "/candidate/Examination/:id",
    needsCand: true,
    element: <Examination />,
  },
  {
    path: "/ExamsList",
    // requireAuth: true,
    element: <ExamList />,
  },
  {
    path: "/ExamQuestionList",
    // requireAuth: true,
    element: <ExamQuestionList />,
  },
  {
    path: "*",
    element: <NotFound />,
  },
];

export default AppRoutes;

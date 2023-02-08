import axios from "axios";
import {getToken} from './handleJWT';

export default function configureInterceptor(){
  axios.defaults.headers.common['Authorization'] = `Bearer ${getToken()}`;

    // axios.interceptors.request.use(
    //     function (config){
    //         const token = getToken();

    //         if (token){
    //             config.headers.Authorization = `Bearer ${token}`;
    //         }

    //         return config;
    //     },
    //     function (error){
    //         return Promise.reject(error);
    //     }
    
}

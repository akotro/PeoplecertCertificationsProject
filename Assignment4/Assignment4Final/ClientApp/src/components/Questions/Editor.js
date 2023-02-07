import React from "react";

import {CKEditor} from "@ckeditor/ckeditor5-react";
import Editor from 'ckeditor5-custom-build/build/ckeditor';

// import { SimpleUploadAdapter } from "@ckeditor/ckeditor5-upload";
 


function MyEditor(props) {


console.log("Before editor");

    return (
        <div>
                                                      
   

                                <CKEditor
                                                    editor={Editor}
                                                    // data={props.text}
                                                    onReady={editor =>
                                                       {
                                                        /* You canc store the "editor" and use when it is needed. */
                                                        console.log("Editor is ready to use!");
                                                      }}

                                                            event = {props.event}
                                                    name={props.name}    
                                                    // optionId={props.optionId}

                                                    onChange={(event, editor,name) => 
                                                                        {
                                                                                // console.log(event);
                                                                                console.log("Inside Editor component");
                                                                                const data = editor.getData();
                                                                                // console.log(data);

                                                                                name=props.name;
                                                                                // console.log(name);
                                                                                
                                                                                // optionId=props.optionId;
                                                                                // console.log(optionId);
                                                                                    
                                                                                props.handleChange(event,name,data);
                                                                                
                                                                                            }
                                                                        }
                                                                        required

                                                    config={{
                                                      simpleUpload: {
                                                        // The URL that the images are uploaded to.
                                                        uploadUrl: "https://localhost:7196/api/Upload",
                                                        // plugins: [ SimpleUploadAdapter,  ],
                                                        // Enable the XMLHttpRequest.withCredentials property if required.
                                                        // withCredentials: true,
                                                
                                                        // Headers sent along with the XMLHttpRequest to the upload server.
                                                        // headers: {
                                                        //   "X-CSRF-TOKEN": "CSFR-Token",
                                                        //   Authorization: "Bearer <JSON Web Token>"
                                                        // }
                                                      }
                                                    }}
                                      />
</div>
                                      );


}   


export default MyEditor;





// editor={EditorPlus}
// data={question.text}
// onReady={editor => {
//   // You can store the "editor" and use when it is needed.
// }}

// onChange={(event, editor) => {
//   const data = editor.getData();
//   handleChange(data,event,editor);
// }}
// // config={{
// //   simpleUpload: {
// //     // The URL that the images are uploaded to.
// //     uploadUrl: "https://localhost:44473/admin/Questions/QuestionCreate",
    
// //     // Enable the XMLHttpRequest.withCredentials property if required.
// //     withCredentials: true,

// //     // Headers sent along with the XMLHttpRequest to the upload server.
// //     headers: {
// //       "X-CSRF-TOKEN": "CSFR-Token",
// //       Authorization: "Bearer <JSON Web Token>"
// //     }
// //   }
// // }}
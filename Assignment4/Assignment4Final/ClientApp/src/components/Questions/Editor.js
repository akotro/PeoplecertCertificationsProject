import React from "react";

import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
// import { SimpleUploadAdapter } from "@ckeditor/ckeditor5-upload";
import SimpleUploadAdapter from '@ckeditor/ckeditor5-upload/src/adapters/simpleuploadadapter';

function MyEditor(props) {
    console.log("Before editor");

    return (
        <div>
            <CKEditor
                editor={ClassicEditor}
                config={{
                    // plugins: [ Paragraph, Bold, Italic, Essentials ],
                    // toolbar: [ 'bold', 'italic' ],
                    plugins: [SimpleUploadAdapter],
                    simpleUpload: {
                        // The URL that the images are uploaded to.
                        uploadUrl: "https://localhost:7196/api/File",
                    },
                }}
                data="<p>Hello from the first editor working with the context!</p>"
                onReady={(editor) => {
                    // You can store the "editor" and use when it is needed.
                    console.log("Editor1 is ready to use!", editor);
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

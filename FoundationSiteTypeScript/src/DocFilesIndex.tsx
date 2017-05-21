import * as React from "React"
import * as ReactDOM from "react-dom"
import {IAllDocuments, IDocumentInfo, DocumentInfo, AllDocuments} from "./DocStorageInterfaces"
import {FileDocumentContainer, FileDocuments } from  "./components/FileDocWrapper"


// create dumment Entries

var files:IDocumentInfo[] = [
    { Id:"1234", Url:"https://google.com", 
    FileName:"TheFileName.docx", Title:"Title one", Description:"Long winded words about things",
     FileType:"docx", UploadedBy:"Paul Lawrence", UploadedDate:1495386000413},
         { Id:"12345", Url:"https://bing.com", 
    FileName:"AfileNAme.docx", Title:"Title Twoses", Description:"Blah Blah ",
     FileType:"docx", UploadedBy:"Paul Lawrence", UploadedDate:1495386000413},
];

var collection:AllDocuments ={
    CollectionName:"Myt list of Files",
    Files:files
}


ReactDOM.render(<FileDocumentContainer Files={collection.Files} CollectionName={collection.CollectionName} />, document.getElementById("docs"));
import * as React from "React"
import * as ReactDOM from "react-dom"
import {IAllDocuments, IDocumentInfo, IDocumentItem, DocumentInfo, AllDocuments} from "./DocStorageInterfaces"
import {FileDocumentContainer } from  "./components/FileDocWrapper"
import {FileDocument} from  "./components/FileDocument"


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
    CollectionName:"My list of Files",
    Files:files
}


ReactDOM.render(<FileDocumentContainer Files={collection.Files} CollectionName={collection.CollectionName} />, document.getElementById("docs"));
//ReactDOM.render(<FileDocument Item={files[0]} />, document.getElementById("docs") );

/* <FileDocument FileType={files[0].FileType}
                             Id={files[0].Id} 
                             Url={files[0].Url} 
                             Description={files[0].Description} 
                             FileName={files[0].FileName} 
                             Title={files[0].Title} 
                             UploadedBy={files[0].UploadedBy}
                              UploadedDate={files[0].UploadedDate}
                              */
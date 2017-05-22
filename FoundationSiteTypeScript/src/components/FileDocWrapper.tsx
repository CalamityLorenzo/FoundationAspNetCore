import * as React from "react"
import * as _ from "lodash"
import { IDocumentInfo, IAllDocuments, IDocumentItem } from "../DocStorageInterfaces"
import {FileDocument } from "./FileDocument"
export const FileDocumentContainer  = (props:IAllDocuments)=>
                        <div>
                            <h1>{props.CollectionName}</h1>
                            <div>
                            {_(props.Files).map(function(FileItm:IDocumentInfo,idx:number){
                             return (<FileDocument key={FileItm.Id} Item={FileItm}  />)
                           }.bind(this)).value()}
                            </div>
                        </div>

import * as React from "react"
import * as _ from "lodash"
import { IDocumentInfo, IAllDocuments, IDocumentItem } from "../DocStorageInterfaces"

export class FileDocument extends React.Component<IDocumentItem, any>{
    constructor (props:IDocumentItem){
        super(props);
    }
    render(){
        return <div>
            <div className="fileRow row">
                <div className="small-1 columns">
                    <span className={this.props.Item.FileType}></span>
                </div>
                <div className="small-3 fileNameCell columns">
                    <a href={this.props.Item.Url} className="file">{this.props.Item.FileName}</a>
                </div>
                <div className="small-4 columns">
                    <span>{this.props.Item.Description}</span>
                </div>
                <div className="small-2 columns">
                    <span>{this.props.Item.UploadedBy}</span>
                </div>
                <div className="small-2 columns">
                    <span>{this.props.Item.UploadedDate}</span>
                </div>                
            </div>
        </div>
    }
}
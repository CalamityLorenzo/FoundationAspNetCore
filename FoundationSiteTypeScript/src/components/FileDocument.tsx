import * as React from "react"
import * as _ from "lodash"
import * as moment from "moment"
import { IDocumentInfo, IAllDocuments, IDocumentItem } from "../DocStorageInterfaces"

export class FileDocument extends React.Component<IDocumentItem, any>{
    constructor(props: IDocumentItem) {
        super(props);
    }
    fileSelected(item: IDocumentInfo): string {
        return (item.Selected) ? "fileSelected" : "fileNotSelected"
    }
    formateDate(item: IDocumentInfo): string {
        return moment(item.UploadedDate).format("YYYY-MM-DD");
    }

    onRowClick = (domNode: any, evt: Event): void => {
        var element: HTMLElement = domNode.currentTarget;
        // yuck
        var classList = element.classList as any as string[];
        var isSelected = _(classList).find((e: string) => e === "selectedRow");
        if (isSelected) {
            element.classList.remove("selectedRow");
        } else {
            element.classList.add("selectedRow");
        }
    }
    render() {
        return <div className="fileRow row" onClick={this.onRowClick.bind(this)}>
            <div className="small-1 columns">
                <span className={this.fileSelected(this.props.Item)}></span>
            </div>
            <div className="small-1 columns">
                <span className={this.props.Item.FileType}></span>
            </div>
            <div className="small-3 fileNameCell columns">
                <a href={this.props.Item.Url} className="file">{this.props.Item.FileName}</a>
            </div>
            <div className="small-3 columns">
                <span>{this.props.Item.Description}</span>
            </div>
            <div className="small-2 columns">
                <span>{this.props.Item.UploadedBy}</span>
            </div>
            <div className="small-2 columns">
                <span>{this.formateDate(this.props.Item)}</span>
            </div>
        </div>
    }
}
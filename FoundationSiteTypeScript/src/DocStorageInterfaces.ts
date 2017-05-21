
export interface IDocumentInfo{
    Id:string;
    Url:string;
    Title:string;    
    FileName:string;
    Description:string;
    FileType:string;
    UploadedBy:string;
    UploadedDate:number;
}

export interface IDocumentItem{
    Item:IDocumentInfo;
}

export interface IAllDocuments{
    CollectionName:string;
    Files:IDocumentInfo[];
}

export class DocumentInfo implements IDocumentInfo{
    Id:string;
    Url:string;
    Title:string;
    FileName:string;
    Description:string;
    FileType:string;
    UploadedBy:string;
    UploadedDate:number;
}

export class AllDocuments implements IAllDocuments{
    CollectionName:string;
    Files:DocumentInfo[];
}

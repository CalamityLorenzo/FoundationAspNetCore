
export interface ICompleteNewsItem{
    by:string;
    descendants:number;
    id:number;
    kids:number[];
    time:number;
    title:string;
    type:string;
    url:string;
    score:string;
    [key:number]:any;
}

export interface IAllNewsItems{
    items:ICompleteNewsItem[];
}

export interface INewsItem{
    item:ICompleteNewsItem;
    rank:string;
}

export class CompleteNewsItem implements  ICompleteNewsItem{
    by:string;
    descendants:number;
    id:number;
    kids:number[];
    time:number;
    title:string;
    type:string;
    url:string;
    score:string;    
}
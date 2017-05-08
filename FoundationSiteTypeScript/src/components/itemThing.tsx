import * as React from "react";

export interface IMyElementEle{
    name:string,
    collar:string
}

export const MyItemTheRub = (props:IMyElementEle)=>
    <div>
        <h3>Pot {props.name}</h3>
    </div>
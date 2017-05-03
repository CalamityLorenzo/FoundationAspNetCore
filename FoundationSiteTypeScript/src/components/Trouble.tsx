import * as React from "React"

export interface IDoTheTrouble{
    name:string,
    DooDoo:string
}

export const DoTheTrouble = (props:IDoTheTrouble)=>
            <div>
             <h1>When it came to {props.name}</h1>
                <h2>The money {props.DooDoo}</h2>
            </div>;

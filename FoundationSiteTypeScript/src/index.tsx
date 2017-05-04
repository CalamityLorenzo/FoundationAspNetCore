import * as React from "react";
import * as ReactDOM from "react-dom";

import { Hello } from "./components/Hello";
import { DoTheTrouble } from "./components/Trouble";

ReactDOM.render(
    <Hello compiler="TypeScript" framework="React" />,
    document.getElementById("example")
);

ReactDOM.render(
    <DoTheTrouble name="Pickle Show" DooDoo="2" />, document.getElementById("teggies")
);
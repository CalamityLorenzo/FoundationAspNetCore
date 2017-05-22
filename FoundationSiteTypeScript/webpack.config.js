const webpack = require('webpack');
const config = {
    entry: "./src/DocFilesIndex.tsx",
    output: {
        filename: "foundyApp.js",
        path: __dirname + "/dest"
    },
    devtool:"source-map",

    resolve:{
        extensions:[".webpack.js", ".web.js", ".ts", ".tsx", ".js", ".json"]
    },
  module: {
        rules: [
            // All files with a '.ts' or '.tsx' extension will be handled by 'awesome-typescript-loader'.
            {
                enforce:'pre',
                test: /\.tsx?$/,
                loader: "awesome-typescript-loader",
                exclude: /(node_modules)|(HackerNewsTut)/
            },
            // All output '.js' files will have any sourcemaps re-processed by 'source-map-loader'.
            {
                enforce:"pre",
                test: /\.js$/,
                loader:"source-map-loader"
            },
            {
                enforce: "pre",
                test: /\.tsx?$/,
                loader: "source-map-loader"
            }
        ]
    },
    // When importing a module whose path matches one of the following, just
    // assume a corresponding global variable exists and use that instead.
    // This is important because it allows us to avoid bundling all of our
    // dependencies, which allows browsers to cache those libraries between builds.
    externals: {
        // node_modules name, external name
        "react": "React",
        "react-dom": "ReactDOM",
        "jquery": "$",
        "moment": "moment",
        "lodash": "_"
    },
} 

module.exports = config;
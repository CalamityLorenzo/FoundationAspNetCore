/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    rimraf = require('rimraf'),
    rename = require('gulp-rename'),
    uglify = require('gulp-uglify'),
    sass = require('gulp-sass'),
    concat = require('gulp-concat'),
    copy = require('gulp-copy'),
    fileExists = require('file-exists');

var paths = {
    webroot: "./wwwroot/"
}

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";
paths.libJs = paths.webroot + "lib/";

gulp.task('default', function () {
    // place code for your default task here

});

function getFile(fileName) {
    fileExists(fileName, { root: paths.libJs }, (err, exists) => { return err; });
}

gulp.task('js:foundation', function () {
    var s = getFile("foundation.min.js");
    console.log(s);
});

gulp.task("sass:foundation", function () {
    console.log(paths.css);
    gulp.src("./Scss/app.scss").pipe(sass({
        includePaths: ["./node_modules/foundation-sites/scss"]
    })
    .on('error', sass.logError))
    .pipe(rename("foundation.css"))
    .pipe(gulp.dest(paths.webroot + "css"));
});
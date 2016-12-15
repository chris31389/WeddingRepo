/// <binding BeforeBuild='inject:index' />
"use strict";

var gulp = require("gulp"),
    series = require("stream-series"),
    inject = require("gulp-inject"),
    wiredep = require("wiredep").stream;

var webroot = "./wwwroot/";

var paths = {
    ngModule: webroot + "app/**/*.module.js",
    ngRoute: webroot + "app/**/*.route.js",
    ngFilter: webroot + "app/**/*.filter.js",
    ngService: webroot + "app/**/*.service.js",
    ngController: webroot + "app/**/*.controller.js",
    ngComponent: webroot + "app/**/*.component.js",
    script: webroot + "scripts/**/*.js",
    script_refences: webroot + "scripts/_references.js",
    style: webroot + "styles/**/*.css"
};

gulp.task("lib", function () {
    var moduleSrc = gulp.src(paths.ngModule, { read: false });
    var routeSrc = gulp.src(paths.ngRoute, { read: false });
    var filterSrc = gulp.src(paths.ngFilter, { read: false });
    var serviceSrc = gulp.src(paths.ngService, { read: false });
    var componentSrc = gulp.src(paths.ngComponent, { read: false });
    var controllerSrc = gulp.src(paths.ngController, { read: false });
    var scriptSrc = gulp.src([paths.script, "!" + paths.script_refences], { read: false });
    var styleSrc = gulp.src(paths.style, { read: false });

    gulp.src(webroot + "index.html")
        .pipe(wiredep({
            optional: "configuration",
            goes: "here",
            ignorePath: ".."
        }))
        .pipe(inject(series(scriptSrc, moduleSrc, filterSrc, serviceSrc, controllerSrc, componentSrc, routeSrc), { ignorePath: "/wwwroot" }))
        .pipe(inject(series(styleSrc), { ignorePath: "/wwwroot" }))
        .pipe(gulp.dest(webroot));
});
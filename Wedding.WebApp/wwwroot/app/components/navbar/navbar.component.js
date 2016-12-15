(function () {
    "use strict";
    angular.module("app")
    .component("navbar", {
        templateUrl: "app/components/navbar/navbar.template.html",
        bindings: {
            title: "<"
        }
    });
}());
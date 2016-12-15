(function () {
    "use strict";
    angular.module("app")
    .component("mymenu", {
        templateUrl: "app/components/menu/menu.template.html",
        bindings: {
            content: "<"
        }
    });
}());
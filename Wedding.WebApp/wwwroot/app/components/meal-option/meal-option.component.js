(function () {
    "use strict";
    angular.module("app")
    .component("mealoption", {
        templateUrl: "app/components/meal-option/meal-option.template.html",
        controller: mealController,
        bindings: {
            option: "<"
        }
    });

    function mealController() {
        /* jshint validthis: true */
        var vm = this;
    }
}());
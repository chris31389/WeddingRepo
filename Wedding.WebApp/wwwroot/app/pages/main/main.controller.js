(function () {
    "use strict";

    angular
        .module("app")
        .controller("MainController", mainController);

    mainController.$inject = ["$scope", "LogoffService", "WeddingEventService"];

    function mainController($scope, logoffService, weddingEventService) {
        var vm = this;

        vm.logoff = logoffService.logoff;
        vm.mealLink = {
            show: false
        };

        weddingEventService.getWeddingEvents(function (weddingEvents) {
            weddingEvents.forEach(function (weddingEvent) {
                if (weddingEvent.name === "Wedding Breakfast") {
                    vm.mealLink.show = true;
                }
            });
        });
    }
})();

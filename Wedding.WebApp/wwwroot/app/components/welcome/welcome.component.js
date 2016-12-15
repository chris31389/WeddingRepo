(function () {
    "use strict";
    angular.module("app")
    .component("welcome", {
        templateUrl: "app/components/welcome/welcome.template.html",
        controller: welcomeController
    });

    welcomeController.$inject = ["RsvpService", "MealService", "WeddingEventService", "$window", "$scope"];

    function welcomeController(rsvpService, mealService, weddingEventService, $window, $scope) {
        var ctrl = this;
        ctrl.reference = {};
        ctrl.weddingEvent = {
            sessions: []
        }
        weddingEventService.getWeddingEvents(storeWeddingEvents);
        mealService.getMeals(storeMeals);

        function storeMeals(data) {
            ctrl.meals = data;
        }

        function storeWeddingEvents(weddingEvents) {
            ctrl.weddingEvent.sessions = weddingEvents;
            weddingEvents.forEach(function (weddingEvent) {
                if (weddingEvent.name === "Wedding Breakfast") {
                    ctrl.showMeal = true;
                }
            });
        }

        rsvpService.getRsvp(storeRsvped);

        function storeRsvped(data) {
            ctrl.rsvp = data;
        }


        var w = angular.element($window);
        $scope.$watch(
          function () {
              return $window.innerWidth;
          },
          function (value) {
              $scope.welcomeWindowWidth = value;
          },
          true
        );

        w.bind('resize', function () {
            $scope.$apply();
        });

    }
}());
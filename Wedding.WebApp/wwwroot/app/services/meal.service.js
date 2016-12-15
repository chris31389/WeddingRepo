(function () {
    "use strict";

    angular.module("app")
      .factory("MealService", mealService);

    mealService.$inject = ["$http", "$sessionStorage"];

    function mealService($http, $sessionStorage) {
        var service = {};

        service.getMeals = getMeals;
        service.saveMeals = saveMeals;
        service.clear = clear;

        return service;

        function getMeals(callback) {
            if ($sessionStorage.meal) {
                callback(JSON.parse($sessionStorage.meal));
            }
            else {
                $http
                    .get("api/meal", null)
                    .success(function (response) {
                        $sessionStorage.meal = JSON.stringify(response);
                        callback(response);
                    });
            }
        }

        function saveMeals(meal, callback) {
            $http
                .post("api/meal", JSON.stringify(meal))
                .success(function () {
                    meal.SelectedMeals = true;
                    $sessionStorage.meal = JSON.stringify(meal);
                    callback();
                });
        }

        function clear() {
            $sessionStorage.meal = null;
        }
    }
}());
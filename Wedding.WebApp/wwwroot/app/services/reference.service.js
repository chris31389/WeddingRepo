(function () {
    "use strict";

    angular.module("app")
      .factory("ReferenceService", referenceService);

    referenceService.$inject = ["$http", "$sessionStorage"];

    function referenceService($http, $sessionStorage) {
        var service = {};

        service.getWeddingEvents = getWeddingEvents;
        service.getStarterMealChoices = getStarterMealChoices;
        service.getMainMealChoices = getMainMealChoices;
        service.getDessertMealChoices = getDessertMealChoices;
        service.clear = clear;

        return service;

        function getWeddingEvents(callback) {
            if ($sessionStorage.weddingEvents) {
                callback(JSON.parse($sessionStorage.weddingEvents));
            }
            else {
                $http
                .get("api/reference/weddingEvent", null)
                .success(function (response) {
                    $sessionStorage.weddingEvents = JSON.stringify(response);
                    callback(response);
                });
            }
        }

        function getStarterMealChoices(callback) {
            if ($sessionStorage.starterMealChoice) {
                callback(JSON.parse($sessionStorage.starterMealChoice));
            }
            else {
                $http
                .get("api/reference/starterMealChoice", null)
                .success(function (response) {
                    $sessionStorage.starterMealChoice = JSON.stringify(response);
                    callback(response);
                });
            }
        }

        function getMainMealChoices(callback) {
            if ($sessionStorage.mainMealChoice) {
                callback(JSON.parse($sessionStorage.mainMealChoice));
            }
            else {
                $http
                .get("api/reference/mainMealChoice", null)
                .success(function (response) {
                    $sessionStorage.mainMealChoice = JSON.stringify(response);
                    callback(response);
                });
            }
        }

        function getDessertMealChoices(callback) {
            if ($sessionStorage.dessertMealChoice) {
                callback(JSON.parse($sessionStorage.dessertMealChoice));
            }
            else {
                $http
                .get("api/reference/dessertMealChoice", null)
                .success(function (response) {
                    $sessionStorage.dessertMealChoice = JSON.stringify(response);
                    callback(response);
                });
            }
        }

        function clear() {
            $sessionStorage.weddingEvents = null;
            $sessionStorage.starterMealChoice = null;
            $sessionStorage.mainMealChoice = null;
            $sessionStorage.dessertMealChoice = null;
        }
    }
}());
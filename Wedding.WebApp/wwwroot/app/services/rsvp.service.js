(function () {
    "use strict";

    angular.module("app")
      .factory("RsvpService", rsvpService);

    rsvpService.$inject = ["$http", "$sessionStorage"];

    function rsvpService($http, $sessionStorage) {
        var service = {};

        service.getRsvp = getRsvp;
        service.saveRsvp = saveRsvp;
        service.clear = clear;

        return service;

        function getRsvp(callback) {
            if ($sessionStorage.rsvp) {
                callback(JSON.parse($sessionStorage.rsvp));
            }
            else {
                $http
                    .get("api/rsvp", null)
                    .success(function (response) {
                        $sessionStorage.rsvp = JSON.stringify(response);
                        callback(response);
                    });
            }
        }

        function saveRsvp(rsvp, callback) {
            $http
                .post("api/rsvp", JSON.stringify(rsvp))
                .success(function () {
                    rsvp.rsvped = true;
                    $sessionStorage.rsvp = JSON.stringify(rsvp);
                    callback();
                });
        }

        function clear() {
            $sessionStorage.rsvp = null;
        }
    }
}());
(function () {
    "use strict";

    angular.module("app")
      .factory("InviteService", inviteService);

    inviteService.$inject = ["$http", "$sessionStorage"];

    function inviteService($http, $sessionStorage) {
        var service = {};

        service.getInvite = getInvite;
        service.clear = clear;

        return service;
        
        function getInvite(callback) {
            if ($sessionStorage.invite) {
                callback(JSON.parse($sessionStorage.invite));
            }
            else {
                $http
                .get("api/invite", null)
                .success(function (response) {
                    $sessionStorage.invite = JSON.stringify(response);
                    callback(response);
                });
            }
        }
        
        function clear() {
            $sessionStorage.invite = null;
        }
    }
}());
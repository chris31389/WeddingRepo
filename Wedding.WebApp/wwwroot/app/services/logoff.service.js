(function () {
    "use strict";

    angular.module("app")
      .factory("LogoffService", logoffService);

    logoffService.$inject = [
        "auth0Service",
        "InviteService",
        "$state",
        "ReferenceService",
        "RsvpService",
        "MealService"
    ];

    function logoffService(
        auth0Service,
        inviteService,
        $state,
        referenceService,
        rsvpService,
        mealService
    ) {
        var service = {};

        service.logoff = logoff;

        return service;

        function logoff() {
            inviteService.clear();
            auth0Service.clear();
            referenceService.clear();
            rsvpService.clear();
            mealService.clear();

            $state.go("login");
        }
    }
}());
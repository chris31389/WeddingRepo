(function () {
    "use strict";

    angular
        .module("app")
        .factory("WeddingEventService", weddingEventService);

    weddingEventService.$inject = ["ReferenceService", "InviteService"];

    function weddingEventService(referenceService, inviteService) {
        var service = {};

        service.getWeddingEvents = getWeddingEvents;

        return service;

        function getWeddingEvents(callback) {
            referenceService.getWeddingEvents(function (weddingEventsReferenceData) {
                inviteService.getInvite(function (inviteReceived) {
                    var weddingEvents = [];
                    inviteReceived.weddingEvents.forEach(function (weddingEventInvitedToId) {
                        weddingEventsReferenceData.forEach(function (weddingEventReference) {
                            if (weddingEventInvitedToId === weddingEventReference.id) {
                                weddingEvents.push(weddingEventReference);
                            }
                        });
                    });

                    callback(weddingEvents);
                });
            });
        }
    }
}());
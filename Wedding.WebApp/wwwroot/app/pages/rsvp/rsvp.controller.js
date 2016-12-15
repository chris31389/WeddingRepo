(function () {
    'use strict';

    angular
        .module('app')
        .controller('RsvpController', rsvpController);

    rsvpController.$inject = ["RsvpService", "$state", "WeddingEventService"];

    function rsvpController(rsvpService, $state, weddingEventService) {
        var vm = this;

        vm.title = "Rsvp";

        vm.sendRsvp = sendRsvp;

        rsvpService.getRsvp(storeRsvp);
        weddingEventService.getWeddingEvents(storeWeddingEvents);

        function storeRsvp(data) {
            vm.rsvp = data;
        }

        function storeWeddingEvents(data) {
            vm.weddingEvents = data;
        }

        function sendRsvp() {
            rsvpService.saveRsvp(
                vm.rsvp,
                function() {
                $state.go("main");
            });
        }

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

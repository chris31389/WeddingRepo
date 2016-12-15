(function () {
    'use strict';

    angular
        .module('app')
        .controller('ItineraryController', itineraryController);

    itineraryController.$inject = ["ItineraryService", "WeddingEventService"];

    function itineraryController(itineraryService, weddingEventService) {
        /* jshint validthis: true */
        var vm = this;

        vm.itinerary = itineraryService.getItinerary();
        weddingEventService.getWeddingEvents(storeWeddingevents);

        function storeWeddingevents(data) {
            vm.weddingEvents = data;
        }
    }
})();

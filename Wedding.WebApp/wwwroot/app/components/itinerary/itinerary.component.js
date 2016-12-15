(function () {
    'use strict';
    angular.module("app")
    .component('itinerary', {
        templateUrl: 'app/components/itinerary/itinerary.template.html',
        controller: itineraryController,
        bindings: {
            weddingevents: '<'
        }
    });

    itineraryController.$inject = ["ItineraryService"];

    function itineraryController(itineraryService) {
        /* jshint validthis: true */
        var vm = this;

        vm.title = "The Itinerary";

        vm.itinerary = itineraryService.getItinerary();
    }
}());
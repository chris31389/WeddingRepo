(function () {
    'use strict';
    angular.module("app")
    .component('itineraryday', {
        templateUrl: 'app/components/itinerary-day/itinerary-day.template.html',
        controller: itineraryDayController,
        bindings: {
            events: '<'
        }
    });

    function itineraryDayController() {
        /* jshint validthis: true */
        var vm = this;
    }
}());
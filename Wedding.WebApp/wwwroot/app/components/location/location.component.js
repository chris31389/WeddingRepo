(function () {
    'use strict';
    angular.module("app")
    .component('weddinglocation', {
        templateUrl: 'app/components/location/location.template.html',
        controller: weddingLocationController,
        bindings: {
            location: '<'
        }
    });

    function weddingLocationController() {
        /* jshint validthis: true */
        var vm = this;
    }
}());
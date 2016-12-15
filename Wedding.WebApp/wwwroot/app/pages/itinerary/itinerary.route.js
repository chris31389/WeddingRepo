(function () {
    'use strict';

    angular
      .module('app')
      .config(routerConfig);

    routerConfig.$inject = ['$stateProvider'];

    function routerConfig($stateProvider) {
        $stateProvider
            .state('itinerary', {
                parent: 'main',
                url: 'itinerary',
                views: {
                    'content@main': {
                        templateUrl: 'app/pages/itinerary/itinerary.html',
                        controller: 'ItineraryController',
                        controllerAs: 'vm'
                    }
                }
            });
    }
})();

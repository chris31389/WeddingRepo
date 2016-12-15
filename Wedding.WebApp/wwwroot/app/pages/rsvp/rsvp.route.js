(function () {
    'use strict';

    angular
      .module('app')
      .config(routerConfig);

    routerConfig.$inject = ['$stateProvider'];

    function routerConfig($stateProvider) {
        $stateProvider
            .state('rsvp', {
                parent: 'main',
                url: 'rsvp',
                views: {
                    'content@main': {
                        templateUrl: 'app/pages/rsvp/rsvp.html',
                        controller: 'RsvpController',
                        controllerAs: 'vm'
                    }
                }
            });
    }
})();

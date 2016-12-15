(function () {
    'use strict';

    angular
      .module('app')
      .config(routerConfig);

    routerConfig.$inject = ['$stateProvider'];

    function routerConfig($stateProvider) {
        $stateProvider
            .state('honeymoon', {
                parent: 'main',
                url: 'honeymoon',
                views: {
                    'content@main': {
                        templateUrl: 'app/pages/honeymoon/honeymoon.html',
                        controller: 'HoneymoonController',
                        controllerAs: 'vm'
                    }
                }
            });
    }
})();

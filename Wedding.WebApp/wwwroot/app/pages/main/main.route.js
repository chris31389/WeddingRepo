(function () {
    'use strict';

    angular
      .module('app')
      .config(routerConfig);

    routerConfig.$inject = ['$stateProvider'];

    function routerConfig($stateProvider) {
        $stateProvider
            .state('main',
            {
                url: '/',
                views: {
                    'main': {
                        templateUrl: 'app/pages/main/main.html',
                        controller: 'MainController',
                        controllerAs: 'vm'
                    },
                    'content@main': {
                        templateUrl: 'app/pages/home/home.html',
                        controller: 'HomeController',
                        controllerAs: 'vm'
                    }
                }
            });
    }
})();
(function () {
    'use strict';

    angular
      .module('app')
      .config(routerConfig);

    routerConfig.$inject = ['$stateProvider'];

    function routerConfig($stateProvider) {
        $stateProvider
            .state('meal', {
                parent: 'main',
                url: 'meal',
                views: {
                    'content@main': {
                        templateUrl: 'app/pages/meal/meal.html',
                        controller: 'MealController',
                        controllerAs: 'vm'
                    }
                }
            });
    }
})();

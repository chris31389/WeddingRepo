(function () {
    'use strict';

    angular
        .module('app')
        .controller('MealController', mealController);

    mealController.$inject = ["$scope", "MealService", "ReferenceService", "$state", "MenuService"];

    function mealController($scope, mealService, referenceService, $state, menuService) {
        var vm = this;

        vm.title = "Your Choices";
        vm.sendMeals = sendMeals;
        vm.menu = {
            adult: {},
            child: {}
        };

        mealService.getMeals(storeMeal);
        referenceService.getStarterMealChoices(storeStarterMealChoices);
        referenceService.getMainMealChoices(storeMainMealChoices);
        referenceService.getDessertMealChoices(storeDessertMealChoices);

        var menu = menuService.getMenu();
        vm.menu.adult = menu.adult;
        vm.menu.adult.title = "Adults Menu";
        vm.menu.child = menu.child;
        vm.menu.child.title = "Childrens Menu";

        function storeMeal(data) {
            vm.meal = data;
        }

        function storeStarterMealChoices(data) {
            vm.starterMealChoices = data;
        }

        function storeMainMealChoices(data) {
            vm.mainMealChoices = data;
        }

        function storeDessertMealChoices(data) {
            vm.dessertMealChoices = data;
        }

        function sendMeals() {
            mealService.saveMeals(
                vm.meal,
                function() {
                $state.go("main");
            });
        }
    }
})();

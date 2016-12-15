(function () {
    "use strict";

    angular
        .module("app")
        .controller("LoginController", LoginController);

    LoginController.$inject = ["$scope", "$http", "$state", "auth0Service"];

    function LoginController($scope, $http, $state, auth0Service) {
        var vm = this;

        var signIn = "Sign in";
        var loading = "Signing in...";

        vm.loginInfo = {
            UserName: ""
        };

        vm.loginDisabled = false;
        vm.loginValue = signIn;

        vm.login = function () {
            vm.loginDisabled = true;
            vm.loginValue = loading;

            auth0Service.login(vm.loginInfo,
                function(response) {
                    if (response === "OK") {
                        auth0Service.authenticate();
                        $state.go("main");
                    }
                    vm.loginDisabled = false;
                    vm.loginValue = signIn;
                });
        };
    }
})();
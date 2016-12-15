(function () {
    "use strict";
    angular.module("app")
    .component("honeymoon", {
        templateUrl: "app/components/honeymoon/honeymoon.template.html",
        controller: honeymoonController
    });

    function honeymoonController() {
        /* jshint validthis: true */
        var vm = this;

        vm.title = "The Honeymoon";

        vm.sections = [
            {
                "content": "To make this a once in a lifetime trip, we have upgraded to a \"step up\" room, where we can step straight into one of the resort’s pools from the terrace.",
                "images": ["honeymoon1.jpg", "honeymoon2.jpg"]
            },
            {
                "content": "The hotel boasts 14 different restaurants and is all inclusive.",
                "images": ["honeymoon3.jpg", "honeymoon4.jpg"]
            },
            {
                "content": "We want to take a look into some history of the area. Two areas recommended is Chichin Itza and Tulum Express.",
                "images": ["chichenitza.jpg", "tulum-express.jpg"]
            }
        ];
    }
}());
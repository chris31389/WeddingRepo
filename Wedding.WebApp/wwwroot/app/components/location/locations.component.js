(function () {
    'use strict';
    angular.module("app")
    .component('weddinglocations', {
        templateUrl: 'app/components/location/locations.template.html',
        controller: weddingLocationsController
    });

    weddingLocationsController.$inject = ["$sce"];

    function weddingLocationsController($sce) {
        /* jshint validthis: true */
        var vm = this;

        vm.title = "The Locations";

        vm.locations = [
            {
                name: "St Remigius",
                role: "The Ceremony",
                address: "27 Norwich Rd, Hethersett, Norwich NR9 3AR",
                image: "st-remigius2.jpg",
                googleMapUrl: $sce.trustAsResourceUrl("https://www.google.com/maps/embed/v1/place?key=AIzaSyBI7RWHBF4OqUR4cfQzscyuTqxxnK3XEKQ&q=St%20Remigius+Norwich%20Road+Hethersett+Norwich")
            },
            {
                name: "Park Farm Hotel",
                role: "The Reception",
                address: "Park Farm Hotel, Norwich Road, Hethersett, Norwich, NR9 3DL",
                image: "parkfarm-entrance.jpg",
                googleMapUrl: $sce.trustAsResourceUrl("https://www.google.com/maps/embed/v1/place?key=AIzaSyBI7RWHBF4OqUR4cfQzscyuTqxxnK3XEKQ&q=Park%20Farm%Hotel+Hethersett,Norwich%20Road+Hethersett+Norwich")
            },
            {
                name: "Travelodge Hotel",
                role: "Alternative Accommodation",
                address: "Thickthorn Service Area, A11 / A47 Interchange, Norwich Southern Bypass, Norwich NR9 3AU, United Kingdom  ",
                image: "travelodge.jpg",
                googleMapUrl: $sce.trustAsResourceUrl("https://www.google.com/maps/embed/v1/place?key=AIzaSyBI7RWHBF4OqUR4cfQzscyuTqxxnK3XEKQ&q=Travelodge+Hethersett")
            }
        ];
    }
}());
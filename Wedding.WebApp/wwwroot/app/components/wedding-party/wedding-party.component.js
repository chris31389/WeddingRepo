(function () {
    "use strict";
    angular.module("app")
    .component("weddingParty", {
        templateUrl: "app/components/wedding-party/wedding-party.template.html",
        controller: weddingPartyController
    });

    weddingPartyController.$inject = ["$window", "$scope"];

    function weddingPartyController($window, $scope) {
        /* jshint validthis: true */
        var ctrl = this;

        var w = angular.element($window);
        $scope.$watch(
          function () {
              return $window.innerWidth;
          },
          function (value) {
              $scope.weddingPartyWindowWidth = value;
          },
          true
        );

        w.bind('resize', function () {
            $scope.$apply();
        });

        ctrl.title = "The Wedding Party";

        ctrl.party = [
            {
                groomsParty: {
                    name: "Peter Neil-Jones",
                    description: "Peter used to live next door to Chris growing up. He married his wife, Jess and went on an 18 month honeymoon to Asia and Australia, getting back in December.",
                    image: {
                        xs: "pete-front.jpg",
                        default: "pete-side2.jpg"
                    },
                    role: "Best Man"
                },
                bridalParty: {
                    name: "Beth Alston",
                    description: "Yasmin met Beth on the first day of university and they have been close friends ever since.  Beth has recently moved back to Norfolk with her boyfriend Matt.",
                    image: {
                        xs: "beth-front.jpg",
                        default: "beth-side.jpg"
                    },
                    role: "Maid of Honour"
                },
                order: 1
            },
            {
                groomsParty: {
                    name: "Tom Jobson",
                    description: "Tom grew up with Chris and loves getting outside and being adventurous.  One of the lads, he is always up for a cheeky pint.",
                    image: {
                        xs: "jobby-front.jpg",
                        default: "jobby-side2.jpg"
                    },
                    role: "Usher"
                },
                bridalParty: {
                    name: "Lottie Jones",
                    description: "Lottie and Yasmins were good friends as children and grew closer at 6th form.  Lottie is also chris' university friend and introduced Yasmin and Chris at her 20th birthday party",
                    image: {
                        xs: "lottie-front.jpg",
                        default: "lottie-side.jpg"
                    },
                    role: "Maid of Honour"
                },
                order: 2
            },
            {
                groomsParty: {
                    name: "Ashley Finn",
                    description: "Ashley is another friend that grew up with Chris.  He has recently bought his first house, a penthouse suite no less!",
                    image: {
                        xs: "ashley-front.jpg",
                        default: "ashley-side2.jpg"
                    },
                    role: "Usher"
                },
                bridalParty: {
                    name: "Gemma Butler",
                    description: "Gemma is Chris' youngest sister.  She's well known for having wacky hair colours, we're looking forward to which colour she picks on the wedding day.",
                    image: {
                        xs: "gem-front.jpg",
                        default: "gem-side.jpg"
                    },
                    role: "Bridesmaid"
                },
                order: 3
            },
            {
                groomsParty: {
                    name: "Mat Jones",
                    description: "Mat is known as one of yas' boys, alongside Jamie and Ali. After studying Architecture together (which still continues), they became very close friends.",
                    image: {
                        xs: "mat-front.jpg",
                        default: "mat-side2.jpg"
                    },
                    role: "Usher",
                    order: 4
                },
                bridalParty: {
                    name: "Sarah Butler",
                    description: "Sarah is one of Chris' sisters. She has been travelling for the last couple of years, visiting Europe, Australia, Asia, South America, America and others, recently getting back from Austria's Ski season.",
                    image: {
                        xs: "sarah-front.jpg",
                        default: "sarah-side.jpg"
                    },
                    role: "Bridesmaid"
                },
                order: 4
            },
            {
                groomsParty: {
                    name: "Simon Giles",
                    description: "Yasmins only sibling, her favourite brother who recently got married to Leanne.  Simon prides himself on being a sensible drinker and a careful driver.",
                    image: {
                        xs: "simon-front.jpg",
                        default: "simon-side2.jpg"
                    },
                    role: "Usher"
                },
                bridalParty: {
                    name: "Leanne Giles",
                    description: "Leanne is Yasmin's new sister-in-law after marrying Simon in August.  Leanne met Simon as a young teenager and has been in Yasmin's life ever since.",
                    image: {
                        xs: "leanne-front.jpg",
                        default: "leanne-side.jpg"
                    },
                    role: "Bridesmaid"
                },
                order: 5
            }
        ];
    }
}());
(function () {
    "use strict";

    angular.module("app")
      .factory("ItineraryService", itineraryService);

    function itineraryService() {
        var service = {};

        service.getItinerary = getItinerary;

        return service;

        function getItinerary() {
            var itinerary = {
                days: [
                    {
                        date: "28/04/2017",
                        day: "Friday",
                        timetable: [
                            {
                                time: "19:30",
                                title: "Friday Night Catchup",
                                description:
                                    "Whilst Yasmin is tucking into bed at her mums, Chris will be meeting guests who have nothing else to do and happen to be in norfolk at a local pub near the venue."
                            }
                        ]
                    }, {
                        date: "29/04/2017",
                        day: "Saturday",
                        timetable: [
                            {
                                time: "12:00",
                                title: "Wedding Ceremony",
                                description: "Tying the knot at St. Remigius Church, Hethersett",
                                image:"st-remigius.jpg"
                            }, {
                                time: "14:00",
                                title: "Pub Lunch",
                                description: "For those we were not able to invite to the Wedding Breakfast, a meal served at a local pub"
                            }, {
                                time: "14:00",
                                title: "Welcome drinks",
                                description: "For those we were able to invite to the Wedding Breakfast, Welcome drinks served at Park Farm",
                                image: "parkfarm-entrance.jpg"
                            }, {
                                time: "14:30",
                                title: "Wedding Breakfast",
                                description: "The Wedding breakfast served at park farm. Make sure you remember to order your food!"
                            }, {
                                time: "16:30",
                                title: "Speeches",
                                description: "Guests at the pub lunch arrive back to hear the speeches by Mark Giles (Father of the Bride), Chris (the groom) and Peter Neil-Jones (The best Man)"
                            }, {
                                time: "17:00",
                                title: "Casual break, bar and games",
                                description: "This is a bit of down time where we offer guests to meet us in the bar, play some games and have a chance to nip back to your room"
                            }, {
                                time: "18:30",
                                title: "Evening Reception Opens",
                                description: "The evening reception will open, ready for a Band, a DJ, the Dance floor and most importantly, Dinner",
                                image: "johnny-and-the-goodtime-boys.jpg"
                            }, {
                                time: "20:30",
                                title: "Dinner",
                                description: "A Pulled Belly of Pork served in a soft roll with optional Apple Sauce and Green Salad"
                            }, {
                                time: "23:59",
                                title: "Close",
                                description: "Time to say goodbye and bring things to an end."
                            }
                        ]
                    }, {
                        date: "30/04/2017",
                        day: "Sunday",
                        timetable: [
                            {
                                time: "09:00 onwards",
                                title: "Hungover Breakfast",
                                description: "The guests staying at Parm Farm Hotel will hopefully be able to eat some breakfast before saying our goodbyes and parting ways"
                            }
                        ]
                    }, {
                        date: "1/05/2017",
                        day: "Monday",
                        timetable: [
                            {
                                time: "11:00 roughly",
                                title: "The Honeymoon Starts",
                                description: "We will fly to Paradisus Playa Del Carmen La Perla, Mexico!",
                                image: "paradisus-playa-del-carmen-la-perla.jpg"
                            }
                        ]
                    }
                ]
            };

            return itinerary;
        }
    }
}());
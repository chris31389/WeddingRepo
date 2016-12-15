(function () {
    "use strict";

    angular.module("app")
      .factory("MenuService", menuService);

    function menuService() {
        var service = {};

        service.getMenu = getMenu;

        return service;

        function getMenu() {
            var menu = {
                adult: {
                    starters: {
                        options: [
                            {
                                name: "Duck",
                                description: "Smoked Duck Breast and Pancetta Salad served with Plum Dressing",
                                isVegetarian: false
                            }, {
                                name: "Risotto",
                                description: "Wild Mushroom and Butternut Squash Risotto with Truffle Oil",
                                isVegetarian: true
                            }
                        ]
                    },
                    mains: {
                        caption: "All main courses served with freshly prepared Vegetables and Potatoes",
                        options: [{
                            name: "Seabass",
                            description: "Seabass Fillet topped with Asparagus Spears served on Crushed New Potatoes with Beurre Blanc Sauce",
                            isVegetarian: false
                        }, {
                            name: "Lamb",
                            description: "Roast Rump of Lamb on Potato Rosti with maderia Jus",
                            isVegetarian: false
                        }, {
                            name: "Tartlet",
                            description: "Roast Cherry Tomato and Binham Blue Tartlet",
                            isVegetarian: true
                        }]
                    },
                    desserts: {
                        options: [
                            {
                                name: "Crumble",
                                description: "Apple and Toffee Crumble Tart with Cinnamon Ice Cream",
                                isVegetarian: true
                            }, {
                                name: "Brulee",
                                description: "Raspberry and Vanilla Seed Brulee accompanied with a Tuille Buscuit",
                                isVegetarian: true
                            }
                        ]
                    }
                },
                child: {
                    starters: {
                        options: [
                            {
                                name: "Fruit Juice",
                                description: "",
                                isVegetarian: true
                            }
                        ]
                    },
                    mains: {
                        caption: "Accompanied with Chips and Peas",
                        options: [{
                            name: "Chicken Nuggets",
                            description: "",
                            isVegetarian: false
                        }, {
                            name: "Sausages",
                            description: "",
                            isVegetarian: false
                        }, {
                            name: "Fish Fingers",
                            description: "",
                            isVegetarian: false
                        }, {
                            name: "Lasange",
                            description: "",
                            isVegetarian: false
                        }]
                    },
                    desserts: {
                        options: [
                            {
                                name: "Ice Cream",
                                description: "",
                                isVegetarian: true
                            }
                        ]
                    }
                }
            };

            return menu;
        }
    }
}());
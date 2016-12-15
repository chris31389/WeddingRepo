(function () {
    "use strict";

    angular
        .module("app")
        .filter("AgeFilter", ageFilter);

    function ageFilter($filter) {
        return function (list, arrayFilter, element) {
            var elementValueRequired = arrayFilter ? "Adult" : "Child";
            return $filter("filter")(list,
                function (listItem) {
                    return listItem[element] === elementValueRequired;
                });
        };
    }
})();

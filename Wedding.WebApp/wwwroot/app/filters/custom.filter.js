(function () {
    "use strict";

    angular
        .module("app")
        .filter("CustomFilter", customFilter);
    
    function customFilter($filter) {
        return function (list, arrayFilter, element) {
            if (arrayFilter) {
                return $filter("filter")(list,
                    function (listItem) {
                        return arrayFilter.indexOf(listItem[element]) !== -1;
                    });
            }
        };
    }
})();

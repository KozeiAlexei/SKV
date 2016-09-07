angular.module('SKV').service('LocationService', ['$location', function ($location) {
    return {
        Path: function (url) { $location.path(url); },
        Redirect: function (url) { location.href = url; }
    }
}]);
angular.module('SKV').service('$pages', ['$request', function ($request) {

    var buildServiceUrl = function (serviceMethod) {
        return '/api/Common/Pages/' + serviceMethod;
    }

    return {
        GetPages: function (successCallback, errorCallback) {
            $request.Get(buildServiceUrl('GetPages'), null, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },
    }
}]);
angular.module('SKV').service('$roles', ['$request', function ($request) {

    var buildServiceUrl = function (serviceMethod) {
        return '/api/Administration/Security/Roles/' + serviceMethod;
    }

    return {
        GetRoles: function (successCallback, errorCallback) {
            $request.Get(buildServiceUrl('GetRoles'), null, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },
    }
}]);
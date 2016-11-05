angular.module('SKV').service('$permissions', ['$request', function ($request) {

    var buildServiceUrl = function (serviceMethod) {
        return '/api/Administration/Security/Permissions/' + serviceMethod;
    }

    return {
        GetPermissions: function (successCallback, errorCallback) {
            $request.Get(buildServiceUrl('GetPermissions'), null, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },
    }
}]);
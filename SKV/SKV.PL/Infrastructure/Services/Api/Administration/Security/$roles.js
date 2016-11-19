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

        UpdateRoleData: function (userData, successCallback, errorCallback) {
            $request.Post(buildServiceUrl('UpdateRoleData'), userData, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },

        CreateRole: function (userData, successCallback, errorCallback) {
            $request.Post(buildServiceUrl('CreateRole'), userData, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },

        DeleteRole: function (user, successCallback, errorCallback) {
            $request.Post(buildServiceUrl('DeleteRole'), user, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        }
    }
}]);
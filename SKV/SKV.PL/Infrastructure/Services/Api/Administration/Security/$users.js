angular.module('SKV').service('$users', ['$request', function ($request) {

    var buildServiceUrl = function (serviceMethod) {
        return '/api/Administration/Security/Users/' + serviceMethod;
    }

    return {
        GetUsers: function (successCallback, errorCallback) {
            $request.Get(buildServiceUrl('GetUsers'), null, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        }, 

        UpdateUserData: function (userData, successCallback, errorCallback) {
            $request.Post(buildServiceUrl('UpdateUserData'), userData, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },

        Register: function (userData, successCallback, errorCallback) {
            $request.Post(buildServiceUrl('Register'), userData, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },

        ChangePassword: function (passwordChangingData, successCallback, errorCallback) {
            $request.Post(buildServiceUrl('ChangePassword'), passwordChangingData, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },

        DeleteUser: function (user, successCallback, errorCallback) {
            $request.Post(buildServiceUrl('DeleteUser'), user, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        }
    }
}]);
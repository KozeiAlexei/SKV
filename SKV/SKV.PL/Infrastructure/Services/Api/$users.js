angular.module('SKV').service('$users', ['$request', function ($request) {
    return {
        Errors: {
            ValidationError: 400
        }, 

        GetUsers: function (successCallback, errorCallback) {
            $request.Get('/api/Security/Users/GetUsers', null, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        }, 

        UpdateUserData: function (userData, successCallback, errorCallback) {
            $request.Post('/api/Security/Users/UpdateUserData', userData, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },

        Register: function (userData, successCallback, errorCallback) {
            $request.Post('/api/Security/Users/Register', userData, function (response) {
                successCallback(response);
            }, function (error, status) {
                errorCallback(error, status);
            });
        },
    }
}]);
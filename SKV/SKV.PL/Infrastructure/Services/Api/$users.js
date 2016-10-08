angular.module('SKV').service('$users', ['$request', function ($request) {
    return {
        GetUsers: function (callback) {
            $request.Get('/api/Security/Users/GetUsers', null, function (response) {
                callback(response);
            });
        }, 

        UpdateUserData: function (userData, callback) {
            $request.Post('/api/Security/Users/UpdateUserData', userData, function (response) {
                callback(response);
            });
        }
    }
}]);
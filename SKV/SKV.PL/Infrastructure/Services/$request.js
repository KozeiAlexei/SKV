//Сервис отправки запросов
angular.module('SKV').service('$request', ['$http', '$window', 'ToolsService', 'AuthService',
function ($http, $window, ToolsService, AuthService) {
    return {
        Get: function (uri, data, successCallback) {
            var http = $http; AuthService.SetHeader(http);

            $http.get(uri, data).success(function (response) {
                successCallback(response);
            }).error(function (error, status) {
                if (status != 500)
                    successCallback(error);
            });
        },

        Post: function (uri, data, successCallback) {
            var http = $http; AuthService.SetHeader(http);

            http.post(uri, data).success(function (response) {
                successCallback(response);
            }).error(function (error, status) {
                if (status != 500)
                    successCallback(error);
            });
        }
    }
}]);



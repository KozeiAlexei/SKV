//Сервис отправки запросов
angular.module('SKV').service('RequestService', ['$http', '$window', 'ToolsService', 'AuthService',
function ($http, $window, ToolsService, AuthService) {
    return {
        Get: function (uri, data, successCallback) {
            $http.get(uri, data).success(function (response) {
                successCallback(JSON.parse(response));
            }).error(function (error, status) {
                if (status < 0) {
                    ToolsService.ShowModal('ServiceUnavailableWindow');
                }
                else
                    ToolsService.ShowModal('ServerErrorWindow');
            });
        },

        Post: function (uri, data, successCallback) {
            var http = $http; AuthService.SetHeader(http);

            http.post(uri, data).success(function (response) {
                successCallback(response);
            }).error(function (error, status) {
                var r = 1;
            });
        },

        DownloadFile: function (uri) {
            var old = location.href;
            location.href = uri; location.href = old;
        },

        GetAccessToken: function (data, successCallback) {
            var pdata = "grant_type=password&username=" + data.username + "&password=" + data.password;
            $http.post('/Token', pdata, {
                headers:
                   { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (response) {
                successCallback(response)
            })
            .error(function (err, status) {
                var r = 1;
            });
        }
    }
}]);



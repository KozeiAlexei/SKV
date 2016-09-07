angular.module('SKV').service('LoginService', ['$http', '$q', 'AuthService', 'UserDataFactory',
    function ($http, $q, AuthService, UserDataFactory) {
        var self = this;

        var deferred_object;

        self.Login = function (user_name, password) {
            deferred_object = $q.defer();

            var data = "grant_type=password&username=" + user_name + "&password=" + password;
            $http.post('/Token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .success(function (response) {
                    AuthService.SetTokenInfo({
                        UserName: response.UserName,
                        AccessToken: response.access_token
                    });

                    UserDataFactory.UserData.IsAuthenticated = true;
                    UserDataFactory.UserData.UserName = response.UserName;

                    deferred_object.resolve(null);
                })
                .error(function (err, status) {
                    UserDataFactory.UserData.IsAuthenticated = false;
                    UserDataFactory.UserData.UserName = '';

                    deferred_object.resolve(err);
                });

            return deferred_object.promise;
        }
        self.Logout = function () {
            AuthService.RemoveToken();
            UserDataFactory.UserData.IsAuthenticated = false;
            UserDataFactory.UserData.UserName = '';
        }
    }
]);
angular.module('SKV').factory('UserDataFactory', [function () {
    var user_data_factory = {};

    var user_data = {
        UserName: '',
        IsAuthenticated: false
    };

    user_data_factory.UserData = user_data;

    return user_data_factory;
}]);
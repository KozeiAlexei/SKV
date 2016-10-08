angular.module('SKV').service('$roles', ['$request', function ($request) {
    return {
        GetRoles: function (callback) {
            callback(['Администратор', 'Руководитель', 'Менеджер', 'Кассир']);
        }
    }
}]);
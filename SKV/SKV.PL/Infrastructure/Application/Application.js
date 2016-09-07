angular.module("SKV", ['ngRoute']).config(function ($routeProvider) {

    $routeProvider
        .when('/Home', { templateUrl: '/App/Home/Index' });

        

}).run(['$rootScope', 'AuthService', function ($rootScope, AuthService) {
    
}]);


angular.module('SKV').directive('dynamicTable', function () {
    return {
        scope: false,
        restrict: 'E',
        templateUrl: '../../Infrastructure/Templates/DynamicTableTemplate.html'
    }
});

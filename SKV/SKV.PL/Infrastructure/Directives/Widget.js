//Widget directive
angular.module('SKV').directive('widget', function () {
    return {
        scope: {
            title: '@',
        },

        restrict: 'E',
        transclude: true,
        templateUrl: '../../Infrastructure/Templates/WidgetTemlate.html'
    }
});
angular.module('SKV').service('$validation', ['$tools', function ($tools) {

    var errorStyle = 'border-color: #843534; -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 6px #ce8483; box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 6px #ce8483;';
    var noErrorStyle = 'border-color: #3c763d; -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075); box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 6px #67b168;';

    var notificationType = {
        Error: 'danger',
        Success: 'success'
    }

    return {
        ServerValidationErrorsParse: function (serverModelState, clientModelState) {
            angular.forEach(serverModelState, function (value, key) {
                if (key.toString() != '') {
                    var path = _.chain(key.toString().split('.')).rest(1).value();

                    var errorFlag = clientModelState;
                    for (var i = 0; i < path.length - 1; i++) {
                        errorFlag = errorFlag[path[i]];
                    }

                    errorFlag[path[path.length - 1]] = errorStyle;
                }
            });
        },

        ValidateField: function (fieldValue, flag, customValidationFunction) {
            var result = true & !$tools.IsNullOrEmpty(fieldValue);
            if (customValidationFunction != undefined)
                result &= customValidationFunction(fieldValue);

            flag.Flag &= result;
            if (!result)
                return errorStyle;

            return noErrorStyle;
        },

        ServerValidationNotificationsParse: function (serverModelState, clientNotifications) {
            clientNotifications.length = 0;

            angular.forEach(serverModelState[''], function (value, key) {
                clientNotifications.push({ Type: notificationType.Error, Text: value });
            });
        }

    }
}]);
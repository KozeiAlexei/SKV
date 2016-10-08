angular.module('SKV').service('ToolsService', ['LocationService', function (LocationService) {
    return {
        FormatDate: function (date) {

            var dd = date.getDate();
            if (dd < 10) dd = '0' + dd;

            var mm = date.getMonth() + 1;
            if (mm < 10) mm = '0' + mm;

            var yy = date.getFullYear();

            return dd + '.' + mm + '.' + yy;
        },

        ShowModal: function (id) {
            $('#' + id).modal('show');
        },

        HideModal: function (id) {
            $('#' + id).modal('hide');
        },

        ClearValidationErrors: function (validationErrors) {
            angular.forEach(validationErrors, function (value, key) {
                validationErrors[key] = false;
            })
        },

        GetLastElement: function (arr) {
            return arr[arr.length - 1];
        },

        IsNullOrEmpty: function (obj) {
            return (this.IsNullOrUndefined(obj) || obj.toString() == '')
        },

        IsNullOrUndefined: function(obj) {
            return (obj == undefined) || (obj == null);
        },

        IncorrectFieldString: function (name) {
            return 'Поле \'' + name + '\' не заполнено либо заполнено неверно!';
        },

        ApplyBoolAggregateFunction: function (arr, func) {
            var result = true;

            var null_check = this.IsNullOrUndefined;

            if (Object.prototype.toString.call(arr) === '[object Array]') {
                angular.forEach(arr, function (item) {
                    if (!null_check(item))
                        result &= func(item);
                });
            } else {
                angular.forEach(arr, function (value, key) {
                    if (!null_check(key) && !null_check(value))
                        result &= func(value);
                });
            }
         
            return result;
        },

        ApplyConjunction: function (arr) {
            return this.ApplyBoolAggregateFunction(arr, function (val) { return val; })
        },

        IsEmptyArray: function (arr) {
            return arr.length == 0;
        },

        IsEmptyObject: function (obj) {
            if (this.IsNullOrUndefined(obj))
                return false;
            else
                return Object.keys(obj).length <= 0;
        },

        GetId: function (object, func) {
            return object.toString() + '_' + func;
        },

        IsObject: function (obj) {
            return (Object.prototype.toString.call(obj) == '[object Object]')
        },

        Copy: function (obj) {
            return JSON.parse(JSON.stringify(obj));
        }
    }
}]);
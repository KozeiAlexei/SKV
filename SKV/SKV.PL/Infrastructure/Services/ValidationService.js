//Сервис валидации модели
angular.module('SKV').service('ValidationService', function () {
    return {
        Validate: function (model, validationErrors, columns) {
            var result = true; var titles = {};

            columns.forEach(function (item) {
                titles[item.Name] = item.Title;
            });

            this.ClearValidationErrors(validationErrors);

            angular.forEach(model, function (value, key) {
                if (titles[key] != undefined) {
                    if (typeof (model[key]) == 'number') {
                        if (model[key] == null || model[key] == undefined || model[key] <= 0) {
                            validationErrors[key] = 'Поле \'' + titles[key] + '\' не заполнено либо заполнено неверно!';
                            result = false;
                        }
                    }
                    else {
                        if (model[key] == null || model[key] == undefined || model[key].toString().trim() == '') {
                            validationErrors[key] = 'Поле \'' + titles[key] + '\' не заполнено!';
                            result = false;
                        }
                    }
                }
            });

            return result;
        },

        ClearValidationErrors: function (validationErrors) {
            angular.forEach(validationErrors, function (value, key) {
                validationErrors[key] = '';
            })
        },

        ValidateFields: function (fields) {
            var result = true;
            angular.forEach(fields, function (item) {
                item.Error = null;

                if (item.Value == null || item.Value == undefined || item.Value.toString().trim() == '') {
                    item.Error = 'Поле \'' + item.Title + '\' не заполнено!'; result = false;
                }
            });
            return result;
        },

        ClearFields: function (fields) {
            angular.forEach(fields, function (item) {
                item.Error = null;
            });
        },

        IsNullOrEmpty: function (obj) {
            if (obj == undefined || obj == null || obj == '')
                return true;
            return false;
        },

        IncorrectFieldString: function (name) {
            return 'Поле \'' + name + '\' не заполнено либо заполнено неверно!';
        }
    }
});

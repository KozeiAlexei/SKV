angular.module('SKV').controller('LoginController', ['ToolsService', 'LoginService',
function (ToolsService, LoginService) {
    var self = this;

    self.Model = {
        UserName: null,
        Password: null
    }

    self.ValidationErrors = {
        UserName: null,
        Password: null
    }

    self.Initialize = function () {
        $('#LoginError').hide();
        $('#LoginSuccessfull').hide();
    }

    self.Login = function () {
        ToolsService.ClearValidationErrors(self.ValidationErrors);
        if (!ToolsService.IsNullOrEmpty(self.Model.UserName)) {
            if (!ToolsService.IsNullOrEmpty(self.Model.Password)) {
                LoginService.Login(self.Model.UserName, self.Model.Password).then(function (response) {
                    if (response != null && response.error != undefined) {
                        $('#LoginSuccessfull').hide();
                        $("#LoginError").show().animate({ "opacity": "1", "bottom": "-80px" }, 400);
                    }
                    else {
                        $('#LoginError').hide();
                        $("#LoginSuccessfull").show().animate({ "opacity": "1", "bottom": "-80px" }, 400);

                        location.href = '/Home/Index';
                    }
                });         
            } else { $("#Password").css({ "border-color": "#ff0000" }); }
        } else { $("#UserName").css({ "border-color": "#ff0000" }); }
    }

    self.Initialize();
}]);
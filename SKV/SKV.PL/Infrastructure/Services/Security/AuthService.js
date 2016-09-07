angular.module('SKV').service('AuthService', ['$http', '$q', '$window',  function ($http, $q, $window) {  
    var self = this; const TOKEN_INFO = 'TokenInfo';
    
    var token_info;  
  
    self.SetTokenInfo = function (info) {  
        token_info = info;  
        $window.sessionStorage[TOKEN_INFO] = JSON.stringify(token_info);  
    }  
  
    self.GetTokenInfo = function () {  
        return token_info;  
    }  
  
    self.RemoveToken = function () {  
        token_info = null;  
        $window.sessionStorage[TOKEN_INFO] = null;  
    }  
  
    self.Initialize = function () {  
        if ($window.sessionStorage[TOKEN_INFO]) {  
            token_info = JSON.parse($window.sessionStorage[TOKEN_INFO]);  
        }  
    }  
  
    self.SetHeader = function (http) {  
        delete http.defaults.headers.common['X-Requested-With'];  
        if ((token_info != undefined) && (token_info.AccessToken != undefined) && 
            (token_info.AccessToken != null) && (token_info.AccessToken != '')) {  
            http.defaults.headers.common['Authorization'] = 'Bearer ' + token_info.AccessToken;  
            http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';  
        }  
    }  
    
    self.Initialize();  
}]);   
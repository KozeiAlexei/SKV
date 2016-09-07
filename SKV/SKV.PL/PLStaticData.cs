using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SKV.PL
{
    public class PLStaticData
    {
        public static string LoginTitle { get; } = "Вход в систему";

        public static string Login { get; } = "Имя пользователя";

        public static string Password { get; } = "Пароль";

        public static string LoginError { get; } = "Имя пользователя или пароль указаны неверно!";

        public static string LoginSuccessfull { get; } = "Вход выполнен";

        public static string SystemLoading { get; } = "Загрузка системы";

        public static string CultureCookieName { get; } = "__UICULTURECOOKIE__";
    }
}
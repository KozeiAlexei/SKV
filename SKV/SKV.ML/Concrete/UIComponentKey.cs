using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.ML.Concrete
{
    public enum UIComponentKey
    {
        UserManager_UserName_Field,
        UserManager_Email_Field,
        UserManager_UserProfile_Name_Field,
        UserManager_PhoneNumber_Field,
        UserManager_UserProfile_AsteriskId,
        UserManager_Roles,

        UserCreating_UserName_Field,
        UserCreating_Email_Field,
        UserCreating_Initials_Field,
        UserCreating_PhoneNumber_Field,
        UserCreating_AsteriskId,
        UserCreating_Roles,
        UserCreating_Password,
        UserCreating_PasswordConfirm,

        PasswordChanging_OldPassword,
        PasswordChanging_NewPassword,
        PasswordChanging_NewPasswordConfirm,

        RoleManager_Name_Field,
        RoleManager_PageInstance_Name_Field,
        RoleManager_Permissions
    }
}

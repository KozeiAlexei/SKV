using SKV.PL.ClientSide.Components.VerticalFormField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SKV.PL.Models.PartialViewModels.Administration.Security
{
    public class RoleMainPropertiesTabModel
    {
        public List<VerticalFormFieldMvcModel> Fields { get; } = new List<VerticalFormFieldMvcModel>();
    }

    public class RolePermissionsTabModel
    {
        public List<VerticalFormFieldMvcModel> Fields { get; } = new List<VerticalFormFieldMvcModel>();
    }
}
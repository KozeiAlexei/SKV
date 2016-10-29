using SKV.PL.ClientSide.Abstract.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SKV.PL.ClientSide.Components.VerticalFormField
{
    public class VerticalFormFieldMvcModel
    {
        [Required]
        public string Title { get; set; }

        public string LocalizedTitle { get; set; }

        [Required]
        public string FieldPath { get; set; }

        public string CustomAttributes { get; set; }


        public string Style { get; set; }

        public string IconClass { get; set; }


        [Required]
        public UIFieldType Type { get; set; }


        public string ButtonTitleFieldPath { get; set; }

        public string ButtonClickFunctionName { get; set; }
    }
}
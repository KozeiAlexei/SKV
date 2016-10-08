using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SKV.PL.ClientSide.Components.Tabs
{
    public class TabHeaderMvcModel
    {
        public bool Active { get; set; } = false;

        [Required]
        public string Title { get; set; }

        [Required]
        public string BodyId { get; set; }
    }

    public class TabBodyMvcModel
    {
        [Required]
        public string Id { get; set; }

        public bool Active { get; set; } = false;
        public IContainer Body { get; set; } = Tools.CreateContainer();
    }

    public class TabsMvcModel
    {
        [Required]
        public string Id { get; set; }

        public List<TabBodyMvcModel> Body { get; } = new List<TabBodyMvcModel>();
        public List<TabHeaderMvcModel> Headers { get; } = new List<TabHeaderMvcModel>();
    }
}
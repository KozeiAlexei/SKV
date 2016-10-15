using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;

namespace SKV.PL.ClientSide.Components.Tabs
{
    public class TabMvcModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public bool Active { get; set; } = false;

        public IContainer Body { get; set; } = Tools.CreateContainer();
    }

    public class TabsMvcModel
    {
        [Required]
        public string Id { get; set; }

        public List<TabMvcModel> Tabs { get; set; } = new List<TabMvcModel>();
    }
}
using System.ComponentModel.DataAnnotations;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;

namespace SKV.PL.ClientSide.Components.Widget
{
    public class WidgetMvcModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public IContainer Body { get; set; } = Tools.CreateContainer();
    }
}
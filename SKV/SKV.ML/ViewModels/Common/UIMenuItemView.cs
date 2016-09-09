using System.Collections.Generic;

namespace SKV.ML.ViewModels.Common
{
    public class UIMenuItemView
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public string IconClass { get; set; }
        public string Controller { get; set; }

        public int Location { get; set; }

        public List<UIMenuItemView> Childs { get; set; } = new List<UIMenuItemView>();
    }
}

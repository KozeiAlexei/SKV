using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.UIModel;

namespace SKV.ML.Concrete.Model.UIModel
{
    public class UIMenuItem : IUIMenuItem<int, int?>
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string Name { get; set; }
        public string Action { get; set; }
        public string IconClass { get; set; }
        public string Controller { get; set; }

        public int Location { get; set; }

        public void CopyFrom(IUIMenuItem<int, int?> from)
        {
            Id = from.Id;
            ParentId = from.ParentId;

            Name = from.Name;
            Action = from.Action;
            IconClass = from.IconClass;
        }
    }
}

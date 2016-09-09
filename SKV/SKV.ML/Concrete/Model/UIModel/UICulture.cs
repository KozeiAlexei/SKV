using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.UIModel;

namespace SKV.ML.Concrete.Model.UIModel
{
    public class UICulture : IUICulture<int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Culture { get; set; }

        public void CopyFrom(IUICulture<int> from)
        {
            Id = from.Id;
            Name = from.Name;
            Culture = from.Culture;
        }
    }
}

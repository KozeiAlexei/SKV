using System.ComponentModel.DataAnnotations;

using SKV.DAL.Abstract.Model.UIModel;

namespace SKV.DAL.Concrete.Model.UIModel
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

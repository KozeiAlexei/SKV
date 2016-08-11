using System.ComponentModel.DataAnnotations;

using SKV.DAL.Abstract.Model.CommonModel;

namespace SKV.DAL.Concrete.Model.CommonModel
{
    public class Page : IPage<int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public void CopyFrom(IPage<int> from)
        {
            Id = from.Id;
            URL = from.URL;
            Name = from.Name;
        }
    }
}

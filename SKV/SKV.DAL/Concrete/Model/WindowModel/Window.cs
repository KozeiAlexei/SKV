using System.ComponentModel.DataAnnotations;

using SKV.DAL.Abstract.Model.WindowModel;

namespace SKV.DAL.Concrete.Model.WindowModel
{
    public enum WindowStatus
    {
        Active,
        Inactive
    }

    public class Window : IWindow<int, WindowStatus>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public WindowStatus Status { get; set; }

        public void CopyFrom(IWindow<int, WindowStatus> from)
        {
            Id = from.Id;
            Name = from.Name;
            Status = from.Status;
        }
    }
}

using SKV.ML.Abstract.Model.UIModel;

namespace SKV.ML.Concrete.Model.UIModel
{
    public class UIComponentData : IUIComponentData<int, string>
    {
        public int Id { get; set; }

        public string TypeName { get; set; }

        public string SerializedData { get; set; }

        public void CopyFrom(IUIComponentData<int, string> from)
        {
            Id = from.Id;
            TypeName = from.TypeName;
            SerializedData = from.SerializedData;
        }
    }
}

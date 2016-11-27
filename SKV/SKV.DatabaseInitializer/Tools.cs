using System;

using Newtonsoft.Json;

using SKV.ML.Concrete;
using SKV.ML.Concrete.Model.UIModel;
using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Components.VerticalFormField;

namespace SKV.DatabaseInitializer
{
    public class Tools
    {
        public static JsonSerializerSettings GetSerializerSettings() => new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public static UIComponentData CreateUIComponentData<TUIComponent>(UIComponentKey id, TUIComponent model) where TUIComponent : IExportToModel<VerticalFormFieldMvcModel>
        {
            var modelExporter = model as IExportToModel<VerticalFormFieldMvcModel>;
            if (modelExporter == null)
                throw new InvalidOperationException();

            return new UIComponentData()
            {
                Id = (int)id,
                TypeName = typeof(TUIComponent).Name,
                SerializedData = JsonConvert.SerializeObject(modelExporter.ExportToModel(), GetSerializerSettings())
            };
        }
    }
}


using SKV.PL.ClientSide.Abstract.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;
using System.Dynamic;
using System.Text;
using SKV.ML.Concrete.Model.UserModel;
using System.Reflection;

namespace SKV.PL.ClientSide.Components.VerticalFormField
{
    public class VerticalFormFieldMvc : IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType>
    {
        #region Constructor

        public VerticalFormFieldMvc()
        {
            Model = new VerticalFormFieldMvcModel();
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private VerticalFormFieldMvcModel Model { get; set; }
        private IResponsibilityChain<VerticalFormFieldMvc> Chain { get; set; }

        #endregion

        #region Component setting

        public IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType> Field<TModel>(Expression<Func<TModel, object>> field)
        {
            return Chain.Responsibility(() =>
            {
                Model.FieldPath = field.GetPathWithoutSource().Replace(")", string.Empty); //fix reflection bug
                Title($"{ typeof(TModel).Name }.{ Model.FieldPath }");
            });
        }

        public IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType> Field<TModel>(string field)
        {
            return Chain.Responsibility(() =>
            {
                Model.FieldPath = field;
                Title($"{ typeof(TModel).Name }.{ Model.FieldPath }");
            });
        }

        public IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType> Icon(string icon) => Chain.Responsibility(() => Model.IconClass = icon);
        public IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType> Title(string title) => Chain.Responsibility(() =>
        {
            Model.Title = title;
            Model.LocalizedTitle = Tools.GetLocalizedString(Model.Title);
        });
        public IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType> Attributes(dynamic attrs)
        {
            return Chain.Responsibility(() =>
            {
                var builder = new StringBuilder();

                foreach (var attr in ((object)attrs).GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    builder.Append($"{ attr.Name }=\"{ attr.GetValue(attrs) }\"");

                Model.CustomAttributes = builder.ToString();
            });
        }

        #endregion

        public MvcHtmlString Render() => new ComponentRenderer(nameof(VerticalFormFieldMvc)).Render(Model);

        public VerticalFormFieldMvcModel ExportToModel() => Model;

        public IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType> ImportFromModel(VerticalFormFieldMvcModel model) 
        {
            return Chain.Responsibility(() =>
            {
                Model.Title = model.Title; Title(model.Title);
                Model.Style = model.Style;
                Model.FieldPath = model.FieldPath;
                Model.IconClass = model.IconClass;
                Model.CustomAttributes = model.CustomAttributes;

                Model.Type = model.Type;
                Model.ButtonTitleFieldPath = model.ButtonTitleFieldPath;
                Model.ButtonClickFunctionName = model.ButtonClickFunctionName;
            });
        }

        public IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType> Type(UIFieldType type) => 
            Chain.Responsibility(() => Model.Type = type);

        public IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType> ButtonTitleFieldPath(string path) =>
            Chain.Responsibility(() => Model.ButtonTitleFieldPath = $".{ path }");

        public IVerticalFormField<VerticalFormFieldMvcModel, UIFieldType> ButtonClickFunctionName(string name) =>
           Chain.Responsibility(() => Model.ButtonClickFunctionName = name);
    }
}
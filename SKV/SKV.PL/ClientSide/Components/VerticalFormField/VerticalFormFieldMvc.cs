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
using SKV.ML.Metadata;

namespace SKV.PL.ClientSide.Components.VerticalFormField
{
    public class VerticalFormFieldMvc : IVerticalFormField<VerticalFormFieldMvcModel>
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

        public IVerticalFormField<VerticalFormFieldMvcModel> Field<TModel>(Expression<Func<TModel, object>> field)
        {
            return Chain.Responsibility(() =>
            {
                Model.FieldPath = field.GetPathWithoutSource() ;
                Title(Tools.GetLocalizedString($"{ typeof(TModel).Name }.{ Model.FieldPath }"));
            });
        }

        public IVerticalFormField<VerticalFormFieldMvcModel> Icon(string icon) => Chain.Responsibility(() => Model.IconClass = icon);
        public IVerticalFormField<VerticalFormFieldMvcModel> Title(string title) => Chain.Responsibility(() => Model.Title = title);
        public IVerticalFormField<VerticalFormFieldMvcModel> Attributes(dynamic attrs)
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

        public IVerticalFormField<VerticalFormFieldMvcModel> ImportFromModel(VerticalFormFieldMvcModel model) 
        {
            return Chain.Responsibility(() =>
            {
                Model.Title = model.Title;
                Model.Style = model.Style;
                Model.FieldPath = model.FieldPath;
                Model.IconClass = model.IconClass;
                Model.CustomAttributes = model.CustomAttributes;
            });
        }
    }
}
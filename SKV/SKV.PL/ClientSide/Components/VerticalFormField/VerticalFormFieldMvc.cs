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
    public class VerticalFormFieldMvc : IVerticalFormField
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

        public IVerticalFormField Field<TModel>(Expression<Func<TModel, object>> field)
        {
            return Chain.Responsibility(() =>
            {
                Model.FieldPath = field.GetPathWithoutSource() ;

                var icon_md = field.GetAttribute<IconAttribute, TModel, object>();
                var title_md = field.GetAttribute<TitleAttribute, TModel, object>();

                if (icon_md != null)
                    Icon(icon_md.IconClass);

                if(title_md != null)
                {
                    if (title_md.Source == ParameterSource.Resource)
                        Title(Tools.GetLocalizedString($"{ typeof(TModel).Name }.{ Model.FieldPath }"));
                    else
                        Title(title_md.Title);
                }
            });
        }

        public IVerticalFormField Icon(string icon) => Chain.Responsibility(() => Model.IconClass = icon);
        public IVerticalFormField Title(string title) => Chain.Responsibility(() => Model.Title = title);

        #endregion

        public MvcHtmlString Render() => new ComponentRenderer(nameof(VerticalFormFieldMvc)).Render(Model);

        public IVerticalFormField Attributes(dynamic attrs)
        {
            return Chain.Responsibility(() =>
            {
                var builder = new StringBuilder();

                foreach (var attr in ((object)attrs).GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    builder.Append($"{ attr.Name }=\"{ attr.GetValue(attrs) }\"");

                Model.CustomAttributes = builder.ToString();
            });
        }
    }
}
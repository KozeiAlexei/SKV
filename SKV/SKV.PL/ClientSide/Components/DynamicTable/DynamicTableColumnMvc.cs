using System.Web.Mvc;

using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;
using System.Linq.Expressions;
using System;

namespace SKV.PL.ClientSide.Components.DynamicTable
{
    public class DynamicTableColumnMvc : IDynamicTableColumn
    {
        #region Constructor

        public DynamicTableColumnMvc()
        {
            Model = new DynamicTableColumnModelMvc();
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private DynamicTableColumnModelMvc Model { get; set; }
        private IResponsibilityChain<DynamicTableColumnMvc> Chain { get; set; }

        #endregion

        #region Component setting

        //public IDynamicTableColumn Name(string name) => Chain.Responsibility(() => Model.FieldPath = name);
        public IDynamicTableColumn TitleKey(string key) => Chain.Responsibility(() => Model.Title = new LocalizedData(key));

        public IDynamicTableColumn Width(uint width) => Chain.Responsibility(() => Model.Width = width);

        public IDynamicTableColumn Editable(bool editable) => Chain.Responsibility(() => Model.Editable = editable);
        public IDynamicTableColumn Filterable(bool filterable) => Chain.Responsibility(() => Model.Filterable = filterable);

        public IDynamicTableColumn Type(TableColumnDataType type) => Chain.Responsibility(() => Model.Type = type);

        public IDynamicTableColumn Field<TModel>(Expression<Func<TModel, object>> field)
        {
            return Chain.Responsibility(() =>
            {
                Model.FieldPath = field.GetPathWithoutSource().Replace(")", string.Empty); //fix reflection bug
                TitleKey($"{ typeof(TModel).Name }.{ Model.FieldPath }");
            });
        }

        public IDynamicTableColumn Field<TModel>(string field)
        {
            return Chain.Responsibility(() =>
            {
                Model.FieldPath = field;
                TitleKey($"{ typeof(TModel).Name }.{ Model.FieldPath }");
            });
        }

        #endregion

        public MvcHtmlString Render() => new ComponentRenderer(nameof(DynamicTableColumnMvc)).Render(Model);
    }
}
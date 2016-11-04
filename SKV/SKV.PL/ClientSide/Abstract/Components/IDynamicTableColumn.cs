using SKV.PL.ClientSide.Abstract.Features;
using System;
using System.Linq.Expressions;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public enum TableColumnDataType
    {
        Text,
        Number,
        Actions,
        Dropdown,
        Currency,
        Component
    }

    public interface IDynamicTableColumn : IComponent, 
                                           /*INameable<IDynamicTableColumn>, */ILocalizedTitle<IDynamicTableColumn>, IWidthable<IDynamicTableColumn>,
                                           IEditable<IDynamicTableColumn>, IFilterable<IDynamicTableColumn>, 
                                           ITypeable<IDynamicTableColumn, TableColumnDataType>
    {
        IDynamicTableColumn Field<TModel>(Expression<Func<TModel, object>> field);

        IDynamicTableColumn Field<TModel>(string field);

    }
}

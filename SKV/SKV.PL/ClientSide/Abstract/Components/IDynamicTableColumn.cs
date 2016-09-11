using SKV.PL.ClientSide.Abstract.Features;

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
                                           INameable<IDynamicTableColumn>, ITitleable<IDynamicTableColumn>, IWidthable<IDynamicTableColumn>,
                                           IEditable<IDynamicTableColumn>, IFilterable<IDynamicTableColumn>, 
                                           ITypeable<IDynamicTableColumn, TableColumnDataType>
    {       
    }
}

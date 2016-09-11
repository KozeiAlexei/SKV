using SKV.PL.ClientSide.Abstract.Features;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface IDynamicTable : IComponent, 
                                     IIdable<IDynamicTable>, ITitleable<IDynamicTable>, 
                                     IEditable<IDynamicTable>, IFilterable<IDynamicTable>, IColumnHaveable<IDynamicTable>
    {
        string ComponentAngularApplicationName { get; set; }
        string ComponentAngularTableSettinsFactoryName { get; set; }
        string ComponentAngularDynamicTableControllerName { get; set; }
        string ComponentAngularDynamicTableActionsControllerName { get; set; }

        IDynamicTable AngularApplicationName(string name);
        IDynamicTable AngularTableSettinsFactoryName(string name);
        IDynamicTable AngularDynamicTableControllerName(string name);
        IDynamicTable AngularDynamicTableActionsControllerName(string name);
    }
}

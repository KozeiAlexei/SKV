using SKV.PL.ClientSide.Abstract.Features;
using System;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface IDynamicTable : IComponent, 
                                     IIdable<IDynamicTable>, ITitleable<IDynamicTable>, 
                                     IEditable<IDynamicTable>, IFilterable<IDynamicTable>, IColumnHaveable<IDynamicTable>,
                                     ILogicHaveable<IDynamicTable>, IBodyHaveable<IDynamicTable>, IPaginable<IDynamicTable>
    {
        IDynamicTable AngularTableSettingsFactoryName(string name);
        IDynamicTable AngularDynamicTableControllerName(string name);
        IDynamicTable AngularDynamicTableActionsController(string name);
        IDynamicTable AngularDynamicTableActionsControllerName(string name);

        IDynamicTable RowActions(Action<IContainer> body);

        IDynamicTable BottomManagmentPanel(Action<IContainer> panel);
    }
}

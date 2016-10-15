using System.ComponentModel.DataAnnotations;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract.Components;

namespace SKV.PL.ClientSide.Components.DynamicTable
{
    public class DynamicTableModelMvc
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public bool Editable { get; set; } = false;
        public bool Filterable { get; set; } = false;

        public bool Paginable { get; set; } = true;
        public uint PageSize { get; set; } = ClientSideConfiguration.DefaultTablePageSize;

        [Required]
        public string AngularApplicationName { get; set; } = ClientSideConfiguration.AngularApplicationName;

        [Required]
        public string AngularTableSettingsFactoryName { get; set; }

        [Required]
        public string AngularDynamicTableControllerName { get; set; } = ClientSideConfiguration.AngularDynamicTableControllerName;

        [Required]
        public string AngularDynamicTableActionsController { get; set; }

        [Required]
        public string AngularDynamicTableActionsControllerName { get; set; }

        public IContainer Body { get; set; } = Tools.CreateContainer();
        public IContainer Logic { get; set; } = Tools.CreateContainer();
        public IContainer Columns { get; set; } = Tools.CreateContainer();
        public IContainer RowActions { get; set; } = Tools.CreateContainer();
        public IContainer TopManagmentPanel { get; set; } = Tools.CreateContainer();
        public IContainer BottomManagmentPanel { get; set; } = Tools.CreateContainer();
    }

    public class DynamicTableColumnModelMvc
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        public uint Width { get; set; }

        public bool Editable { get; set; } = false;
        public bool Filterable { get; set; } = false;

        public TableColumnDataType Type { get; set; } = TableColumnDataType.Text;
    }

    public class DynamicTableActionModelMvc
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Icon { get; set; }

        [Required]
        public string Class { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Click { get; set; } = @"function(row) {}";

        public string Visible { get; set; } = @"function(row) {}";
    }
}
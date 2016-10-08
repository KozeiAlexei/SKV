using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Features;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public enum FunctionType
    {
        Custom,
        Referrence
    }

    public interface IDynamicTableAction<TFunctionType, TFunction> : IComponent,
                                                                     IIdable<IDynamicTableAction<TFunctionType, TFunction>>,
                                                                     ITitleable<IDynamicTableAction<TFunctionType, TFunction>>, 
                                                                     IIconHaveable<IDynamicTableAction<TFunctionType, TFunction>, string>
    {
        IDynamicTableAction<TFunctionType, TFunction> Class(string @class);

        IDynamicTableAction<TFunctionType, TFunction> Click(TFunctionType func_type, TFunction function);

        IDynamicTableAction<TFunctionType, TFunction> Visible(TFunctionType func_type, TFunction function);
    }
}

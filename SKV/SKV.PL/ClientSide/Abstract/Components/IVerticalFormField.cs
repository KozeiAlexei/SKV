using SKV.PL.ClientSide.Abstract.Features;
using System;
using System.Linq.Expressions;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public enum UIFieldType
    {
        Input,
        Buttons,
        Dropdown,
        SelectListBox
    }

    public interface IVerticalFormField<TComponentModel, TFieldType> : IComponent, 
                                                           ITitleable<IVerticalFormField<TComponentModel, TFieldType>>, 
                                                           IIconHaveable<IVerticalFormField<TComponentModel, TFieldType>, string>,
                                                           IExportToModel<TComponentModel>,
                                                           IImportFromModel<IVerticalFormField<TComponentModel, TFieldType>, TComponentModel>
    {
        IVerticalFormField<TComponentModel, TFieldType> Field<TModel>(Expression<Func<TModel, object>> field);

        IVerticalFormField<TComponentModel, TFieldType> Field<TModel>(string field);

        IVerticalFormField<TComponentModel, TFieldType> Attributes(dynamic attrs);

        IVerticalFormField<TComponentModel, TFieldType> Type(TFieldType type);

        IVerticalFormField<TComponentModel, TFieldType> ModelPath(string path);

        IVerticalFormField<TComponentModel, TFieldType> ButtonTitleFieldPath(string path);
        IVerticalFormField<TComponentModel, TFieldType> ButtonClickFunctionName(string name);

        IVerticalFormField<TComponentModel, TFieldType> ControllerName(string name);
    }
}

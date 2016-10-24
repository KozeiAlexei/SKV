using SKV.PL.ClientSide.Abstract.Features;
using System;
using System.Linq.Expressions;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface IVerticalFormField<TComponentModel> : IComponent, 
                                                           ITitleable<IVerticalFormField<TComponentModel>>, 
                                                           IIconHaveable<IVerticalFormField<TComponentModel>, string>,
                                                           IExportToModel<TComponentModel>,
                                                           IImportFromModel<IVerticalFormField<TComponentModel>, TComponentModel>
    {
        IVerticalFormField<TComponentModel> Field<TModel>(Expression<Func<TModel, object>> field);
        IVerticalFormField<TComponentModel> Attributes(dynamic attrs);
    }
}

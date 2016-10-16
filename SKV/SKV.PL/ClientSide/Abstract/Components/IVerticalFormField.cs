using SKV.PL.ClientSide.Abstract.Features;
using System;
using System.Linq.Expressions;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface IVerticalFormField : IComponent, ITitleable<IVerticalFormField>, IIconHaveable<IVerticalFormField, string>
    {
        IVerticalFormField Field<TModel>(Expression<Func<TModel, object>> field);
        IVerticalFormField Attributes(dynamic attrs);
    }
}

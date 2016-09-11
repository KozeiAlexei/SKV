using System;

namespace SKV.PL.ClientSide.Abstract
{
    public interface IResponsibilityChain<TSubject>
    {
        TSubject Responsibility(Action resp);
    }
}

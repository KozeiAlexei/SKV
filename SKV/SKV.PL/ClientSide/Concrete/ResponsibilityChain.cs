using System;

using SKV.PL.ClientSide.Abstract;

namespace SKV.PL.ClientSide.Concrete
{
    public class ResponsibilityChain<TSubject> : IResponsibilityChain<TSubject> where TSubject: class
    {
        private TSubject @object = default(TSubject);

        public ResponsibilityChain(TSubject obj)
        {
            @object = obj;
        }

        public TSubject Responsibility(Action resp)
        {
            resp();
            return @object;
        }
    }
}
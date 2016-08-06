namespace SKV.DAL.Abstract.Entity
{
    public interface ICloneableFrom<TCloneableObject>
    {
        void CopyFrom(TCloneableObject from);
    }
}

namespace SKV.ML.Abstract.Entity
{
    public interface ICloneableFrom<TCloneableObject>
    {
        void CopyFrom(TCloneableObject from);
    }
}

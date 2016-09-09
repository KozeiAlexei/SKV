namespace SKV.ML.Abstract.Entity
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}

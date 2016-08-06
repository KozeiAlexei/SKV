namespace SKV.DAL.Abstract.Entity
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}

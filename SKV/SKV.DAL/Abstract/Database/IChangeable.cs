namespace SKV.DAL.Abstract.Database
{
    public interface IChangeable
    {
        void Refresh();

        void SaveChanges();
    }
}

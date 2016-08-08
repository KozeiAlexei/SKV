namespace SKV.DAL.Abstract.Database
{
    public interface IDbManager : IChangeable
    {
        object ExecuteQuery(string query);
    }
}

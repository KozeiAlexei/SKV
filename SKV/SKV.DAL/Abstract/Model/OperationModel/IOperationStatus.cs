using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.OperationModel
{
    public interface IOperationStatus<TKey, TOperation, TStatus> : IEntity<TKey>, ICloneableFrom<IOperationStatus<TKey, TOperation, TStatus>>
    {
        string Name { get; set; }

        string Text { get; set; }

        string Description { get; set; }


        TStatus StatusCode { get; set; }

        TOperation OperationType { get; set; }
    }
}

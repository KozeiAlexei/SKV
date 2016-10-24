using SKV.ML.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.ML.Abstract.Model.UIModel
{
    public interface IUIComponentData<TKey, TComponentData> : IEntity<TKey>, ICloneableFrom<IUIComponentData<TKey, TComponentData>>
    {
        TComponentData SerializedData { get; set; }
    }
}

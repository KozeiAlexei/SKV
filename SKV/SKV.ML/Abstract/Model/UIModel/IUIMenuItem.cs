﻿using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.UIModel
{
    public interface IUIMenuItem<TKey, TParentKey> : IEntity<TKey>, ICloneableFrom<IUIMenuItem<TKey, TParentKey>>
    {
        TParentKey ParentId { get; set; }

        string Name { get; set; }
        string Action { get; set; }
        string IconClass { get; set; }
        string Controller { get; set; }

        int Location { get; set; }
    }
}
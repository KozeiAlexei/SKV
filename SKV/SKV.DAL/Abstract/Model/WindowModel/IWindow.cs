﻿using SKV.DAL.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Abstract.Model.WindowModel
{
    public interface IWindow<TKey, TWindowStatus> : IEntity<TKey>, ICloneableFrom<IWindow<TKey, TWindowStatus>>
    {
        string Name { get; set; }


        TWindowStatus Status { get; set; }
    }
}

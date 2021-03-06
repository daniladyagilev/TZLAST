using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace SP_Dyagilev
{
    interface IView
    {
        event Action OpenDB;
        public event Action Analyze;

        List<Stat> DataListDB { set; }
        Guid CurrentItemInDB { get; }

        //List<Stat> GetStatsFromDB { get; }

    }
}

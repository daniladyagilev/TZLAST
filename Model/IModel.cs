using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP_Dyagilev
{
    interface IModel
    {
        List<Stat> GetStatsFromDB();

        List<Stat> DataList { get; set; }
    }
}

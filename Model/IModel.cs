using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP_Dyagilev
{
    interface IModel
    {
        List<Stat> GetStatsFromDB();

        //string GET(string url);
    //    List<Stat> DataList { get; set; }
    }
}

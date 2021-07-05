using Logic;
using Logic.Database;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SP_Dyagilev
{
    class Model : IModel
    {
        private IDBModel iDBModel;
        // List<Stat> IModel.DataList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public Model(IDBModel iDBModel)
        {
            this.iDBModel = iDBModel;
        }

        public List<Stat> GetStatsFromDB()
        {
            return iDBModel.GetStatsFromDB();
        }
    }
}

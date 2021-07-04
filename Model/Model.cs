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
        //private List dataList;
        private string pathFile;
        public string PathFile
        {
            get { return pathFile; }
        }
        //public List DataList { get => dataList; set => dataList = value; }
        List<Stat> IModel.DataList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Model(IDBModel iDBModel)
        {
            this.iDBModel = iDBModel;

            

        }
        public string Analyzer(string[] lines)
        {
            return "";
        }
        private object instance;
        private MethodInfo method;

        #region MSSQLDB

        public List<Stat> GetNodes()
        {
            return iDBModel.GetStats();
        }

        public List<Stat> GetStats()
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}

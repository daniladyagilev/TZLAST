using System;
using System.Collections.Generic;
using System.Text;

namespace SP_Dyagilev
{
    class Presenter
    {
        private IView view;
        private IModel model;

        public Presenter(IView view, IModel model)
        {
            this.view = view;
            this.model = model;
            view.OpenDB += OpenDB;
        }
        public void OpenDB()
        {
            view.DataListDB = model.GetStatsFromDB();
        }

    }
}

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
            view.Analyze += Analyzer;


            
        }


        #region DB
        public void OpenDB()
        {
            view.DataListDB = model.GetStats();
        }

        #endregion



        public void Analyzer()
        {
            try
            {
                //string res = model.Analyzer(view.AnalyzerCode);
                //view.AnalyzerResult = res;
                //view.LogBox = res;
            }
            catch (ArgumentOutOfRangeException)
            {
                view.LogBox = "При выполнении анализа произошла ошибка: входная строка имеет неверный формат.";
                //view.AnalyzerResult = "Введите корректные данные!";
            }
            catch (Exception ex)
            {
                view.LogBox = "При выполнении анализа произошла ошибка: " + ex.Message;
                //view.AnalyzerResult = "[Ошибка]";
            }
        }



    }
}

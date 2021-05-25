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
            view.CreateFile += CreateFile;
            view.OpenFile += OpenFile;
            view.AddElem += AddElem;
            view.NativeFunction += NativeFunction;
            view.AddToDB += AddToDB;

            view.EditInDB += EditInDB;

            view.RemFromDB += Rem;

            view.SaveFile += SaveFile;

            view.RemFile += RemElem;

            view.EditFile += EditElem;

            view.SaveFileAs += SaveFileAs;
        }


        #region DB
        public void OpenDB()
        {
            view.DataListDB = model.GetNodes();
        }

        public void AddToDB()
        {
          //  try
           // {
                model.AddNode();  //must be true

                OpenDB();
        //    }
         //   catch (Exception ex)
//            {
          //      view.LogBox = "Произошла ошибка: " + ex.Message;
          //  }
        }

        public void EditInDB()
        {
        
                
                if (!model.EditNode(view.CurrentItemInDB))
                   throw new Exception("Элементт не был отредактироан в БД "); //FileName
                view.LogBox = "Элемент успешно отредактирован в БД";
                OpenDB();

         
        }

        public void Rem() {
            if (!model.DeleteNode(view.CurrentItemInDB))
                throw new Exception("Элементт не был удалён из БД "); //FileName
            view.LogBox = "Элемент успешно удалён из БД";
            OpenDB();
        }


        #endregion





        public void Analyzer()
        {
            try
            {
                string res = model.Analyzer(view.AnalyzerCode);
                view.AnalyzerResult = res;
                view.LogBox = res;
            }
            catch (ArgumentOutOfRangeException)
            {
                view.LogBox = "При выполнении анализа произошла ошибка: входная строка имеет неверный формат.";
                view.AnalyzerResult = "Введите корректные данные!";
            }
           // catch (Exception ex)
           // {
                //view.LogBox = "При выполнении анализа произошла ошибка: " + ex.Message;
                //view.AnalyzerResult = "[Ошибка]";
            //}
        }

        public void CreateFile()
        {
            try
            {
                var tmp = model.CreateFile();
                if (tmp == null) { throw new Exception("Файл не был сохранён."); }
                view.DataList = tmp;
                view.LogBox = "Файл успешно создан";
                view.PathFile = model.PathFile;
                //view.ElemActionsPanelVisible = true;
            }
            catch (Exception ex)
            {
              //  if (model.PathFile == null)
                //    view.ElemActionsPanelVisible = false;
              view.LogBox = "Произошла ошибка: " + ex.Message;
            }
        }

        public void OpenFile()
        {
            try
            {
                var tmp = model.OpenFile();
                if (tmp == null) { throw new Exception("Файл не был открыт."); }

                view.DataList = tmp;
                view.LogBox = "Файл успешно загружен";
                view.PathFile = model.PathFile;
                //view.ElemActionsPanelVisible = true;
            }
            catch (Exception ex)
            {
                //if (model.PathFile == null)
                //    view.ElemActionsPanelVisible = false;
                view.LogBox = "Произошла ошибка: " + ex.Message;
            }
        }

        public void AddElem()
        {
            try
            {
                if (!model.AddElem())
                    throw new Exception("Элемент не был добавлен");
                view.DataList = model.DataList;
                view.LogBox = "Элемент успешно добавлен";
            }
            catch (Exception ex)
            {
                view.LogBox = "Произошла ошибка: " + ex.Message;
            }
        }

        public void RemElem() {

            try
            {
                if (!model.RemElem(view.CurrentElemXML))
                    throw new Exception("Элемент не был добавлен");
                view.DataList = model.DataList;
                view.LogBox = "Элемент успешно добавлен";
            }
            catch (Exception ex)
            {
                view.LogBox = "Произошла ошибка: " + ex.Message;
            }

        }

        public void EditElem()
        {
            try
            {
                if (!model.EditElem(view.CurrentElemXML))
                    throw new Exception("Элемент не был отредактирован");
                view.DataList = model.DataList;
                view.LogBox = "Элемент успешно отредактирован";
            }
            catch (Exception ex)
            {
                view.LogBox = "Произошла ошибка: " + ex.Message;
            }
        }

        public void SaveFile()
        {
            try
            {
                if (model.PathFile != null)
                {
                    model.SaveFile(model.DataList);
                    view.LogBox = "Файл успешно сохранён";
                }
                else
                {
                    view.LogBox = "Файл не открыт";
                }
            }
            catch (Exception ex)
            {
                view.LogBox = "Произошла ошибка: " + ex.Message;
            }
        }

        public void SaveFileAs()
        {
            try
            {
                if (model.PathFile != null)
                {
                    if (!model.SaveFileAs(model.DataList))
                        throw new Exception("Сохранение отменено");
                    view.LogBox = "Файл успешно сохранён";
                    view.PathFile = model.PathFile;
                }
                else
                {
                    view.LogBox = "Файл не открыт";
                }
            }
            catch (Exception ex)
            {
                view.LogBox = "Произошла ошибка: " + ex.Message;
            }

        }



        public void NativeFunction()
        {
            try
            {
                view.NativeResult = Convert.ToString(model.NativeFunction(view.A, view.B));
                view.LogBox = "умножение выполнено успешно";
            }
            catch (Exception ex)
            {
                view.LogBox = "При выполнении умножения произошла ошибка: " + ex.Message;
            }
        }

    }
}

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
        private IFile file;
        private List dataList;
        private string pathFile;

        public string PathFile
        {
            get { return pathFile; }
        }

        public List DataList { get => dataList; set => dataList = value; }

        public Model(IFile file, IDBModel iDBModel)
        {
            this.iDBModel = iDBModel;
            this.file = file;

            Assembly asmA = Assembly.Load(System.IO.File.ReadAllBytes("C://Users//dyagi//Desktop//СИСПРОГ ЛР 1//Native//bin//Debug//Multiplication.dll"));
            Type tA = asmA.GetType("MultiplicationDLL");
            method = tA.GetMethod("Multiplication", BindingFlags.Instance | BindingFlags.Public);
            instance = Activator.CreateInstance(tA);


        }
       

        public string Analyzer(string[] lines)
        {
            var analyzer = new Analyzer(lines);
            analyzer.Research();
            return analyzer.Result;
        }


        private object instance;
        private MethodInfo method;
        public int NativeFunction(int leftOperand, int rightOperand)
        {
            return (int)method.Invoke(instance, new object[] { leftOperand, rightOperand });
        }







        #region FILE
        public List OpenFile()
        {
            var f = file.OpenFile();
            pathFile = file.Path;
            dataList = f;
            return f;
        }
        public List CreateFile()
        {
            var f = file.CreateFile();
            pathFile = file.Path;
            dataList = f;
            return f;
        }
        public void SaveFile(List data)
        {
            file.SaveFile(data);
        }


        public bool SaveFileAsA(List data)
        {
            if (file.SaveFileAs(data))
            {
                pathFile = file.Path;
                return true;
            }
            return false;
        }
        public bool AddElem()
        {
            var tmpNode = new AddFileForm("AddToXML");
            if (tmpNode != null && dataList != null)
            {
                dataList.AddElement(tmpNode.FileName, tmpNode.FileVersion, tmpNode.LastChangeDate);
                return true;
            }
            return false;
        }

        public bool RemElem(int index)
        {
            if (dataList != null)
            {
                dataList.DeleteElementAt(index);
                return true;
            }
            return false;
        }


        public bool DeleteElem(int index)
        {
            if (dataList != null)
            {
                dataList.DeleteElementAt(index);
                return true;
            }
            return false;
        }
        public bool EditElem(int index)
        {
            var tmpElem = dataList.GetElementAt(index);
            var tmpNode = new AddFileForm("AddToXML");
            if (tmpNode != null && dataList != null)
            {
                dataList.SetElementAt(index, tmpNode.FileName, tmpNode.FileVersion, tmpNode.LastChangeDate);
                return true;
            }
            
            return false;
        }
        #endregion



        #region MSSQLDB

        public List<Node> GetNodes()
        {
            return iDBModel.GetNodes();
        }
        public bool AddNode()
        {

            AddFileForm addFileForm = new AddFileForm("Add");

            Node node = new Node
            {
                FileName = addFileForm.FileName,
                FileVersion = addFileForm.FileVersion,
                LastChangeDate = addFileForm.LastChangeDate
            };

            if (node != null)
            {
                iDBModel.AddNode(node);
                return true;
            }
            return false;
        }
        public bool DeleteNode(Guid id)
        {
            
            if (id != null)
            {
                iDBModel.DeleteNode(id);
                return true;
            }
            return false;
        }
        public bool EditNode(Guid id)
        {
            var node = iDBModel.GetNode(id);
            AddFileForm addFileForm = new AddFileForm("Edit");

            Node newnode = new Node
            {
                Id = id,
                FileName = addFileForm.FileName,
                FileVersion = addFileForm.FileVersion,
                LastChangeDate = addFileForm.LastChangeDate
            };

            if (node != null)
            {
                iDBModel.UpdateNode(newnode);
                return true;
            }
            return false;
        }

        #endregion

    }
}

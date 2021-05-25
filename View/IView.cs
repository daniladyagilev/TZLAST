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
        event Action CreateFile;
        public event Action OpenFile;
        public event Action AddElem;
        event Action NativeFunction;
        public event Action AddToDB;

        public event Action EditInDB;

        public event Action RemFromDB;

        public event Action SaveFile;

        public event Action RemFile;

        public event Action EditFile;

        public event Action SaveFileAs;


        int A { get; }
        int B { get; }
        List<Node> DataListDB { set; }

        List DataList { get; set; }
        string PathFile { set; }

        string[] AnalyzerCode { get; }
        string AnalyzerResult { set; }

        string LogBox { set; }

        string NativeResult { set; }

        Guid CurrentItemInDB { get; }

        int CurrentElemXML { get; }



    }
}

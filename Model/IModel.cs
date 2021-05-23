using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP_Dyagilev
{
    interface IModel
    {
        string PathFile { get; }
        List<Node> GetNodes();
        bool AddNode();

        string Analyzer(string[] lines);

        List CreateFile();
        List OpenFile();

        int NativeFunction(int a, int b);

        bool AddElem();

        List DataList { get; set; }

        bool EditNode(string index);


    }
}

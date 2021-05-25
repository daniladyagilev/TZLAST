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

        bool RemElem(int index);

        bool EditElem(int index);

        List DataList { get; set; }

        bool EditNode(Guid index);

        bool DeleteNode(Guid id);

        void SaveFile(List data);

        bool SaveFileAs(List data);


    }
}

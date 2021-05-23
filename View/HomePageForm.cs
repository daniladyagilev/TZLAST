using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SP_Dyagilev
{
    public partial class HomePageForm : Form, IView
    {
        public HomePageForm()
        {
            InitializeComponent();
            analyzerInit();

        }

        public List<Node> DataListDB
        {
            set
            {
                dataGridView1.Rows.Clear();
                foreach (var el in value)
                    dataGridView1.Rows.Add(el.FileName, el.FileVersion, el.LastChangeDate);
            }
        }
        public string[] AnalyzerCode { get { return richTextBoxCode.Lines; } }
        public string AnalyzerResult { set { labelResult.Text = value; } }
        public string LogBox
        {
            set
            {
                richTextBoxLog.Text += (DateTime.Now + " - " + value + "\r\n");
                richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                richTextBoxLog.ScrollToCaret();
            }
        }

        public List DataList
        {
            get
            {
                var list = new List();
                for (int i = 0; i < dataGridViewFiles.Rows.Count; i++)
                {
                    var element = dataGridViewFiles.Rows[i];
                    list.AddElement(
                        element.Cells[0].Value.ToString(),
                        element.Cells[1].Value.ToString(), 
                        DateTime.Parse(element.Cells[2].Value.ToString()));
                }
                return list;
            }
            set { ShowDateList(value.First, dataGridViewFiles); }
        }
        private void ShowDateList(Node node, DataGridView dGv)
        {
            dGv.Rows.Clear();

            while (node != null)
            {
                dGv.Rows.Add(node.FileName, node.FileVersion, node.LastChangeDate);

                node = node.Next;
            }
        }
        public string PathFile { set { labelPathFile.Text = "Текущий файл: " + value; } }

        public int A { get { return int.Parse(textBoxA.Text); } }
        public int B { get { return int.Parse(textBoxB.Text); } }


        public string NativeResult { set { labelNativeResult.Text = value.ToString(); } }

        public long CurrentItemInDB
        {
            get
            {
                if (dataGridView1.CurrentCell == null)
                   throw new Exception("Выберите запись в таблице!");
                return long.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                
            }
        }

        string IView.CurrentItemInDB => throw new NotImplementedException();

        public event Action OpenDB;
        public event Action Analyze;
        public event Action CreateFile;
        public event Action OpenFile;
        public event Action AddElem;
        public event Action NativeFunction;
        public event Action AddToDB;

        public event Action EditInDB;

        public void analyzerInit() {
            labelTask.Text = "Цикл-перебор\nforeach\r\n(< элемент > in < массив >) {< Тело цикла >}\r\nПосчитать, сколько раз выполнится цикл.";
            richTextBoxCode.Text = "int[] arr = new int[7];\nforeach(int a in arr)\n{\n    int x = 0;\n    x++;\n}";
        }


        #region BUTTONS
        private void button1_Click(object sender, EventArgs e)
        {
            OpenDB?.Invoke();
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            Analyze();
        }
        #endregion

        private void buttonCreateFile_Click(object sender, EventArgs e)
        {
            CreateFile?.Invoke();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile?.Invoke();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            AddElem?.Invoke();
        }

        private void buttonNative_Click(object sender, EventArgs e)
        {
            NativeFunction?.Invoke();
        }

        private void buttonAddItemToDB_Click(object sender, EventArgs e)
        {
            AddToDB?.Invoke();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditInDB?.Invoke();
        }
    }
}

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

        }

        public List<Stat> DataListDB
        {
            set
            {
                dataGridView1.Rows.Clear();
                foreach (var el in value)
                    dataGridView1.Rows.Add(el.Id, el.Word, el.Quantity);
            }
        }
        public string LogBox
        {
            set
            {
                richTextBoxLog.Text += (DateTime.Now + " - " + value + "\r\n");
                richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                richTextBoxLog.ScrollToCaret();
            }
        }

        public List<Stat> DataList
        {
            get
            {
                var list = new List<Stat>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var element = dataGridView1.Rows[i];

                    Stat entry = new Stat
                    {
                        Id = row.Id,
                        Quantity = row.Quantity,
                        Word = row.Word
                    };

                    list.Add(
                        element.Cells[0].Value.ToString(),
                        element.Cells[1].Value.ToString(), 
                        DateTime.Parse(element.Cells[2].Value.ToString()));
                }
                return list;
            }
            set { ShowDateList(value.First, dataGridView1); }
        }

        public Guid CurrentItemInDB => throw new NotImplementedException();

        private void ShowDateList(Stat node, DataGridView dGv)
        {
            dGv.Rows.Clear();

            while (node != null)
            {
                dGv.Rows.Add(node.Id, node.Word, node.Quantity);

            }
        }


        public event Action OpenDB;
        public event Action Analyze;
       



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

    }
}
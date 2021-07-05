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
      
        public Guid CurrentItemInDB => throw new NotImplementedException();


        public event Action OpenDB;
        
        public event Action GetHTML;

        public event Action Analyze;

        private void button1_Click(object sender, EventArgs e)
        {
            GetHTML?.Invoke();
            Analyze?.Invoke();
            OpenDB?.Invoke();
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Logic;

namespace SP_Dyagilev
{
    public partial class AddFileForm : Form
    {
        public AddFileForm(string action)
        {
            InitializeComponent();
            switch (action)
            {

                case "Add":
                    Add();
                    break;
                case "Edit":
                    Edit();
                    break;

            }


        }

        public string FileName { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string FileVersion { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public DateTime LastChangeDate { get { return dateTimePicker1.Value; } set { dateTimePicker1.Value = value; } }
        //public int Id { get { return ; } set { dateTimePicker1.Value = value; } }


        public void Add()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dll files (*.dll)|*.dll";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                FileName = openFileDialog.SafeFileName;
                FileVersion = FileVersionInfo.GetVersionInfo(openFileDialog.FileName).FileVersion;
                LastChangeDate = new FileInfo(openFileDialog.FileName).LastWriteTime;

            }
            this.Close();
        }
        public void Edit()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dll files (*.dll)|*.dll";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                FileName = openFileDialog.SafeFileName;
                FileVersion = FileVersionInfo.GetVersionInfo(openFileDialog.FileName).FileVersion;
                LastChangeDate = new FileInfo(openFileDialog.FileName).LastWriteTime;

            }
            this.Close();


        }
    }
}

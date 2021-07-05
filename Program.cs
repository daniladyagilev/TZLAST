using Logic;
using SP_Dyagilev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TzMain
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HomePageForm f = new HomePageForm();
            Presenter p = new Presenter(f, new Model(new DBModel()));
            Application.Run(f);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AccountingInterface.Presentation;
namespace AccountingInterface
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new  CityLedgerUI());
        }
    }
}

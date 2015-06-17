using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VendingMachine.BLL;

namespace VendingMachine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Transaction transaction = new Transaction();
            Application.Current.MainWindow = new MainWindow(transaction);
            Application.Current.MainWindow.Show();    
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VendingMachine.BLL;

namespace VendingMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Transaction transaction = new Transaction();

        public MainWindow()
        {
            InitializeComponent();
           
            DisplayTextBox.Text = "INSERT COIN";

            InsertCoinBox.Items.Add("Penny");
            InsertCoinBox.Items.Add("Nickel");
            InsertCoinBox.Items.Add("Dime");
            InsertCoinBox.Items.Add("Quarter");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void InsertCoin_Click(object sender, RoutedEventArgs e)
        {
            InsertCoinClick();
        }


        
        //simulate the reading of a coins size and weight
        public void InsertCoinClick()
        {
            decimal coinValue = 0M;

            if (InsertCoinBox.SelectedItem == null)
            {
                MessageBox.Show("Select a coin then press Insert Coin");
            }
            else if (InsertCoinBox.SelectedItem.ToString() == "Nickel")
            {
                coinValue = Coin.DetermineCoin(CoinSizeEnum.micrometer21210, CoinWeightEnum.milligram5000);
            }
            else if (InsertCoinBox.SelectedItem.ToString() == "Dime")
            {
                coinValue = Coin.DetermineCoin(CoinSizeEnum.mirometer17910, CoinWeightEnum.milligram2268);
            }
            else if (InsertCoinBox.SelectedItem.ToString() == "Quarter")
            {
                coinValue = Coin.DetermineCoin(CoinSizeEnum.micrometer24260, CoinWeightEnum.milligram5670);
            }
            else
            {
                MessageBox.Show("Invalid Coin");
            }

            transaction.DisplayTotal.Add(coinValue);
            decimal sum = transaction.DisplayTotal.Sum();
            DisplayTextBox.Text = sum.ToString("C");
            
        }





    }
}

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
        public Transaction transaction { get; set; }
        

        public MainWindow()
        {
            InitializeComponent();
            transaction = new Transaction();

            txtDisplay.Text = "INSERT COIN";
            txtCoinReturn.Text = "Coin Return Slot";

            lstInsertCoin.Items.Add("Penny");
            lstInsertCoin.Items.Add("Nickel");
            lstInsertCoin.Items.Add("Dime");
            lstInsertCoin.Items.Add("Quarter");
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

            if (lstInsertCoin.SelectedItem == null)
            {
                MessageBox.Show("Select a coin then press Insert Coin");
            }
            else if (lstInsertCoin.SelectedItem.ToString() == "Nickel")
            {
                coinValue = Coin.DetermineCoin(CoinSizeEnum.micrometer21210, CoinWeightEnum.milligram5000);
            }
            else if (lstInsertCoin.SelectedItem.ToString() == "Dime")
            {
                coinValue = Coin.DetermineCoin(CoinSizeEnum.mirometer17910, CoinWeightEnum.milligram2268);
            }
            else if (lstInsertCoin.SelectedItem.ToString() == "Quarter")
            {
                coinValue = Coin.DetermineCoin(CoinSizeEnum.micrometer24260, CoinWeightEnum.milligram5670);
            }
            else
            {
                MessageBox.Show("Invalid Coin");
                UpdateReturnTotal();
            }

            transaction.AddToDisplayTotal(coinValue);
            string sum = transaction.DisplayTotal.ToString("C");
            CoinUpdateDisplayTotal(sum);
        }

        private void CoinUpdateDisplayTotal(string message)
        {
            if (message == "$0.00")
            {
                txtDisplay.Text = "INSERT COIN";
            }
            else
            {
                txtDisplay.Text = message.ToString();
            }
        }

        private void UpdateDisplayTotal(string message, int delay)
        {
                txtDisplay.Text = message.ToString();
        }




        private void UpdateReturnTotal()
        {
            transaction.AddToReturnTotal(.01M);
            txtCoinReturn.Text = transaction.ReturnTotal.ToString("C");
        }

        private void CoinReturnbtn_Click(object sender, RoutedEventArgs e)
        {
            PickupChangeClick();
        }

        public void PickupChangeClick()
        {
            txtCoinReturn.Text = "Coin Return Slot";
            transaction.ReturnTotal = 0M;
        }

        private void btnCola_Click(object sender, RoutedEventArgs e)
        {
            ProductClick("cola");
        }

        private void btnChips_Click(object sender, RoutedEventArgs e)
        {
            ProductClick("chips");
        }

        private void btnCandy_Click(object sender, RoutedEventArgs e)
        {
            ProductClick("candy"); 
        }

        public void ProductClick(string productString)
        {
            int index = transaction.Products.FindIndex(x => x.Name == productString);

            if (index == -1)
            {
                MessageBox.Show("Could not find product.");
            } else
            {
                if (transaction.ProductVended(transaction.Products[index])) UpdateDisplayTotal("THANK YOU", 1000);
            }
        }

        private void btnResetDisplay_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplay();
        }

        public void ResetDisplay()
        {
            txtDisplay.Text = "INSERT COIN";
        }


    }
}

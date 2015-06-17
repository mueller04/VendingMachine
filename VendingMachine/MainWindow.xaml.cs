﻿using System;
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

            InsertCoinDisplayText();
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
            decimal coinValue = CalculateCoinValue();

            if (coinValue == 0M)
            {
                MessageBox.Show("Invalid Coin");
                UpdateReturnTotal(.01M);
            } else
            {
                transaction.AddToDisplayTotal(coinValue);
                string sum = transaction.DisplayTotal.ToString("C");
                CoinUpdateDisplayTotal(sum);
            }
        }

        private decimal CalculateCoinValue()
        {
            decimal coinValue = 0M;

            if (lstInsertCoin.SelectedItem == null)
            {
                MessageBox.Show("Select a coin then press Insert Coin");
                return coinValue;
            }
            else if (lstInsertCoin.SelectedItem.ToString() == "Nickel")
            {
                coinValue = Coin.DetermineCoin(CoinSizeEnum.micrometer21210, CoinWeightEnum.milligram5000);
                return coinValue;
            }
            else if (lstInsertCoin.SelectedItem.ToString() == "Dime")
            {
                coinValue = Coin.DetermineCoin(CoinSizeEnum.mirometer17910, CoinWeightEnum.milligram2268);
                return coinValue;
            }
            else if (lstInsertCoin.SelectedItem.ToString() == "Quarter")
            {
                coinValue = Coin.DetermineCoin(CoinSizeEnum.micrometer24260, CoinWeightEnum.milligram5670);
                return coinValue;
            }
            else
            {
                return coinValue;
            }
        }

        private void CoinUpdateDisplayTotal(string message)
        {
            if (message == "$0.00")
            {
                InsertCoinDisplayText();
            }
            else
            {
                txtDisplay.Text = message.ToString();
            }
        }

        private void UpdateDisplayTotal(string message)
        {
                txtDisplay.Text = message.ToString();
        }

        private void UpdateReturnTotal(decimal add)
        {
            transaction.AddToReturnTotal(add);
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
            transaction.DisplayTotal = 0M;
            ResetDisplay();
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
                string displayMessage = transaction.ProductVended(transaction.Products[index]);

                UpdateDisplayTotal(displayMessage);
                    UpdateReturnTotal(0);
            }

        }

        private void btnResetDisplay_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplay();
        }

        public void ResetDisplay()
        {
            if (transaction.DisplayTotal != 0)
            {
                txtDisplay.Text = transaction.DisplayTotal.ToString("C");
            }
            else
            {
                InsertCoinDisplayText();
            }
            
        }

        private void InsertCoinDisplayText()
        {
            txtDisplay.Text = "INSERT COIN";
        }

        private void chkExactChange_Checked(object sender, RoutedEventArgs e)
        {
            if (chkExactChange.IsChecked == true)
            {
                transaction.ExactChangeEnabled = true;
            }
            else if (chkExactChange.IsChecked == false)
            {
                transaction.ExactChangeEnabled = false;
            }
        }
    }
}

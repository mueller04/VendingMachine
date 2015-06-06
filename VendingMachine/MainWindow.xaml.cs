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
        public MainWindow()
        {
            InitializeComponent();
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


        public string coin { get; set; }

        public void InsertCoinClick()
        {
            
            if (InsertCoinBox.SelectedItem == null)
            {
                this.coin = "Select a coin then press Insert Coin";
            }
            else if (InsertCoinBox.SelectedItem.ToString() == "Nickel")
            {
                this.coin = Coin.DetermineCoin(CoinSizeEnum.micrometer21210, CoinWeightEnum.grams5000);
            }
            else
            {
                this.coin = "Error";
            }

            MessageBox.Show(coin);
        }





    }
}
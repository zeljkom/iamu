using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ZMZadaca.Misc;


namespace ZMZadaca {
    public partial class Zbrajalica : PhoneApplicationPage {
        public Zbrajalica() {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e) {
            decimal num1 = 0;
            decimal num2 = 0;

            Decimal.TryParse(txtA.Text, out num1);
            Decimal.TryParse(txtB.Text, out num2);

            decimal rez = num1 + num2;
            string message =String.Format("{0} + {1} = {2}",num1, num2, rez);
 
            MessageBox.Show(message, "Rezultat", MessageBoxButton.OK);
            txtA.Text = "";
            txtB.Text = "";

            ShellTile TileToFind = ShellTile.ActiveTiles.First();
            if (TileToFind != null) {

                StandardTileData NewTileData = new StandardTileData {
                    Title = message,                                                            
                };

                TileToFind.Update(NewTileData);

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {


            PersistanceData pData = ((App.Current.RootVisual as PhoneApplicationFrame).DataContext as PersistanceData);
            if (pData != null) {
                if (State.ContainsKey("txtA"))
                    pData.CalcData.A = State["txtA"] as string;
                if (State.ContainsKey("txtB"))
                    pData.CalcData.B = State["txtB"] as string;
            }
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e) {


            if (State.ContainsKey("txtA"))
                State.Remove("txtA");
            State.Add("txtA", txtA.Text);

            if (State.ContainsKey("txtB"))
                State.Remove("txtB");
            State.Add("txtB", txtB.Text);
            
            base.OnNavigatedFrom(e);
        }
    }
}
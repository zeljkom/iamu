using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Phone.System.UserProfile;

namespace Vjezba {
    public partial class Page1 : PhoneApplicationPage {
        public Page1() {
            InitializeComponent();
        }

        private void btnCreateTile_Click(object sender, RoutedEventArgs e) {

            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(t => t.NavigationUri.ToString().Contains("Page1.xaml"));
            if (tile != null) tile.Delete();
            
            FlipTileData tileData = new FlipTileData();
            tileData.SmallBackgroundImage = new Uri("/Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative);
            MojaKlasa data = App.RootFrame.DataContext as MojaKlasa;
            tileData.Title = data.Ime + " " + data.Prezime;
            tileData.WideBackgroundImage = new Uri("/Assets/Tiles/FlipCycleTileLarge.png", UriKind.Relative);
            tileData.BackgroundImage = new Uri("/Assets/tiles/FlipCycleTileMedium.png", UriKind.Relative);
            tileData.Count = 1;
            Uri uri = new Uri("/Page1.xaml", UriKind.Relative);
            ShellTile.Create(uri, tileData, true);
        }

        private void btnUpdateTile_Click(object sender, RoutedEventArgs e) {

            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault();
            StandardTileData data = new StandardTileData();
            data.BackTitle = "Mika";
            data.Count = 30;
            if (tile != null)
                tile.Update(data);
        }

        private void btnUpdateTileScheduler_Click(object sender, RoutedEventArgs e) {
            //Sek. tile - dohvat
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(t => t.NavigationUri.ToString().Contains("Page1.xaml"));

            //Primarni tile
            //ShellTileSchedule schedule = new ShellTileSchedule();
            
            //Sekundarni tile
            ShellTileSchedule schedule = new ShellTileSchedule(tile);            
            schedule.Recurrence = UpdateRecurrence.Interval;
            schedule.Interval = UpdateInterval.EveryHour;
            schedule.RemoteImageUri = new Uri(@"http://www.teched.eu/images/includetables/SGS-130px.png");

            schedule.Start();



        }

        private void bTNLock_Click(object sender, RoutedEventArgs e) {
            Lock();
        }

        private async void Lock() {
            var op = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
        }

        private void btnBackground_Click(object sender, RoutedEventArgs e) {
            SetBackground();

        }

        private async void SetBackground() {
            var op = await LockScreenManager.RequestAccessAsync();
            if (LockScreenManager.IsProvidedByCurrentApplication) {
                LockScreen.SetImageUri(new Uri("ms-appx:///Assets/Calendar.png"));
            }
        }
        


    }
}
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Vjezba.Resources;
using Windows.Storage;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Microsoft.Phone.Storage;
using System.Threading;

namespace Vjezba {
    public partial class MainPage : PhoneApplicationPage {
        // Constructor
        public MainPage() {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar() {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {

           
            //Način 1. WP7
            //IsolatedStorageFile iStorage = IsolatedStorageFile.GetUserStoreForApplication();
            //string [] files = iStorage.GetFileNames();
            //Način 2. WP8            
            //getFileStorage();
            //getFile("mika.xml");
            IsolatedStorageSettings sett = getSettings();            
            //isoFileStream();
            //StorageFileTest();
            int i;

            base.OnNavigatedTo(e);
        }

        private async void StorageFileTest() {

            //1. CREATE FILE
            StorageFolder appDataFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await appDataFolder.CreateFileAsync("mika.txt", CreationCollisionOption.ReplaceExisting);
            using (Stream s = await file.OpenStreamForWriteAsync()) {
                using (StreamWriter sw = new StreamWriter(s)) {
                    sw.WriteLine("Hello Mika");
                }                
            }

            //2. ACCESS VIA StorageFile
            StorageFile file2 = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/mika.txt"));

            IEnumerable<ExternalStorageDevice> es = await ExternalStorage.GetExternalStorageDevicesAsync();
            
            
            int i = 0;
        }

        
        private async void getFileStorage() {

            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile mojFajl = await localFolder.CreateFileAsync("mika.xml", CreationCollisionOption.OpenIfExists);

            using (XmlWriter xw = XmlWriter.Create(await mojFajl.OpenStreamForWriteAsync())) {
                xw.WriteElementString("Mika", "Data");
            }

            byte[] data;
            //Read
            using (Stream s = await mojFajl.OpenStreamForReadAsync()) {
                data = new byte[s.Length];
                await s.ReadAsync(data, 0, (int)s.Length);
            }
            string dataStr = Encoding.UTF8.GetString(data, 0, data.Length);
        }

        private async void getFile(string filename) {
            StorageFolder sf = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await sf.GetFileAsync(filename);
            int i = 0;
        }

        public IsolatedStorageSettings getSettings() {
            //IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            //using (Stream s = store.OpenFile("mika.xml", FileMode.Append)) { 
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            MojaKlasa kl = new MojaKlasa() { Ime = "Pero", Prezime = "Perić", Data = new MojaKlasa.PodKlasa() {MyProperty=6 } };
            if (settings.Contains("mika")) settings.Remove("mika");
            if (settings.Contains("Klasa")) settings.Remove("Klasa");
            
            settings.Add("mika", "Bla bla");
            settings.Add("Klasa", kl);

           

            
            settings.Save();
            return settings;            
        }

        public async void isoFileStream() {
            StorageFolder sfold = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile sfile =  await sfold.GetFileAsync("mika.xml");
            string data;
            using (Stream s = await sfile.OpenStreamForReadAsync()) {

                StreamReader sr = new StreamReader(s);
                data = sr.ReadToEnd();
            }

            //StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //StorageFile file = await folder.GetFileAsync("mika.xml");
            IsolatedStorageFile folder = IsolatedStorageFile.GetUserStoreForApplication();
            using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("mika.xml", FileMode.Open, folder)) {

                using (StreamReader sr = new StreamReader(isfs)) {

                    string result = sr.ReadToEnd();
                }
                
            }
            
            
            
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e) {

            MessageBoxResult result = MessageBox.Show("Želite li spremiti podatke?", "Pohrana?", MessageBoxButton.OKCancel);
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (result == MessageBoxResult.OK) {
                settings["appdata"] = App.RootFrame.DataContext;
            } else {
                settings.Remove("appdata");
            }
                        base.OnBackKeyPress(e);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }

        
    }
}
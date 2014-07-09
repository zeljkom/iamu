using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using ZMZadaca.Misc;

namespace ZMZadaca {
    public partial class Sms : PhoneApplicationPage {
        public Sms() {
            InitializeComponent();
        }

        private void btnContChoose_Click(object sender, RoutedEventArgs e) {
            PhoneNumberChooserTask phoneNumberChooserTask = new PhoneNumberChooserTask();
            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
            phoneNumberChooserTask.Show();
        }

        private void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e) {
            if (e.TaskResult == TaskResult.OK) {
                txtPhoneNumber.Text = e.PhoneNumber;
            }
        }

        private void btbSend_Click(object sender, RoutedEventArgs e) {
            SmsComposeTask smsComposeTask = new SmsComposeTask();

            smsComposeTask.To = txtPhoneNumber.Text;
            smsComposeTask.Body = txtMessage.Text;

            smsComposeTask.Show();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {


            PersistanceData pData = ((App.Current.RootVisual as PhoneApplicationFrame).DataContext as PersistanceData);
            if (pData != null) {
                if (State.ContainsKey("txtPhoneNumber"))
                    pData.SMSData.Number = State["txtPhoneNumber"] as string;
                if (State.ContainsKey("txtMessage"))
                    pData.SMSData.Message = State["txtMessage"] as string;
            }
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e) {


            if (State.ContainsKey("txtPhoneNumber"))
                State.Remove("txtPhoneNumber");
            State.Add("txtPhoneNumber", txtPhoneNumber.Text);

            if (State.ContainsKey("txtMessage"))
                State.Remove("txtMessage");
            State.Add("txtMessage", txtMessage.Text);

            base.OnNavigatedFrom(e);
        }
    }
}
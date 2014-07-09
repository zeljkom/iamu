using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMZadaca.Misc {
    public class PersistanceData : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public PersistanceData() {
            CalcData = new CalculatorData() { A="",B="", Result="" };
            CalcData.PropertyChanged += CalcData_PropertyChanged;
            SMSData = new SmsData() { Number="", Message="" };
        }

        void CalcData_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            NotifyPropertyChanged("CalcData." + e.PropertyName);
        }

        public CalculatorData CalcData { get; set; }
        public SmsData SMSData { get; set; }

        public class CalculatorData : INotifyPropertyChanged {

            private string a = "";
            private string b = "";
            public string A {
                get { return a; }
                set {
                    this.a = value;
                    NotifyPropertyChanged("A");
                }
            } 
           
            public string B {
                get { return b; } 
                set { 
                    this.b = value;
                    NotifyPropertyChanged("B");
                } 
            }
            
            public string Result { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(string propertyName) {
                if (null != PropertyChanged)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class SmsData : INotifyPropertyChanged {
            private string number = "";
            private string message = "";
            public string Number {
                get { return number; }
                set {
                    this.number = value;
                    NotifyPropertyChanged("Number");
                } 
            }
            public string Message {
                get { return message; }
                set {
                    this.message = value;
                    NotifyPropertyChanged("Message");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName) {
                if (null != PropertyChanged)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private void NotifyPropertyChanged(string propertyName) {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

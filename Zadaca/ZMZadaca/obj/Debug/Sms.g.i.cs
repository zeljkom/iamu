﻿#pragma checksum "D:\DropBox\VSPR\IAMU\Zadaca\ZMZadaca\ZMZadaca\Sms.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AC5BC7D29DA71303BF8F8707089C4FF4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ZMZadaca {
    
    
    public partial class Sms : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button btnContChoose;
        
        internal System.Windows.Controls.TextBox txtPhoneNumber;
        
        internal System.Windows.Controls.TextBox txtMessage;
        
        internal System.Windows.Controls.Button btbSend;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ZMZadaca;component/Sms.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.btnContChoose = ((System.Windows.Controls.Button)(this.FindName("btnContChoose")));
            this.txtPhoneNumber = ((System.Windows.Controls.TextBox)(this.FindName("txtPhoneNumber")));
            this.txtMessage = ((System.Windows.Controls.TextBox)(this.FindName("txtMessage")));
            this.btbSend = ((System.Windows.Controls.Button)(this.FindName("btbSend")));
        }
    }
}

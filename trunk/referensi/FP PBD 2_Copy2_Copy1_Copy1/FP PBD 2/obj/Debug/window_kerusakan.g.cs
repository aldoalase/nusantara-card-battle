﻿#pragma checksum "..\..\window_kerusakan.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1A70B0ED70EEE034EA8AA640C398D0C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CrystalDecisions.Windows.Forms;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FP_PBD_2 {
    
    
    /// <summary>
    /// window_kerusakan
    /// </summary>
    public partial class window_kerusakan : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\window_kerusakan.xaml"
        internal FP_PBD_2.window_kerusakan Window;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\window_kerusakan.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard button_home_leave_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.Image PsdLayer;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.Image Shape_4;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.Canvas button_home;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.TextBox no_surat;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.TextBox pegawai;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.Label tanggal;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.ComboBox no_transaksi;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\window_kerusakan.xaml"
        internal System.Windows.Controls.TextBox keterangan;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/FP PBD 2;component/window_kerusakan.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\window_kerusakan.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window = ((FP_PBD_2.window_kerusakan)(target));
            return;
            case 2:
            this.button_home_leave_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.PsdLayer = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.Shape_4 = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.button_home = ((System.Windows.Controls.Canvas)(target));
            return;
            case 7:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\window_kerusakan.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.back_pegawai);
            
            #line default
            #line hidden
            return;
            case 8:
            this.no_surat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.pegawai = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.tanggal = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.no_transaksi = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.keterangan = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


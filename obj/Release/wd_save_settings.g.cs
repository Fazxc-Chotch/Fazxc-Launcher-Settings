﻿#pragma checksum "..\..\wd_save_settings.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AA37789CDFCAF093F134BEB967519E661F76EC0B733B17B210DB5505FE1696A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Panuon.UI.Silver;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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
using System.Windows.Shell;


namespace KC_Launcher_Settings {
    
    
    /// <summary>
    /// wd_save_settings
    /// </summary>
    public partial class wd_save_settings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\wd_save_settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border br_main;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\wd_save_settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_exitapp;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\wd_save_settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_login_rdb;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\wd_save_settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_export;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\wd_save_settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_rtdb_url;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\wd_save_settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_rtdb_key;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\wd_save_settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_passwordencryption_package;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KC Launcher Settings;component/wd_save_settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\wd_save_settings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 15 "..\..\wd_save_settings.xaml"
            ((KC_Launcher_Settings.wd_save_settings)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.br_main = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.lbl_exitapp = ((System.Windows.Controls.Label)(target));
            
            #line 76 "..\..\wd_save_settings.xaml"
            this.lbl_exitapp.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.lbl_exitapp_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_login_rdb = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\wd_save_settings.xaml"
            this.btn_login_rdb.Click += new System.Windows.RoutedEventHandler(this.btn_login_rdb_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_export = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\wd_save_settings.xaml"
            this.btn_export.Click += new System.Windows.RoutedEventHandler(this.btn_export_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_rtdb_url = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_rtdb_key = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txt_passwordencryption_package = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


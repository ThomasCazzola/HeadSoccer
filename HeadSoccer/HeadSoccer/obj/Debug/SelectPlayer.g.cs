﻿#pragma checksum "..\..\SelectPlayer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AD958528980167B7B45D6B10250FD43756282BFB7E9C2509D781D90C6F28386C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HeadSoccer;
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


namespace HeadSoccer {
    
    
    /// <summary>
    /// SelectPlayer
    /// </summary>
    public partial class SelectPlayer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\SelectPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\SelectPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image players;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SelectPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SelectPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SelectPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
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
            System.Uri resourceLocater = new System.Uri("/HeadSoccer;component/selectplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SelectPlayer.xaml"
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
            this.lbl1 = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.players = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\SelectPlayer.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.GoBack);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\SelectPlayer.xaml"
            this.btnNext.Click += new System.Windows.RoutedEventHandler(this.GoNext);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\SelectPlayer.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.Confirm);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

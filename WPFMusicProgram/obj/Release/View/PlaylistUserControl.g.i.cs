﻿#pragma checksum "..\..\..\View\PlaylistUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A6ADFEC1E666867660FB52AF55B023258D1E99FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
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
using WPFMusicProgram;
using WPFMusicProgram.ViewModel;


namespace WPFMusicProgram.View {
    
    
    /// <summary>
    /// PlaylistUserControl
    /// </summary>
    public partial class PlaylistUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\View\PlaylistUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome RefreshCircle;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\View\PlaylistUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxPlaylist;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFMusicProgram;component/view/playlistusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PlaylistUserControl.xaml"
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
            
            #line 23 "..\..\..\View\PlaylistUserControl.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\View\PlaylistUserControl.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RefreshCircle = ((FontAwesome.WPF.ImageAwesome)(target));
            return;
            case 3:
            this.ListBoxPlaylist = ((System.Windows.Controls.ListBox)(target));
            
            #line 40 "..\..\..\View\PlaylistUserControl.xaml"
            this.ListBoxPlaylist.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\View\PlaylistUserControl.xaml"
            this.ListBoxPlaylist.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListBoxPlaylist_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


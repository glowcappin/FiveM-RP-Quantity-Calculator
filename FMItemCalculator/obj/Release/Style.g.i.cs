﻿#pragma checksum "..\..\Style.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "37D15888B96F48F2A19A5B6CB0B686FF271317D5731842787832E52F7E4B15D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FMItemCalculator;
using Microsoft.Windows.Themes;
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


namespace FMItemCalculator {
    
    
    /// <summary>
    /// Style
    /// </summary>
    public partial class Style : System.Windows.ResourceDictionary, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
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
            System.Uri resourceLocater = new System.Uri("/FMItemCalculator;component/style.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Style.xaml"
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
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 362 "..\..\Style.xaml"
            ((System.Windows.Controls.Primitives.StatusBar)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.StatusBar_MouseDown);
            
            #line default
            #line hidden
            break;
            case 2:
            
            #line 404 "..\..\Style.xaml"
            ((System.Windows.Controls.Border)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.control_OnFocus);
            
            #line default
            #line hidden
            
            #line 404 "..\..\Style.xaml"
            ((System.Windows.Controls.Border)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.control_OnFocus);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 412 "..\..\Style.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 552 "..\..\Style.xaml"
            ((System.Windows.Controls.Border)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.control_OnFocus);
            
            #line default
            #line hidden
            
            #line 552 "..\..\Style.xaml"
            ((System.Windows.Controls.Border)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.control_OnFocus);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


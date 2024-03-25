﻿#pragma checksum "..\..\..\..\Views\BlockDiagramWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D9894EE1A3E9E867D86040FBC0A2B62932E65676"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GraphSharp.Controls;
using MahApps.Metro.Controls;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ParaPen.Converters;
using ParaPen.ModelViews;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
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


namespace ParaPen.Views {
    
    
    /// <summary>
    /// BlockDiagramWindow
    /// </summary>
    public partial class BlockDiagramWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Views\BlockDiagramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ParaPen.Views.BlockDiagramWindow root;
        
        #line default
        #line hidden
        
        
        #line 265 "..\..\..\..\Views\BlockDiagramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GraphSharp.Controls.GraphLayout graphLayout;
        
        #line default
        #line hidden
        
        
        #line 290 "..\..\..\..\Views\BlockDiagramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Flyout blockPenContainersFlyout;
        
        #line default
        #line hidden
        
        
        #line 299 "..\..\..\..\Views\BlockDiagramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox blockPenContainersLB;
        
        #line default
        #line hidden
        
        
        #line 360 "..\..\..\..\Views\BlockDiagramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Flyout tracebackFlyout;
        
        #line default
        #line hidden
        
        
        #line 371 "..\..\..\..\Views\BlockDiagramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid tracebackTable;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ParaPen;component/views/blockdiagramwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\BlockDiagramWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.root = ((ParaPen.Views.BlockDiagramWindow)(target));
            return;
            case 2:
            this.graphLayout = ((GraphSharp.Controls.GraphLayout)(target));
            
            #line 269 "..\..\..\..\Views\BlockDiagramWindow.xaml"
            this.graphLayout.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.graphLayout_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 270 "..\..\..\..\Views\BlockDiagramWindow.xaml"
            this.graphLayout.PreviewMouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.graphLayout_PreviewMouseRightButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.blockPenContainersFlyout = ((MahApps.Metro.Controls.Flyout)(target));
            return;
            case 4:
            this.blockPenContainersLB = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.tracebackFlyout = ((MahApps.Metro.Controls.Flyout)(target));
            return;
            case 6:
            this.tracebackTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            
            #line 405 "..\..\..\..\Views\BlockDiagramWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 439 "..\..\..\..\Views\BlockDiagramWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


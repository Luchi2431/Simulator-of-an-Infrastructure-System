﻿#pragma checksum "..\..\..\Views\NetworkEntitiesView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72BDA6F3937513D17F86101AAF530A660EFC023756C1F1FD4A7D69352DDC8AF7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NetworkService.Views;
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


namespace NetworkService.Views {
    
    
    /// <summary>
    /// NetworkEntitiesView
    /// </summary>
    public partial class NetworkEntitiesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 68 "..\..\..\Views\NetworkEntitiesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxEntityType;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Views\NetworkEntitiesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddEntityBTN;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Views\NetworkEntitiesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteEntityBTN;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\Views\NetworkEntitiesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridEntities;
        
        #line default
        #line hidden
        
        
        #line 212 "..\..\..\Views\NetworkEntitiesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\..\Views\NetworkEntitiesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton LessThanRB;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\..\Views\NetworkEntitiesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton GreaterThanRB;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\..\Views\NetworkEntitiesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton EqualRB;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\..\Views\NetworkEntitiesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IdTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/NetworkService;component/views/networkentitiesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\NetworkEntitiesView.xaml"
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
            this.comboBoxEntityType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.AddEntityBTN = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.DeleteEntityBTN = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.dataGridEntities = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.TypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.LessThanRB = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.GreaterThanRB = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.EqualRB = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.IdTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


#pragma checksum "..\..\..\Views\MaterialsListWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B97F8669CEDE98161BCFBDD75A146207CECB3BA5F4CA43BA9514155EE0141D05"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TestDemPodgotovka.Views;


namespace TestDemPodgotovka.Views {
    
    
    /// <summary>
    /// MaterialsListWindow
    /// </summary>
    public partial class MaterialsListWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 33 "..\..\..\Views\MaterialsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView materialsList;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Views\MaterialsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Views\MaterialsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView paginator;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Views\MaterialsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button forward;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Views\MaterialsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addMaterial;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Views\MaterialsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minCountChange;
        
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
            System.Uri resourceLocater = new System.Uri("/TestDemPodgotovka;component/views/materialslistwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MaterialsListWindow.xaml"
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
            this.materialsList = ((System.Windows.Controls.ListView)(target));
            
            #line 34 "..\..\..\Views\MaterialsListWindow.xaml"
            this.materialsList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.materialsList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Views\MaterialsListWindow.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.back_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.paginator = ((System.Windows.Controls.ListView)(target));
            
            #line 89 "..\..\..\Views\MaterialsListWindow.xaml"
            this.paginator.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.paginator_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.forward = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\Views\MaterialsListWindow.xaml"
            this.forward.Click += new System.Windows.RoutedEventHandler(this.forward_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.addMaterial = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\Views\MaterialsListWindow.xaml"
            this.addMaterial.Click += new System.Windows.RoutedEventHandler(this.addMaterial_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.minCountChange = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\Views\MaterialsListWindow.xaml"
            this.minCountChange.Click += new System.Windows.RoutedEventHandler(this.minCountChange_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 2:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 62 "..\..\..\Views\MaterialsListWindow.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}


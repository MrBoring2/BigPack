<<<<<<< HEAD
﻿#pragma checksum "..\..\..\Views\MaterialWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "84AFA10ED531037480FCDE36DFCAC0B006B0343A42D5DE0BA143BF14C8AEE259"
=======
﻿#pragma checksum "..\..\..\Views\MaterialWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "73A4AA99064B8AF8F484E54956DF0EFB59B99FAC2224E99197A9F0238E147169"
>>>>>>> 147416be8facb5cbb84b705494491dd14bfe7836
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
    /// MaterialWindow
    /// </summary>
    public partial class MaterialWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Views\MaterialWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadImage;
        
        #line default
        #line hidden
        
        
<<<<<<< HEAD
        #line 30 "..\..\..\Views\MaterialWindow.xaml"
=======
        #line 35 "..\..\..\Views\MaterialWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\MaterialWindow.xaml"
>>>>>>> 147416be8facb5cbb84b705494491dd14bfe7836
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save;
        
        #line default
        #line hidden
        
        
<<<<<<< HEAD
        #line 38 "..\..\..\Views\MaterialWindow.xaml"
=======
        #line 46 "..\..\..\Views\MaterialWindow.xaml"
>>>>>>> 147416be8facb5cbb84b705494491dd14bfe7836
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button removeFromList;
        
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
            System.Uri resourceLocater = new System.Uri("/TestDemPodgotovka;component/views/materialwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MaterialWindow.xaml"
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
            this.loadImage = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Views\MaterialWindow.xaml"
            this.loadImage.Click += new System.Windows.RoutedEventHandler(this.loadImage_Click);
            
            #line default
            #line hidden
            return;
            case 2:
<<<<<<< HEAD
            this.save = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Views\MaterialWindow.xaml"
=======
            this.delete = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Views\MaterialWindow.xaml"
            this.delete.Click += new System.Windows.RoutedEventHandler(this.delete_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.save = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Views\MaterialWindow.xaml"
>>>>>>> 147416be8facb5cbb84b705494491dd14bfe7836
            this.save.Click += new System.Windows.RoutedEventHandler(this.save_Click);
            
            #line default
            #line hidden
            return;
<<<<<<< HEAD
            case 3:
=======
            case 4:
            
            #line 43 "..\..\..\Views\MaterialWindow.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.suppliers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
>>>>>>> 147416be8facb5cbb84b705494491dd14bfe7836
            this.removeFromList = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Views\MaterialWindow.xaml"
            this.removeFromList.Click += new System.Windows.RoutedEventHandler(this.removeFromList_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


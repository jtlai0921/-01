﻿#pragma checksum "C:\Users\joshhu\Desktop\win10\第5章\Example_30\MyApp\MyUcValidCode.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E1A9264AFAD9B73C646C7B6088D1FE14"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyApp
{
    partial class MyUcValidCode : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.txtInputCode = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 2:
                {
                    this.symbTip = (global::Windows.UI.Xaml.Controls.SymbolIcon)(target);
                }
                break;
            case 3:
                {
                    this.tbCode = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 21 "..\..\..\MyUcValidCode.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.tbCode).Tapped += this.OnTBTapped;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}


﻿#pragma checksum "c:\users\kabram\documents\visual studio 2015\Projects\QuestBuzzer\QuestBuzzer\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A6B9FF2DEB13A15A6490059410353C07"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuestBuzzer
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
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
                    this.buttonStatusGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.nextTeamButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 61 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.nextTeamButton).Click += this.nextTeamButton_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.resetButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 62 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.resetButton).Click += this.resetButton_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.whiteEllipse = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 5:
                {
                    this.redEllipse = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 6:
                {
                    this.greenEllipse = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 7:
                {
                    this.blueEllipse = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 8:
                {
                    this.yellowEllipse = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 9:
                {
                    this.whiteTeam = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10:
                {
                    this.redTeam = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.greenTeam = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.blueTeam = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.yellowTeam = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14:
                {
                    this.whiteEllapsed = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.redEllapsed = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16:
                {
                    this.greenEllapsed = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17:
                {
                    this.blueEllapsed = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18:
                {
                    this.yellowEllapsed = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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


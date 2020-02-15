using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


namespace MyApp
{
    /// <summary>
    /// 提供特定於套用程式的行為，以補充預設的套用程式類別。
    /// </summary>
    public sealed partial class App : Application
    {
        public App ()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 用於導覽的Frame物件
        /// </summary>
        public Frame RootFrame { get; private set; }

        protected override void OnLaunched ( LaunchActivatedEventArgs args )
        {
            // 案例化Frame物件
            RootFrame = new Frame();
            // 將目前Frame作為視窗的內容
            Window.Current.Content = RootFrame;
            // 導覽到頁面一
            RootFrame.Navigate(typeof(FirstPage));
            // 啟動目前視窗
            Window.Current.Activate();
        }
    }
}
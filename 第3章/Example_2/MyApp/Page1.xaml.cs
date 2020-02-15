using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// “空白頁”項範本在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介紹

namespace MyApp
{
    /// <summary>
    /// 可用於自己或導覽至 Frame 內定的空白頁。
    /// </summary>
    public sealed partial class Page1 : Page
    {
        public Page1 ()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo ( NavigationEventArgs e )
        {
            Debug.WriteLine("Page 1：OnNavigatedTo方法被呼叫。");
        }

        protected override void OnNavigatingFrom ( NavigatingCancelEventArgs e )
        {
            Debug.WriteLine("Page 1：OnNavigatingFrom方法被呼叫。");
        }

        protected override void OnNavigatedFrom ( NavigationEventArgs e )
        {
            Debug.WriteLine("Page 1：OnNavigatedFrom方法被呼叫。");
        }
    }
}

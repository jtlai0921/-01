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

// “空白頁”項範本在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介紹

namespace MyApp
{
    /// <summary>
    /// 可用於自己或導覽至 Frame 內定的空白頁。
    /// </summary>
    public sealed partial class DisplayPage : Page
    {
        public DisplayPage ()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 在此頁將要在 Frame 中顯示時進行呼叫。
        /// </summary>
        /// <param name="e">描述如何存取此頁的事件資料。
        /// 此參數通常用於組態頁。</param>
        protected override void OnNavigatedTo ( NavigationEventArgs e )
        {
            if (e.Parameter != null && e.Parameter is Dictionary<string, string>)
            {
                // 取得導覽參數
                Dictionary<string, string> getdata = (Dictionary<string, string>)e.Parameter;
                // 顯示內容
                tbID.Text = getdata["id"];
                tbName.Text = getdata["name"];
                tbAge.Text = getdata["age"];
            }
        }
    }
}

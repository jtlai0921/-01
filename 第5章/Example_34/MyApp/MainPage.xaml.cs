﻿using System;
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


using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;


namespace MyApp
{
    /// <summary>
    /// 可用於自己或導覽至 Frame 內定的空白頁。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// 在此頁將要在 Frame 中顯示時進行呼叫。
        /// </summary>
        /// <param name="e">描述如何存取此頁的事件資料。
        /// 此參數通常用於組態頁。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Uri uri = new Uri("http://msdn.microsoft.com/zh-cn/");
            wv.Navigate(uri);
        }

        private async void OnClick ( object sender, RoutedEventArgs e )
        {
            using (InMemoryRandomAccessStream ms=new InMemoryRandomAccessStream())
            {
                // 捕捉HTML內容並儲存到記憶體流中
                await wv.CapturePreviewToStreamAsync(ms);
                // 建立點陣圖物件
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(ms);
                // 顯示圖形
                img.Source = bmp;
            }
        }
    }
}

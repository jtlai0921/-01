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
using Windows.UI.Popups;
using Windows.UI;

// “空白頁”項範本在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介紹

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
            // TODO: 準備此處顯示的頁面。

            // TODO: 若果您的套用程式包括多個頁面，請確保
            // 透過登錄以下事件來處理硬體“後退”按鈕:
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed 事件。
            // 若果使用由某些範本提供的 NavigationHelper，
            // 則系統會為您處理該事件。
        }

        private async void OnTapped ( object sender, TappedRoutedEventArgs e )
        {
            TextBlock tb = sender as TextBlock;
            PopupMenu menu = new PopupMenu();
            // 用於響應選單指令的回調
            UICommandInvokedHandler invokedHandler = ( cmd ) =>
            {
                SolidColorBrush brush = cmd.Id as SolidColorBrush;
                tb.Foreground = brush;
            };
            // 加入選單項
            UICommand cmdRed = new UICommand("紅", invokedHandler, new SolidColorBrush(Colors.Red));
            UICommand cmdYellow = new UICommand("黃", invokedHandler, new SolidColorBrush(Colors.Yellow));
            UICommand cmdPurple = new UICommand("紫", invokedHandler, new SolidColorBrush(Colors.Purple));
            menu.Commands.Add(cmdRed);
            menu.Commands.Add(cmdYellow);
            menu.Commands.Add(cmdPurple);
            // 計算TextBlock物件相對於目前視窗的位置座標
            GeneralTransform gt = tb.TransformToVisual(null);
            Point popupPoint = gt.TransformPoint(new Point(0d, tb.ActualHeight));
            // 顯示選單
            await menu.ShowAsync(popupPoint);
        }


    }
}

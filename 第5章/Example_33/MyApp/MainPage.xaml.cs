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

        private void OnLoaded ( object sender, RoutedEventArgs e )
        {
            // 自訂HTML內容
            string html = "<html>" +
                            "<head>" +
                                "<title>test</title>" +
                                "<script type=\"text/javascript\">" +
                                    "function setFontSize(size) {" +
                                        "var ele = document.getElementById(\"sptext\");" +
                                        "ele.style.fontSize = size + 'px';" +
                                    "}" +
                                "</script>" +
                            "</head>" +
                            "<body style=\"color: white; background-color: black;\">" +
                                "<span id=\"sptext\" style=\"font-size:20px\">" +
                                    "範例文字" +
                                "</span>" +
                            "</body>" +
                        "</html>";
            // 載入HTML內容
            (sender as WebView).NavigateToString(html);
        }

        private async void OnClick ( object sender, RoutedEventArgs e )
        {
            Button btn = (Button)sender;
            short tag = Convert.ToInt16(btn.Tag);
            string arg = ""; //傳遞給指令稿函數的參數
            switch (tag)
            {
                case 1:
                    arg = "20";
                    break;
                case 2:
                    arg = "32";
                    break;
                case 3:
                    arg = "45";
                    break;
            }
            btn.IsEnabled = false;
            // 執行HTML內容中的指令稿函數
            await webView.InvokeScriptAsync("setFontSize", new string[] { arg });
            btn.IsEnabled = true;
        }
    }
}

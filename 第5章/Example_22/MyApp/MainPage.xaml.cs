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

        private async void OnClick ( object sender, RoutedEventArgs e )
        {
            // 案例化MessageDialog物件
            MessageDialog dlg = new MessageDialog("確定要執行工作嗎?", "提示");
            // 加入指令按鈕
            UICommand cmdOK = new UICommand("確定", new UICommandInvokedHandler(OnCommandAct), 1);
            UICommand cmdCancel = new UICommand("取消", new UICommandInvokedHandler(OnCommandAct), 2);
            dlg.Commands.Add(cmdOK);
            dlg.Commands.Add(cmdCancel);
            // 顯示交談視窗
            await dlg.ShowAsync();
        }

        private void OnCommandAct ( IUICommand command )
        {
            int cmdID = (int)command.Id;
            if (cmdID == 1)
            {
                tbResult.Text = "您已經確認執行工作。";
            }
            else
            {
                tbResult.Text = "您已經放棄執行該工作。";
            }
        }
    }
}

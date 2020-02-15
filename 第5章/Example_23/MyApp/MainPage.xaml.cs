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
        public MainPage ()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// 在此頁將要在 Frame 中顯示時進行呼叫。
        /// </summary>
        /// <param name="e">描述如何存取此頁的事件資料。
        /// 此參數通常用於組態頁。</param>
        protected override void OnNavigatedTo ( NavigationEventArgs e )
        {
            // TODO: 準備此處顯示的頁面。

            // TODO: 若果您的套用程式包括多個頁面，請確保
            // 透過登錄以下事件來處理硬體“後退”按鈕:
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed 事件。
            // 若果使用由某些範本提供的 NavigationHelper，
            // 則系統會為您處理該事件。
        }

        private void OnDialogClosing ( ContentDialog sender, ContentDialogClosingEventArgs args )
        {
            // 對輸入內容進行驗證
            bool isChecked = true;
            if (txtUserName.Text == "")
            {
                tbMsg.Text="請輸入使用者名稱。";
                isChecked = false;
            }
            if (pwdNew.Password == "" || pwdNew2.Password == "")
            {
                tbMsg.Text="請輸入密碼。";
                isChecked = false;
            }
            if (pwdNew.Password != pwdNew2.Password)
            {
                tbMsg.Text="兩次輸入的密碼不一致。";
                isChecked = false;
            }
            // 當點擊“登錄”按鈕時才進行處理
            if (args.Result == ContentDialogResult.Primary)
            {
                // 若果驗證沒有透過，則不容許關閉交談視窗
                args.Cancel = !isChecked;
            }
        }

        private async void OnClick ( object sender, RoutedEventArgs e )
        {
            ContentDialogResult res = await dlgReg.ShowAsync();
            // 若果點擊了“登錄”按鈕則顯示輸入結果
            if (res == ContentDialogResult.Primary)
            {
                tbInfo.Text = string.Format("歡迎，新使用者：{0}\n您輸入的密碼為：{1}", txtUserName.Text, pwdNew.Password);
            }
            else
            {
                tbInfo.Text = "未輸入新使用者。";
            }
        }

        private void OnDialogOpened ( ContentDialog sender, ContentDialogOpenedEventArgs args )
        {
            // 清理交談視窗中的所有文字
            txtUserName.ClearValue(TextBox.TextProperty);
            pwdNew.ClearValue(PasswordBox.PasswordProperty);
            pwdNew2.ClearValue(PasswordBox.PasswordProperty);
            tbMsg.ClearValue(TextBlock.TextProperty);
        }
    }
}

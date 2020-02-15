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


        private void OnRichtextblockLoaded ( object sender, RoutedEventArgs e )
        {
            // 用於處理溢位文字的RichTextBlockOverflow物件
            RichTextBlockOverflow overFlow = null;
            // 文字是否已經溢位的標志
            bool isTextOverflow = false;
            if (this.rtTextblock.HasOverflowContent) //文字溢位
            {
                overFlow = new RichTextBlockOverflow();
                // 必須將RichTextBlockOverflow物件賦給RichTextBlock的
                // OverflowContentTarget屬性
                rtTextblock.OverflowContentTarget = overFlow;
                // 將新的RichTextBlockOverflow物件新增到FlipView的項清單中
                this.flipView.Items.Add(overFlow);
                // 呼叫UpdateLayout方法，確保呈現的文字已經由測量
                // 才能準確判斷文字是否溢位
                overFlow.UpdateLayout();
                isTextOverflow = overFlow.HasOverflowContent;
                // 透過循環繼續加入RichTextBlockOverflow物件
                while (isTextOverflow)
                {
                    RichTextBlockOverflow temp = overFlow;
                    overFlow = new RichTextBlockOverflow();
                    temp.OverflowContentTarget = overFlow;
                    this.flipView.Items.Add(overFlow);
                    // 記得呼叫以下方法更新佈局計算
                    overFlow.UpdateLayout();
                    isTextOverflow = overFlow.HasOverflowContent;
                }
            }
        }
    }
}

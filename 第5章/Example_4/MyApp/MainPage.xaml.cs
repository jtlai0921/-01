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
using Windows.UI.Xaml.Media.Animation;

// “空白頁”項範本在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介紹

namespace MyApp
{
    /// <summary>
    /// 可用於自己或導覽至 Frame 內定的空白頁。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Storyboard storyboard = null;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            CreateAnimation();
        }

        private void CreateAnimation ()
        {
            DoubleAnimationUsingKeyFrames frames = new DoubleAnimationUsingKeyFrames();
            frames.Duration = new Duration(TimeSpan.FromSeconds(4));
            LinearDoubleKeyFrame f1 = new LinearDoubleKeyFrame
            {
                KeyTime = TimeSpan.FromSeconds(0),
                Value = 0d
            };
            LinearDoubleKeyFrame f2 = new LinearDoubleKeyFrame
            {
                KeyTime = TimeSpan.FromSeconds(1),
                Value = 1d
            };
            LinearDoubleKeyFrame f3 = new LinearDoubleKeyFrame
            {
                KeyTime = TimeSpan.FromSeconds(3),
                Value = 1d
            };
            LinearDoubleKeyFrame f4 = new LinearDoubleKeyFrame
            {
                KeyTime = TimeSpan.FromSeconds(4),
                Value = 0d
            };
            frames.KeyFrames.Add(f1);
            frames.KeyFrames.Add(f2);
            frames.KeyFrames.Add(f3);
            frames.KeyFrames.Add(f4);
            Storyboard.SetTarget(frames, bd);
            Storyboard.SetTargetProperty(frames, "Opacity");
            storyboard = new Storyboard();
            storyboard.Children.Add(frames);
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

        private void OnClick ( object sender, RoutedEventArgs e )
        {
            storyboard.Begin();
        }
    }
}

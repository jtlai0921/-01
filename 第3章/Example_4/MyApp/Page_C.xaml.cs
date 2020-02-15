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

namespace MyApp
{
    public sealed partial class Page_C : Page
    {
        public Page_C ()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo ( NavigationEventArgs e )
        {
            this.tbInfo.Text = "導覽模式：" + e.NavigationMode.ToString();


            // 查詢與頁面B關聯的記錄
            var r = this.Frame.BackStack.FirstOrDefault(p => p.SourcePageType == typeof(Page_B));
            // 移除一條回復記錄
            if (r != null)
            {
                Frame.BackStack.Remove(r);
            }

        }

        private void OnBack ( object sender, RoutedEventArgs e )
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void OnForward ( object sender, RoutedEventArgs e )
        {
            if (this.Frame.CanGoForward)
            {
                this.Frame.GoForward();
            }
        }

    }
}

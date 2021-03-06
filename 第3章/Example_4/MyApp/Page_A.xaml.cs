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

namespace MyApp
{
    public sealed partial class Page_A : Page
    {
        public Page_A ()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo ( NavigationEventArgs e )
        {
            this.tbInfo.Text = "導覽模式：" + e.NavigationMode.ToString();
        }

        private void OnBack ( object sender, RoutedEventArgs e )
        {
            // 若果可以後退，便後退一頁
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void OnForward ( object sender, RoutedEventArgs e )
        {
            // 若果可以向前，則往前一頁
            if (this.Frame.CanGoForward)
            {
                this.Frame.GoForward();
            }
            else
            {
                this.Frame.Navigate(typeof(Page_B));
            }
        }

    }
}

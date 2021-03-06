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
using System.Windows.Input;

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

    }


    public class ValidCommand : ICommand
    {
        public bool CanExecute ( object parameter )
        {
            string inputStr = parameter as string;
            if (string.IsNullOrWhiteSpace(inputStr))
            {
                return false;
            }
            if (inputStr.Length < 3 || inputStr.Length > 10)
            {
                return false;
            }
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public async void Execute ( object parameter )
        {
            string msg = string.Format("您輸入了：{0}。", parameter as string);
            Windows.UI.Popups.MessageDialog dialog = new Windows.UI.Popups.MessageDialog(msg);
            await dialog.ShowAsync();
        }
    }

}

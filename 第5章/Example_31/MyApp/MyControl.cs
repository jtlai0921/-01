using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// “使用者控制項”項範本在 http://go.microsoft.com/fwlink/?LinkId=234235 上有介紹

namespace MyApp
{
    public sealed class MyControl : Control
    {
        public MyControl ()
        {
            this.DefaultStyleKey = typeof(MyControl);
        }

        /// <summary>
        /// 控制項中Image控制項的名字
        /// </summary>
        const string PART_IMAGE = "PART_Image";

        /// <summary>
        /// Image控制項的參考
        /// </summary>
        Image m_image = null;


        #region 相依項屬性
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// 要顯示的文字
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(MyControl), new PropertyMetadata(null));

        /// <summary>
        /// 要顯示的圖形
        /// </summary>
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion

        protected override void OnApplyTemplate ()
        {
            base.OnApplyTemplate();
            if (m_image != null)
            {
                // 解除事件處理綁定
                m_image.PointerPressed -= OnImagePointerPressed;
                m_image.PointerReleased -= OnImagePointerReleased;
                m_image = null;
            }
            // 找出控制項範本中的Image控制項
            m_image = GetTemplateChild(PART_IMAGE) as Image;
            if (m_image != null)
            {
                // 加入事件處理程式
                m_image.PointerPressed += OnImagePointerPressed;
                m_image.PointerReleased += OnImagePointerReleased;
            }
        }

        void OnImagePointerReleased ( object sender, PointerRoutedEventArgs e )
        {
            VisualStateManager.GoToState(this, "Normal", false);
            e.Handled = true;
        }

        void OnImagePointerPressed ( object sender, PointerRoutedEventArgs e )
        {
            VisualStateManager.GoToState(this, "Showtext", false);
            e.Handled = true;
        }

    }
}

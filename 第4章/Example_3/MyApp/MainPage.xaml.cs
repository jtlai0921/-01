using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


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
    }
}

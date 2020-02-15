using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;


namespace MyApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.Language = "zh-cn"; //設定預設語系
                Window.Current.Content = rootFrame;

                // 若果套用程式之前是被使用者關閉的，或是被動作系統結束的
                // 就要考慮對導覽狀態進行還原
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated || e.PreviousExecutionState == ApplicationExecutionState.ClosedByUser)
                {
                    // 若果本機設定中包括導覽狀態，則進行還原
                    // 否則進入預設頁面
                    object value;
                    var localSettings = ApplicationData.Current.LocalSettings;
                    if (localSettings.Values.TryGetValue("nav", out value))
                    {
                        rootFrame.SetNavigationState(value as string);
                    }
                    else
                    {
                        rootFrame.Navigate(typeof(MainPage));
                    }
                }
                else //否則直接導覽到主頁面
                {
                    rootFrame.Navigate(typeof(MainPage));
                }
            }

            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            Frame rootFrame = Window.Current.Content as Frame;
            // 取得導覽狀態
            string navstate = rootFrame.GetNavigationState();
            // 在除錯訊息中輸出該狀態內容
            System.Diagnostics.Debug.WriteLine("導覽狀態：" + navstate);
            // 將導覽狀態儲存到本機設定中
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["nav"] = navstate;

            deferral.Complete();
        }
    }
}

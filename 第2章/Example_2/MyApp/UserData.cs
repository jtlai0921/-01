using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyApp
{
    class UserData : INotifyPropertyChanged
    {
        #region 私有成員
        // 儲存目前類別的案例參考
        private static UserData _userData = null;
        private int _count = default(int);
        #endregion
        // 靜態建構函數，當靜態成員被第一次存取時呼叫
        static UserData ()
        {
            _userData = new UserData();
        }
        /// <summary>
        /// 取得或設定目前計數值
        /// </summary>
        public int Count
        {
            get { return _count; }
            set
            {
                if (value != _count)
                {
                    _count = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// 取得類別的目前案例
        /// </summary>
        public static UserData CurrentInstance
        {
            get
            {
                return _userData;
            }
        }
        /// <summary>
        /// 載入資料
        /// </summary>
        public static void LoadData ()
        {
            object settingVal = null;
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("num", out settingVal))
            {
                CurrentInstance.Count = Convert.ToInt32(settingVal);
            }
            else
            {
                CurrentInstance.Count = 0;
            }
        }
        /// <summary>
        /// 儲存資料
        /// </summary>
        public static void SaveData ()
        {
            ApplicationData.Current.LocalSettings.Values["num"] = CurrentInstance.Count;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged ( [CallerMemberName] string propName = "" )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}

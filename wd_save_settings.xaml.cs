using AduSkin.Controls.Metro;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Fujino.Encryption;
using Fujino.KCLauncher.XML;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace KC_Launcher_Settings
{
    public partial class wd_save_settings : Window
    {
        static string jsonString;
        static string _VersionNew { get; set; }
        static string _UpdateApp { get; set; }
        static string _LauncherName { get; set; }
        static string _LauncherServerAddress { get; set; }
        static string _LauncherSteamWebAPI { get; set; }
        public string _LauncherTeamSpeakAddress { get; set; }
        public string _LauncherUILauncherURL { get; set; }
        public string _URLServerAPI { get; set; }
        public string _KeyKC_L_S_API { get; set; }

        public wd_save_settings(
            string UpdateApp,
            string VersionNew,
            string LauncherName,
            string LauncherServerAddress,
            string LauncherSteamWebAPI,
            string KeyKC_L_S_API,
            string URLServerAPI,
            string LauncherTeamSpeakAddress,
            string LauncherUILauncherURL)
        {
            InitializeComponent();

            try
            {
                _UpdateApp = UpdateApp;
                _VersionNew = VersionNew;
                _LauncherName = LauncherName;
                _LauncherServerAddress = LauncherServerAddress;
                _LauncherSteamWebAPI = LauncherSteamWebAPI;
                _LauncherTeamSpeakAddress = LauncherTeamSpeakAddress;
                _LauncherUILauncherURL = LauncherUILauncherURL;
                _URLServerAPI = URLServerAPI;
                _KeyKC_L_S_API = KeyKC_L_S_API;

                DataSettings settings = new DataSettings();
                settings.UpdateApp = UpdateApp;
                settings.VersionNew = VersionNew;
                settings.LauncherName = LauncherName;
                settings.LauncherServerAddress = LauncherServerAddress;
                settings.LauncherSteamWebAPI = LauncherSteamWebAPI;
                settings.KeyKC_L_S_API = KeyKC_L_S_API;
                settings.URLServerAPI = URLServerAPI;
                settings.LauncherTeamSpeakAddress = LauncherTeamSpeakAddress;
                settings.LauncherUILauncherURL = LauncherUILauncherURL;
                KC_XmlManager.KC_XmlDataWriter(settings, "DataSettings.xml");

                DataSaveSettings dataSave = new DataSaveSettings();
                dataSave = KC_XmlManager.KC_XmlDataSaveSettingsReader("DataSaveSettings.xml");
                this.txt_passwordencryption_package.Text = dataSave.PasswordEncryption;
                this.txt_rtdb_key.Text = dataSave.DatabaseSecrets;
                this.txt_rtdb_url.Text = dataSave.DatabaseURL;

                jsonString =
                    @"{""_status"": true" +
                    @",""UpdateApp"": """ + UpdateApp +
                    @""",""VersionNew"": """ + VersionNew +
                    @""",""LauncherName"": """ + LauncherName +
                    @""",""LauncherServerAddress"": """ + LauncherServerAddress +
                    @""",""LauncherSteamWebAPI"": """ + LauncherSteamWebAPI +
                    @""",""LauncherTeamSpeakAddress"": """ + LauncherTeamSpeakAddress +
                    @""",""LauncherUILauncherURL"": """ + LauncherUILauncherURL +
                    @""",""URLServerAPI"": """ + URLServerAPI +
                    @""",""KeyKC_L_S_API"": """ + KeyKC_L_S_API + @"""}";
            }
            catch (Exception ex)
            {
                AduMessageBox.Show(ex.Message, "Save Settings", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void UpdateData()
        {
            #region
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = this.txt_rtdb_key.Text,
                BasePath = this.txt_rtdb_url.Text
            };
            IFirebaseClient client = new FirebaseClient(config);
            #endregion

            var dataAutoUpdate = new DataAutoUpdate
            {
                _status = true,
                UpdateApp = _UpdateApp,
                VersionNew = _VersionNew
            };

            FirebaseResponse response = await client.UpdateTaskAsync("KC Launcher AutoUpdate", dataAutoUpdate);
            DataAutoUpdate autoUpdate = response.ResultAs<DataAutoUpdate>();

            var dataLauncherSettings = new DataLauncherSettings
            {
                _status = true,
                LauncherName = _LauncherName,
                LauncherServerAddress = _LauncherServerAddress,
                LauncherSteamWebAPI = _LauncherSteamWebAPI,
                LauncherTeamSpeakAddress = _LauncherTeamSpeakAddress,
                LauncherUILauncherURL = _LauncherUILauncherURL
            };

            FirebaseResponse response2 = await client.UpdateTaskAsync("KC Launcher Settings", dataLauncherSettings);
            DataLauncherSettings dataLauncher = response2.ResultAs<DataLauncherSettings>();

            var dataServiceAPI = new DataServiceAPI
            {
                _status = true,
                URLServerAPI = _URLServerAPI,
                KeyKC_L_S_API = _KeyKC_L_S_API
            };

            FirebaseResponse response3 = await client.UpdateTaskAsync("KC Launcher Service API", dataServiceAPI);
            DataServiceAPI serviceAPI = response3.ResultAs<DataServiceAPI>();

            AduMessageBox.Show("ปรับใช้การตั้งค่าสำเร็จ!\nแต่หากไม่พบการเปลี่ยนแปลงบน Realtime Database โปรดตรวจสอบ 'ลิ้งค์ Realtime Database' หรือ 'คีย์ Database Secrets' ว่าถูกต้องหรือไม่", "Save Settings", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        #region
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void lbl_exitapp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btn_export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.SaveDataSaveSettings();

                Directory.CreateDirectory("Data Export");

                using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Data Export\kc_packages.json"))
                {
                    if (this.txt_passwordencryption_package.Text == "")
                    {
                        writer.WriteLine(jsonString);
                    }
                    else
                    {
                        writer.WriteLine(Encryption.EncryptString(jsonString, this.txt_passwordencryption_package.Text));
                    }
                    writer.Flush();
                }

                using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Data Export\Data KC Packages for n.point.txt"))
                {
                    writer.WriteLine(jsonString);
                    writer.Flush();
                }

                MessageBoxResult result = AduMessageBox.Show("ระบบทำการ Export ไฟล์ 'kc_packages.json' และ\n'Data KC Packages for n.point.txt' สำเร็จ!", "Save Settings", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + @"Data Export");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                AduMessageBox.Show(ex.Message, "Save Settings", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_login_rdb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.SaveDataSaveSettings();
                this.UpdateData();
            }
            catch (Exception ex)
            {
                AduMessageBox.Show(ex.Message, "Save Settings", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveDataSaveSettings()
        {
            DataSaveSettings dataSave = new DataSaveSettings();
            dataSave.PasswordEncryption = this.txt_passwordencryption_package.Text;
            dataSave.DatabaseSecrets = this.txt_rtdb_key.Text;
            dataSave.DatabaseURL = this.txt_rtdb_url.Text;
            KC_XmlManager.KC_XmlDataWriter(dataSave, "DataSaveSettings.xml");
        }
        #endregion
    }
}

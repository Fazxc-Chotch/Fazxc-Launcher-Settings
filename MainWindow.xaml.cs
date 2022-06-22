using AduSkin.Controls.Metro;
using Fujino.KCLauncher.XML;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace KC_Launcher_Settings
{
    public partial class MainWindow : Window
    {
        static string _filedataname = "DataSettings.xml";

        #region
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                this.GetDateTimeUpdate();

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + _filedataname))
                {
                    this.ReadDataSettings();
                }
                else
                {
                    File.Create(AppDomain.CurrentDomain.BaseDirectory + _filedataname);
                    this.ReadDataSettings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KC Launcher Settings", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lbl_exitapp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btn_save_settings_Click(object sender, RoutedEventArgs e)
        {
            this.DateTimeUpdate();
            this.CheckInput();
        }

        private void btn_test_server_api_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.txt_server_api.Text != "")
                {
                    Process.Start(this.txt_server_api.Text);
                    string jsonString = @"{""kc_playercount"": ""???" + @""",""kc_playermax"": ""???" + @""",""_connected"": ""???" + @"""}";
                    MessageBox.Show("หากคุณมองเห็นข้อความ: " + jsonString + "\nนั้นหมายถึงลิ้งค์สามารถใช้งานได้\n\nแต่หากคุณไม่สามารถเข้าถึงลิ้งค์: " + this.txt_server_api.Text + " ได้ โปรดติดตั้ง Script KC_L_S_API ในเซิร์ฟเวอร์ของคุณและ Start เซิร์ฟเวอร์ของคุณและลองอีกครั้ง\n\nแต่หากคุณไม่สามารถเข้าถึงลิ้งค์: " + this.txt_server_api.Text + " ได้ โปรดอนุญาต Apache HTTP ใน Windows Firewall", "KC Settings Launcher", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KC Launcher Settings", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DateTimeUpdate()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"datetimeupdate.txt"))
                {
                    writer.WriteLine("แก้ไขการตั้งค่าล่าสุดเมื่อวันที่ " + DateTime.Now.ToString("MM/dd/yyyy") + " เวลา " + DateTime.Now.ToString("HH:mm:ss"));
                    writer.Flush();
                }
                this.GetDateTimeUpdate();
            }
            catch { }
        }

        private void GetDateTimeUpdate()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "datetimeupdate.txt"))
            {
                lbl_datetime_edit.Content = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "datetimeupdate.txt");
            }
        }
        #endregion

        private void ReadDataSettings()
        {
            try
            {
                DataSettings settings = new DataSettings();
                settings = KC_XmlManager.KC_XmlDataSettingsReader(_filedataname);
                this.txt_launcher_update_url.Text = settings.UpdateApp;
                this.txt_launcher_ver.Text = settings.VersionNew;
                this.txt_launcher_name.Text = settings.LauncherName;
                this.txt_server_address.Text = settings.LauncherServerAddress;
                this.txt_steam_api_key.Text = settings.LauncherSteamWebAPI;
                this.txt_kclsapi_key.Text = settings.KeyKC_L_S_API;
                this.txt_server_api.Text = settings.URLServerAPI;
                this.txt_server_address_teamspeak.Text = settings.LauncherTeamSpeakAddress;
                this.txt_launcher_uilauncher.Text = settings.LauncherUILauncherURL;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KC Launcher Settings", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckInput()
        {
            try
            {
                if (this.txt_launcher_update_url.Text == "")
                {
                    AduMessageBox.Show("โปรดกรอกลิงค์ดาวน์โหลดไฟล์อัพเดต!", "Check Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (this.txt_launcher_ver.Text == "")
                {
                    AduMessageBox.Show("โปรดกรอกเวอร์ชั่น Launcher ล่าสุด!", "Check Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (this.txt_launcher_name.Text == "")
                {
                    AduMessageBox.Show("โปรดกรอกชื่อ Launcher!", "Check Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (this.txt_server_address.Text == "")
                {
                    AduMessageBox.Show("ที่อยู่ของเซิร์ฟเวอร์สำหรับเชื่อมต่อ FiveM!", "Check Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (this.txt_steam_api_key.Text == "")
                {
                    AduMessageBox.Show("โปรดกรอกคีย์ Steam Web API!", "Check Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (this.txt_kclsapi_key.Text == "")
                {
                    AduMessageBox.Show("โปรดกรอกคีย์ KC_L_S_API!", "Check Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (this.txt_server_api.Text == "")
                {
                    AduMessageBox.Show("โปรดกรอกลิงค์ Server API!", "Check Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (this.txt_launcher_uilauncher.Text == "")
                {
                    AduMessageBox.Show("โปรดกรอกลิงค์ UI Launcher!", "Check Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                wd_save_settings _Save_Settings = new wd_save_settings(
                    this.txt_launcher_update_url.Text,
                    this.txt_launcher_ver.Text,
                    this.txt_launcher_name.Text,
                    this.txt_server_address.Text,
                    this.txt_steam_api_key.Text,
                    this.txt_kclsapi_key.Text,
                    this.txt_server_api.Text,
                    this.txt_server_address_teamspeak.Text,
                    this.txt_launcher_uilauncher.Text);

                _Save_Settings.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KC Launcher Settings", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

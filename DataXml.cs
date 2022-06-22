namespace KC_Launcher_Settings
{
    public class DataSettings
    {

        private string _LauncherName;
        public string LauncherName
        {
            get { return _LauncherName; }
            set { _LauncherName = value; }
        }

        private string _LauncherServerAddress;
        public string LauncherServerAddress
        {
            get { return _LauncherServerAddress; }
            set { _LauncherServerAddress = value; }
        }

        private string _LauncherSteamWebAPI;
        public string LauncherSteamWebAPI
        {
            get { return _LauncherSteamWebAPI; }
            set { _LauncherSteamWebAPI = value; }
        }

        private string _KeyKC_L_S_API;
        public string KeyKC_L_S_API
        {
            get { return _KeyKC_L_S_API; }
            set { _KeyKC_L_S_API = value; }
        }

        private string _URLServerAPI;
        public string URLServerAPI
        {
            get { return _URLServerAPI; }
            set { _URLServerAPI = value; }
        }

        private string _UpdateApp;
        public string UpdateApp
        {
            get { return _UpdateApp; }
            set { _UpdateApp = value; }
        }

        private string _VersionNew;
        public string VersionNew
        {
            get { return _VersionNew; }
            set { _VersionNew = value; }
        }


        private string _LauncherTeamSpeakAddress;
        public string LauncherTeamSpeakAddress
        {
            get { return _LauncherTeamSpeakAddress; }
            set { _LauncherTeamSpeakAddress = value; }
        }


        private string _LauncherUILauncherURL;
        public string LauncherUILauncherURL
        {
            get { return _LauncherUILauncherURL; }
            set { _LauncherUILauncherURL = value; }
        }

    }

    public class DataSaveSettings
    {
        private string _DatabaseURL;
        public string DatabaseURL
        {
            get { return _DatabaseURL; }
            set { _DatabaseURL = value; }
        }

        private string _DatabaseSecrets;
        public string DatabaseSecrets
        {
            get { return _DatabaseSecrets; }
            set { _DatabaseSecrets = value; }
        }

        private string _PasswordEncryption;
        public string PasswordEncryption
        {
            get { return _PasswordEncryption; }
            set { _PasswordEncryption = value; }
        }
    }

}

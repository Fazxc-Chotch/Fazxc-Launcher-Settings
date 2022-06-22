using KC_Launcher_Settings;
using System.IO;
using System.Xml.Serialization;

namespace Fujino.KCLauncher.XML
{
    public class KC_XmlManager
    {
        public static void KC_XmlDataWriter(object obj, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, obj);
            writer.Close();
        }

        public static DataSettings KC_XmlDataSettingsReader(string filename)
        {
            DataSettings data = new DataSettings();
            XmlSerializer serializer = new XmlSerializer(typeof(DataSettings));
            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            data = (DataSettings)serializer.Deserialize(stream);
            stream.Close();
            return data;
        }

        public static DataSaveSettings KC_XmlDataSaveSettingsReader(string filename)
        {
            DataSaveSettings data = new DataSaveSettings();
            XmlSerializer serializer = new XmlSerializer(typeof(DataSaveSettings));
            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            data = (DataSaveSettings)serializer.Deserialize(stream);
            stream.Close();
            return data;
        }
    }
}

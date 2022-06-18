using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using Jirka.Snake.Logic;

namespace Jirka.Snake.UI.WPF.Class
{
    public static class XMLSerialization
    {

        public static void Save(Player player)
        {
            using (var file = new StreamWriter(@"data.xml"))
            {
                var writer = new XmlSerializer(typeof(Player));
                writer.Serialize(file, player);
                file.Close();
            }
        }

        public static Player? Load()
        {
            
            using (var file = new StreamReader(@"data.xml"))
            {
                var reader = new XmlSerializer(typeof(Player));
                Player? player = reader.Deserialize(file) as Player;
                file.Close();

                if (CheckPlayer(player)) return player;
                else return null;
            }
        }

        public static bool CheckPlayer(Player player)
        {
            if (player == null || player.Name == null) return false;
            return true;
        }

    }
}

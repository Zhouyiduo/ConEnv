using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConEnv.Model
{
    public class Soft
    {
        private List<Vison> _visons = new List<Vison>();
        public List<Vison> Visons
        {
            set
            {
                _visons = value;
            }
            get
            {
                return _visons;
            }
        }


        static public void Save( Soft soft,string sPath )
        {
            if ( !string.IsNullOrWhiteSpace(sPath) )
            {
                Type type = soft.GetType();
                using (StreamWriter writer = new StreamWriter(sPath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                    xmlSerializer.Serialize(writer, soft);
                }
            }
        }

        static public void Open( ref Soft soft,string sPath )
        {
            if (File.Exists(sPath))
            {
                using (StreamReader reader = new StreamReader(sPath))
                {
                    Type type = soft.GetType();
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                    soft = xmlSerializer.Deserialize(reader) as Soft;
                }
            }
        }
    }
}

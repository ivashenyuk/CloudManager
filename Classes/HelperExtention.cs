using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Graduation_Work.Classes
{
    public static class HelperExtention
    {
        public static byte[] PackToXml<T>(this T @object)
        {
            XmlSerializer fileSerializer = new XmlSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();

            // Сериализуем объект
            fileSerializer.Serialize(stream, @object);

            // Считываем поток в байты
            stream.Position = 0;
            Byte[] pack = new Byte[stream.Length];
            stream.Read(pack, 0, Convert.ToInt32(stream.Length));

            return pack;
        }

        public static T UnpackFromXml<T>(this byte[] pack)
        {
            XmlSerializer fileSerializer = new XmlSerializer(typeof(T));
            MemoryStream stream1 = new MemoryStream();

            // Считываем информацию о файле
            stream1.Write(pack, 0, pack.Length);
            stream1.Position = 0;

            // Вызываем метод Deserialize
            T infoFile = (T)fileSerializer.Deserialize(stream1);


            return infoFile;
        }
    }
}

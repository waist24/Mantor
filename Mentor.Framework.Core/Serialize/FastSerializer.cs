using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Core.Serialize
{
    public static class FastSerializer
    {
        static public byte[] Serialize(object target,bool isCompress = false)
        {
            if (target == null)
                return null;

            byte[] bytes;
            
            using (var memoryStream = new MemoryStream())
            {
                IFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, target);
                bytes = memoryStream.ToArray();
            }
            return bytes;
        }

        static public T DeSerialize<T>(byte[] source,bool isDeCompress = false)
        {
            T ReturnValue;
            using (var memoryStream = new MemoryStream(source))
            {
                IFormatter binaryFormatter = new BinaryFormatter();
                ReturnValue = (T)binaryFormatter.Deserialize(memoryStream);
            }
            return ReturnValue;
        }
    }
}

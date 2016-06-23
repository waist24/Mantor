using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Core.Serialize
{
    public class Serializer
    {
        public Serializer()
        {

        }
        public byte[] Serialize<T>(T target)
        {
            return null;
        }

        public T DeSerialize<T>(byte[] source)
        {
            return default(T);
        }
    }
}

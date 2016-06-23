using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Message
{
    public sealed class MessageResponseContext
    {
        public object[] Results { get; set; }

        public int ElapsedTime { get; set; }

        public ResultCode ResultCode { get; set; }


    }
}

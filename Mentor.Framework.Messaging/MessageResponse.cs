using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Communication
{
    public sealed class MessageResponse
    {
        public object[] Results { get; set; }

        public int ElapsedTime { get; set; }

        public ResultCode ResultCode { get; set; }


    }
}

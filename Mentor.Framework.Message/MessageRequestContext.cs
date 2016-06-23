using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Message
{
    public class MessageRequestContext
    {
        public string ServiceID { get; set; }

        public Dictionary<object, object> Arguments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MessageServiceAttribute : System.Attribute
    {
        public MessageServiceAttribute(string serviceId)
        {
            ServiceId = serviceId;
        }
        public string ServiceId { get; set; }
                      
      
    }
}

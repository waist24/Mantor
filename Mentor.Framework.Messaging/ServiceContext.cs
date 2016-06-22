using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Communication
{
    public class ServiceContextBase
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string IP { get; set; }

        public DateTime RequestTime { get; set; }
    }

    public sealed class ServiceContext : ServiceContextBase
    {
        public string ServiceID { get; set; }

        public Dictionary<object,object> Arguments { get; set; }
    }
}

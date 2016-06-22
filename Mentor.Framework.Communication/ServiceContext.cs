using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Communication
{
    public sealed class ServiceContext
    {
        public string ServiceID { get; set; }

        public Dictionary<object,object> Arguments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Message
{
    public class MessageEventArgs
    {
        public List<MessageResponseContext> MessageResponseContexts { get; set; }
    }
}

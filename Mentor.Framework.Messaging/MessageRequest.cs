using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Messaging
{
    public sealed class MessageRequest
    {
        private readonly List<ServiceContext> serviceContext;

        public MessageRequest()
        {
            serviceContext = new List<ServiceContext>();
        }
        public List<ServiceContext> ServiceContexts { get; set; }

        public bool IsShowProgressWindow { get; set; }

        static public MessageRequest Create(string url)
        {
            return new MessageRequest();
        }

        public MessageResponse GetResponse(int timeOut = 300)
        {
            return null;
        }

        public void GetResponseAsync(EventHandler<MessageEventArgs> handler, int timeOut = 300)
        {
            
        }

       
        public void Cancel()
        {

        }
    }
}

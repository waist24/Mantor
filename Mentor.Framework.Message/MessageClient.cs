using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.Framework.Message
{
    public sealed class MessageClient
    {
        private readonly List<MessageRequestContext> messageReqeustContext;

        public MessageClient()
        {
            messageReqeustContext = new List<MessageRequestContext>();
        }
        public List<MessageRequestContext> MessageReqeustContexts
        {
            get
            {
                return messageReqeustContext;
            }
        }

        public bool IsShowProgressWindow { get; set; }

        static public MessageClient Create(string url)
        {
            return new MessageClient();
        }

        public MessageResponseContext GetResponse(int timeOut = 300)
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

using Mentor.Framework.Core.Serialize;
using NATS.Client;
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

        public List<MessageResponseContext> GetResponse(int timeOut = 300)
        {
            return this.Request(this.MessageReqeustContexts);
        }

        public void GetResponseAsync(EventHandler<MessageEventArgs> handler, int timeOut = 300)
        {
            if (handler == null)
                throw new Exception("handler 값이 null입니다. ");

            var task = Task<List<MessageResponseContext>>.Factory.StartNew 
                (
                    () => this.Request(this.MessageReqeustContexts )
                );
            task.ContinueWith((t) => 
                    {
                        if (handler != null)
                            handler(this, new MessageEventArgs() { MessageResponseContexts = t.Result });
                    }, TaskScheduler.FromCurrentSynchronizationContext() );
        }

        private List<MessageResponseContext> Request(List<MessageRequestContext> messageReqeustContexts)
        {
            Options opts = ConnectionFactory.GetDefaultOptions();
            opts.Url = Defaults.Url;
            var data = FastSerializer.Serialize(messageReqeustContexts);
            List<MessageResponseContext> result = null;
            using (IConnection c = new ConnectionFactory().CreateConnection(opts))
            {
                var msg = c.Request("ADMIN", data);
                result = FastSerializer.DeSerialize<List<MessageResponseContext>>(msg.Data);
                c.Flush();
            }
            return result;
        }

        public void Cancel()
        {

        }
    }
}

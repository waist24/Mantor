using Mentor.Framework.Core.Serialize;
using NATS.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mentor.Framework.Message
{
    public sealed class MessageClient
    {
        private readonly List<MessageRequestContext> messageReqeustContext;

        private CancellationTokenSource cts = new CancellationTokenSource();
       

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
            return this.Request(this.MessageReqeustContexts, timeOut);
        }

        public void GetResponseAsync(EventHandler<MessageEventArgs> handler, int timeOut = 30 * 1000)
        {
            var token = cts.Token;

            if (handler == null)
                throw new Exception("handler 값이 null입니다. ");

            var task = Task<List<MessageResponseContext>>.Factory.StartNew 
                (
                    () => this.Request(this.MessageReqeustContexts , timeOut)
                ,token);
            task.ContinueWith((t) => 
                    {
                        var args = new MessageEventArgs();
                        if (t.Status == TaskStatus.Canceled)
                        {
                            var result = new List<MessageResponseContext>();
                            foreach (var context in MessageReqeustContexts)
                            {
                                var mrc = new MessageResponseContext();
                                mrc.ResultCode = ResultCode.CANCEL;
                                mrc.ResultMessage = "Operation Canceled.";
                                result.Add(mrc);
                            }
                            args.MessageResponseContexts = result;
                        }
                        else
                        {
                            args.MessageResponseContexts = t.Result;
                        }
                        if (handler != null)
                            handler(this,args);
                    }, TaskScheduler.FromCurrentSynchronizationContext() );


        }
        
        private List<MessageResponseContext> Request(List<MessageRequestContext> messageReqeustContexts,int timeout)
        {
            List<MessageResponseContext> result = null;
            try
            {
                Options opts = ConnectionFactory.GetDefaultOptions();
                opts.Url = Defaults.Url;
                var data = FastSerializer.Serialize(messageReqeustContexts);
                using (IConnection c = new ConnectionFactory().CreateConnection(opts))
                {
                    var msg = c.Request(Global.TRANSPORT_CHANNEL , data, timeout);
                    result = FastSerializer.DeSerialize<List<MessageResponseContext>>(msg.Data);
                    c.Flush();
                }
            }
            catch (Exception ex)
            {
                result = new List<MessageResponseContext>();
                foreach (var context in messageReqeustContexts)
                {
                    var mrc = new MessageResponseContext();
                    mrc.ResultCode = ResultCode.FAIL;
                    mrc.ResultMessage = ex.Message;
                    result.Add(mrc);
                }
            }
            return result;
        }

        public void Cancel()
        {
            cts.Cancel();
        }
    }
}

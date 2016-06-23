
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Mentor.Framework.Message;
namespace Mentor.Client.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url = "127.0.0.1";
            var msgClient = MessageClient.Create(url);
            msgClient.MessageReqeustContexts.Add(new MessageRequestContext()
            {
                ServiceID = "TypeName#Method1",
                Arguments = new Dictionary<object, object>()
                    {
                        { "Argument1", 1},
                        { "Argument2", "test"},
                        { "Argument3", true},
                        { "Argument4", new string[] { "1", "apple" }},
                    }
            });
            msgClient.MessageReqeustContexts.Add(new MessageRequestContext()
            {
                ServiceID = "TypeName#Method2",
                Arguments = new Dictionary<object, object>()
                    {
                        { "Argument1", 1},
                        { "Argument2", "test"},
                    }
            });

            msgClient.IsShowProgressWindow = true;

            // 동기처리 방식
            var msgResponseContext = msgClient.GetResponse(Global.TimeOut);
            if (msgResponseContext.ResultCode == ResultCode.SUCCESS)
            {
                var dtData = (DataSet)msgResponseContext.Results[0];
                var count = msgResponseContext.Results[1];
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            
            var url = "127.0.0.1";
            var msgClient = MessageClient.Create(url);
            msgClient.MessageReqeustContexts.Add(new MessageRequestContext()
            {
                ServiceID = "TypeName#Method1",
                Arguments = new Dictionary<object, object>()
                    {
                        { "Argument1", 1},
                        { "Argument2", "test"},
                        { "Argument3", true},
                        { "Argument4", new string[] { "1", "apple" }},
                    }
            });
            msgClient.MessageReqeustContexts.Add(new MessageRequestContext()
            {
                ServiceID = "TypeName#Method2",
                Arguments = new Dictionary<object, object>()
                    {
                        { "Argument1", 1},
                        { "Argument2", "test"},
                    }
            });

            msgClient.IsShowProgressWindow = true;

            // 비동기처리 방식
            EventHandler<MessageEventArgs> msgHandler = (s, a) =>
            {
                if (a.Response.ResultCode == ResultCode.SUCCESS)
                {
                    
                };
            };
            msgClient.GetResponseAsync(msgHandler, Global.TimeOut);

            msgClient.GetResponseAsync(OnProcess, Global.TimeOut);

  
        }

        private void OnProcess(object sender, MessageEventArgs args)
        {
            if (args.Response.ResultCode == ResultCode.SUCCESS)
            {
                //
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
           /*
            List<byte[]> result = new List<byte[]>();
            result.Add(Encoding.Unicode.GetBytes("string1"));
            result.Add(Encoding.Unicode.GetBytes("string2"));
            result.Add(Encoding.Unicode.GetBytes("string3"));

            var kkk = result.ToArray();

            //var kjjjk = ( byte[]) kkk;

            var flattenedByteArray = result.SelectMany(bytes => bytes).ToArray<byte>();

            //var byteList = flattenedByteArray.ToArray<byte[]>();

            //foreach(var b in byteList)
            //{
            //    var a = Encoding.Unicode.GetString((byte[])b);
            //}
            */
        }
    }
}

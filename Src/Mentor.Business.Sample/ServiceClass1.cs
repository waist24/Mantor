using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mentor.Framework.Core.Attribute;
using System.Data;

namespace Mentor.Business.Sample
{
    [MessageService("Mentor.Business.Sample.ServiceClass1")]
    public class ServiceClass1
    {
        public int GetMethod1(string a,int b)
        {

            return 1;
        }

        public DataSet GetMethod2(string a, int b)
        {
            return new DataSet();
        }
    }
}

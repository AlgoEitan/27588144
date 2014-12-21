using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

//namespace WcfService2
//{

    [ServiceContract]
    [ServiceKnownType(typeof(A))]
    [ServiceKnownType(typeof(B))]
    public interface IService2
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        void GetR(IObject obj);


    }
//}

using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

//namespace WcfService1
//{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void Active()
        {
            string url = @"http://localhost:59533/Service1.svc/GetR";

            B bObj= new B();
            bObj.s2 = "StringToSend";
            

//            var json = new JavaScriptSerializer().Serialize(bObj);

            string json;
            using (var ms = new MemoryStream())
            {
                var ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(B));
                ser.WriteObject(ms, bObj);
                json = System.Text.Encoding.UTF8.GetString(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            }

            json = "{a:b}";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/plain";

                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                
//                ASCIIEncoding encoding = new ASCIIEncoding();
//                byte[] byteArray = encoding.GetBytes(json);

                

                dataStream.Write(byteArray, 0, byteArray.Length);



                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string result;
                using (Stream data = response.GetResponseStream())
                using (var reader = new StreamReader(data))
                {
                    result = reader.ReadToEnd();
                }
                
            }
            catch (Exception exp)
            {
                string s = exp.Message;
            }

        }

    }
//}

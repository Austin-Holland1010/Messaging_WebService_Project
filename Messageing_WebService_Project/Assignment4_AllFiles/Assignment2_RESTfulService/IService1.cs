using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Assignment2_RESTfulService
{
    [ServiceContract]
    public interface IService1
    {
        //http://localhost:56451/Service1.svc/sendMsg?senderID=10&receiverID=5&msg=test1&date=2:21:23
        [OperationContract]
        [WebGet(UriTemplate = "sendMsg?senderID={senderID}&receiverID={recieverID}&msg={msg}&date={date}",
            RequestFormat = WebMessageFormat.Json)]
        void sendMsg(string senderID, string recieverID, string msg, string date);

        [OperationContract]
        [WebGet(UriTemplate = "recieveMsg?recieverID={recieverID}&purge={purge}",
        RequestFormat = WebMessageFormat.Json)]
        string recieveMsg(string recieverID, bool purge);
    }
}

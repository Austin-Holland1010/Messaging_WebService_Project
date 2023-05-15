using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Web;

namespace Assignment2_RESTfulService
{ 
    public class Service1 : IService1
    {
        //http://localhost:56451/Service1.svc/sendMsg?senderID=10&receiverID=5&msg=test1&date=2:21:23
        //Used by the service to have a referecen location for the Messages.xml file
        string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Messages.xml");
        
        //This method takes the parameters and saves them as a new message in Messages.xml
        public void sendMsg(string senderID, string recieverID, string msg, string date)
        {
            XDocument xDocument = XDocument.Load(fLocation);
            XElement root = xDocument.Element("Messages");
            IEnumerable<XElement> rows = root.Descendants("Message");
            XElement firstRow = rows.First();
            firstRow.AddBeforeSelf(
                new XElement("Message",
                new XElement("senderID", senderID),
                new XElement("recieverID", recieverID),
                new XElement("msg", msg),
                new XElement("timestamp", date)));
            xDocument.Save(fLocation);
        }

        //http://localhost:56451/Service1.svc/recieveMsg?recieverID=5&purge=false
        //http://localhost:56451/Service1.svc/recieveMsg?recieverID=4&purge=true

        //This method returns all the messages of the provided recieverID. If purge == true the messages are deleted after being accessed
        public string recieveMsg(string recieverID, bool purge)
        {
            List<string> messageList = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(fLocation);
            XmlNodeList nodeList = doc.SelectNodes("/Messages/Message");

            //Parse through the Messages.xml file, add any messages to the recieverID to the string[]
            foreach(XmlNode node in nodeList)
            {
                string xmlSenderID = "";
                string xmlRecieverID = "";
                string message = "";
                string date = "";
                
                //Get the data from each attribute of the Message
                foreach(XmlNode child in node.ChildNodes)
                {
                    if(child.Name == "senderID")
                    {
                        xmlSenderID = child.InnerText;
                    }

                    if (child.Name == "recieverID")
                    {
                        xmlRecieverID = child.InnerText;
                    }

                    if (child.Name == "msg")
                    {
                        message = child.InnerText;
                    }

                    if (child.Name == "timestamp")
                    {
                        date = child.InnerText;
                    }
                }

                //Now check to see if the reciverID matches the method parameter and add to the message list
                if(xmlRecieverID.Equals(recieverID))
                {
                    messageList.Add(message);
                }
            }

            //Now delete the messages to the reciever if purge == true
            if(purge == true)
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load(fLocation);
                XmlNodeList nodes = doc2.SelectNodes("Messages/Message");
                for (int x = nodes.Count - 1; x >= 0; x--)
                {
                    string tmprecieverID = "";
                    foreach (XmlNode child in nodes[x].ChildNodes)
                    {
                        if(child.Name == "recieverID")
                        {
                            tmprecieverID = child.InnerText;
                        }
                    }
                    if(tmprecieverID.Equals(recieverID))
                    {
                        nodes[x].ParentNode.RemoveChild(nodes[x]);
                    }
                }
                doc2.Save(fLocation);
            }


            //Add the list into a string with each word delimited by a comma
            string output = "";
            for(int x = 0; x < messageList.Count; x++)
            {
                if (output.Equals(""))
                {
                    output = messageList[x];
                }
                else
                {
                    output = output + "," + messageList[x];
                }
            }
            return output;
       }
    }
}

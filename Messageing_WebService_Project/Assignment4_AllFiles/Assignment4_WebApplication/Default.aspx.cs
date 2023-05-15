using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace Assignment4_WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox_main_TextChanged(object sender, EventArgs e)
        {

        }
        protected void SendMessage_btn_Click(object sender, EventArgs e)
        {
            //Get all the values from the textboxes
            string recieverID = RecieverID_txtbox.Text;
            string senderID = SenderID_txtbox.Text;
            string message = TextBox_main.Text;
            string date = DateTime.Now.ToString("M/d/yyyy hh:mm:ss");

            //Use the values to create a call to the RESTful service (sendMsg(string senderID, string recieverID, string msg, string date))
            //http://localhost:56451/Service1.svc/sendMsg?senderID=10&receiverID=5&msg=test1

            string baseURL = "http://localhost:56451/Service1.svc/sendMsg?senderID=";
            baseURL = baseURL + senderID + "&receiverID=" + recieverID + "&msg=" + message + "&date=" + date;
            //TextBox_main.Text = baseURL;
            Uri completeUri = new Uri(baseURL);
            WebClient channel = new WebClient();
            byte[] abc = channel.DownloadData(completeUri);



        }

        protected void RecieverPage_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reciever.aspx");
        }

        protected void SendMessage_btn_Click1(object sender, EventArgs e)
        {
            //Get all the values from the textboxes
            string recieverID = RecieverID_txtbox.Text;
            string senderID = SenderID_txtbox.Text;
            string message = TextBox_main.Text;
            string date = DateTime.Now.ToString("M/d/yyyy hh:mm:ss");

            //Use the values to create a call to the RESTful service (sendMsg(string senderID, string recieverID, string msg, string date))
            //http://localhost:56451/Service1.svc/sendMsg?senderID=10&receiverID=5&msg=test1

            string baseURL = "http://localhost:56451/Service1.svc/sendMsg?senderID=";
            baseURL = baseURL + senderID + "&receiverID=" + recieverID + "&msg=" + message + "&date=" + date;
            //TextBox_main.Text = baseURL;
            Uri completeUri = new Uri(baseURL);
            WebClient channel = new WebClient();
            byte[] abc = channel.DownloadData(completeUri);
        }
    }
}
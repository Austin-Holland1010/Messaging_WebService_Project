using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace Assignment4_WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RecieverID_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RecieveNow_btn_Click(object sender, EventArgs e)
        {
            //Get the inputs from the textbox and radio button
            string recieverID = RecieverID_txtbox.Text;
            bool purge = Purge_ckBox.Checked;

            //Now create the URL for the RESTful service
            string baseURL = "http://localhost:56451/Service1.svc/recieveMsg?recieverID=";
            if (purge == true)
            {
                baseURL = baseURL + recieverID + "&purge=true";
            }
            else if (purge == false)
            {
                baseURL = baseURL + recieverID + "&purge=false";
            }

            //Call the service
            Uri completeUri = new Uri(baseURL);
            WebClient channel = new WebClient();
            byte[] abc = channel.DownloadData(completeUri);
            string result = System.Text.Encoding.Default.GetString(abc);
            
            //Get the string from within the XML tag
            for(int x = 0; x < result.Length; x++)
            {
                if(result[x] == '<')
                {
                    for(int y = x + 1; y < result.Length; y++)
                    {
                        if(result[y] == '>')
                        {
                            if(result[0] == '<' )
                            {
                                y++;
                                result = result.Remove(x, y);
                            }
                            else
                            {
                                result = result.Remove(x);
                            }
                        }
                    }
                }
            }

            //Now Break the messages apart using the ',' as a delimiter
            string[] messages = result.Split(',');

            result = "";
            
            //Add newlines between each message and save into a single string
            for(int x = 0; x < messages.Length; x++)
            {
                result = result + messages[x] + "\n\n";
            }

            //Display the messages in browser
            TextBox_main.Text = result;
        }

        protected void TextBox_main_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SendPage_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
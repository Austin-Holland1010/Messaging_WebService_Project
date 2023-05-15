<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment4_WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   

    <p>
        <asp:Button ID="RecieverPage_btn" runat="server" OnClick="RecieverPage_btn_Click" Text="Go to Reciever Page" />
        <br />
    </p>
    <p>
        RecieverID:
        <asp:TextBox ID="RecieverID_txtbox" runat="server"></asp:TextBox>
    </p>
    <p>
        SenderID:&nbsp;&nbsp;
        <asp:TextBox ID="SenderID_txtbox" runat="server"></asp:TextBox>
    </p>
    <p>
        Message:&nbsp;&nbsp;
        <br />
    <asp:TextBox ID="TextBox_main" TextMode="MultiLine" Rows="10" placeholder="Enter Text Here" runat="server" OnTextChanged="TextBox_main_TextChanged" Width="1153px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="SendMessage_btn" runat="server" OnClick="SendMessage_btn_Click1" Text="Send Message" />
    </p>

   

</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reciever.aspx.cs" Inherits="Assignment4_WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="SendPage_btn" runat="server" Text="Go to Sender Page" OnClick="SendPage_btn_Click" />
        </div>
        RecieverID:
        <asp:TextBox ID="RecieverID_txtbox" runat="server" OnTextChanged="RecieverID_txtbox_TextChanged"></asp:TextBox>
&nbsp;<asp:Button ID="RecieveNow_btn" runat="server" OnClick="RecieveNow_btn_Click" Text="Recieve Now" />
        <br />
        <br />
        <asp:CheckBox ID="Purge_ckBox" runat="server" Text="Purge" />
        <br />
        <br />
         <asp:TextBox ID="TextBox_main" TextMode="MultiLine" Rows="10" placeholder="Enter Text Here" runat="server" OnTextChanged="TextBox_main_TextChanged" Width="1153px"></asp:TextBox>
    </form>
</body>
</html>

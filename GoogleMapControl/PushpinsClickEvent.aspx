<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PushpinsClickEvent.aspx.cs" Inherits="GoogleMapControl.PushpinsClickEvent" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <h3><a href="Default.aspx">Back</a></h3>
    <h3>Pushpin click event example.</h3>
    Click any pushpin and see changed position value at bottom of page. See <b>OnPushpinCliked()</b> event in source code.
    <br />
    <br />
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Last Pushpin Clicked : <asp:Label ID="lblLastPushpin" runat="server" Text="" ForeColor="Red" Font-Bold=true></asp:Label><br />
            Position : <asp:Label ID="lblPushpin1" runat="server" Text="" ForeColor="Blue" Font-Bold=true></asp:Label><br />
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithMovingPushpins.aspx.cs" Inherits="GoogleMapControl.MapWithMovingPushpins" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3><a href="Default.aspx">Back</a></h3>
    <form id="form1" runat="server">
    <h3>Google map with moving pushpins.</h3>
    Click on buttons to move a pushpin. Click on a pushpin to see it's description.
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="btnMovePin1" runat="server" Text="Move Pushpin" OnClick="btnMovePin1_Click" />
        <asp:Button ID="btnMovePin2" runat="server" Text="Move Horse" OnClick="btnMovePin2_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

    </form>
</body>
</html>

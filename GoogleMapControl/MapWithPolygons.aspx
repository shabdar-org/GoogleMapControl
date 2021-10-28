<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithPolygons.aspx.cs" Inherits="GoogleMapControl.MapWithPolygons" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h3><a href="Default.aspx">Back</a></h3>
    <h3>Google Map with clickable pushpins.</h3>
    Click on a pushpin to see it's description.
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="btnMovePoint" runat="server" Text="Move Polygon Point" OnClick="btnMovePoint_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithDrawing.aspx.cs" Inherits="GoogleMapControl.MapWithDrawing" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h3><a href="Default.aspx">Back</a></h3>
    <h3>Drawings on Map</h3>
    Select an object (Pushpin, Polyline or Polygon) and click on Map to draw it. For Polyline and Polygons, you need to click 2 to 3 times on different locations on map to provide various points.
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Text="Pushpin" Value="Pushpin" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Polyline" Value="Polyline"></asp:ListItem>
            <asp:ListItem Text="Polygon" Value="Polygon"></asp:ListItem>
            </asp:RadioButtonList>
        </ContentTemplate>
    </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Clicked Position : <asp:Label ID="lblPushpin1" runat="server" Text="" ForeColor="Blue" Font-Bold=true></asp:Label><br />
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>
</body>
</html>

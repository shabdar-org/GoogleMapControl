<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithZoomLevels.aspx.cs" Inherits="GoogleMapControl.MapWithZoomLevels" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Simple Google Map</h3>
    <b> Note: Change zoom level by clicking + or - sign in map and then checkout Zoom Level at the bottom of the map.</b>
    <br />
        <br />

        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <h3 style="color:Red;">Zoom Level: <asp:Label ID="lblZoomLevel" runat="server" Width="200"></asp:Label></h3>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>

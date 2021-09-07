<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWithZoomLevels.aspx.cs" Inherits="MapWithZoomLevels" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Map with Zoom levels</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <h3>Simple Google Map</h3>
    <b> Note: Change zoom level by clicking + or - sign in map and then checkout Zoom Level at the bottom of the map.</b>
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

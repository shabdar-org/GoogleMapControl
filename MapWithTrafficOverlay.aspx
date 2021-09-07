<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWithTrafficOverlay.aspx.cs" Inherits="Samples_MapWithTrafficOverlay" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Google Map with clickable pushpins</title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <h3><a href="Default.aspx">Back</a></h3>
    <h3>Google Map with clickable pushpins.</h3>
    Click on a pushpin to see it's description.
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="btnToggleTraffic" runat="server" Text="Toggle Traffic Overlay" OnClick="btnToggleTraffic_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

</body>
</html>

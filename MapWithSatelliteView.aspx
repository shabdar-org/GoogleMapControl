<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWithSatelliteView.aspx.cs" Inherits="Samples_MapWithSatelliteView" %>
<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
    <h3>Google Map with Satellite View.</h3>
    Change Map Types by clicking following Buttons. These are ASP.Net buttons.
        
    <br />
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
    <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnSimple" Text="Simple Map" runat="server" OnClick="btnSimple_Click"  />
            <asp:Button ID="btnSatellite" Text="Satellite View" runat="server" OnClick="btnSatellite_Click"  />
            <asp:Button ID="btnHybrid" Text="Hybrid View" runat="server" OnClick="btnHybrid_Click"  />
        </ContentTemplate>
        </asp:UpdatePanel>
<br />

    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

</body>
</html>

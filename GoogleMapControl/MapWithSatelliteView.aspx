<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithSatelliteView.aspx.cs" Inherits="GoogleMapControl.MapWithSatelliteView" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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

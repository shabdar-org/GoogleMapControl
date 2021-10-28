<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithAutoMovingPushpinsAndDynamicBoundaries.aspx.cs" Inherits="GoogleMapControl.MapWithAutoMovingPushpinsAndDynamicBoundaries" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <h3><a href="Default.aspx">Back</a></h3>
    <h3>Google Map with automatically moving pushpins and dynamic boundaries.</h3>
    Click on a pushpin to see it's description. Note that we are using Ajax timer control to move pushpins.<br /><br />See how map boundary gets changed with every move. To stop dynamic behaviour, just change following property, <br /><br />
    GoogleMapForASPNet1.GoogleMapObject.AutomaticBoundaryAndZoom = false;
    <br />
    <br />

    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
            </asp:Timer>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

</body>
</html>

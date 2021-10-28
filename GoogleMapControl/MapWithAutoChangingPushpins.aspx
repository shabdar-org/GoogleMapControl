<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="MapWithAutoChangingPushpins.aspx.cs" Inherits="GoogleMapControl.MapWithAutoChangingPushpins" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Google map with automatically changing pushpins.</h3>
    Click on a pushpin to see it's description. Note that we are using Ajax timer control to change pushpin icons.
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick">
            </asp:Timer>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>
    </form>
</body>
</html>

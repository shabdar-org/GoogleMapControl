<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPerformanceTest.aspx.cs" Inherits="GoogleMapControl.ControlPerformanceTest" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3><a href="Default.aspx">Back</a></h3>
    <form id="form1" runat="server">

    <h3>Control's performance test.</h3>
    This control is designed for optimum performance. In this sample, 50 pushpins are loaded. Pushpin icons get changed every 5 seconds. Few vehicle pushpins keeps moving inbetween.
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick">
            </asp:Timer>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <h3><a href="Default.aspx">Return to Samples Index</a></h3>
    </form>
</body>
</html>

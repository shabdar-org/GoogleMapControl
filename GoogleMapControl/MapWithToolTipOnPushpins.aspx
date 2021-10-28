<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithToolTipOnPushpins.aspx.cs" Inherits="GoogleMapControl.MapWithToolTipOnPushpins" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h3><a href="Default.aspx">Back</a></h3>
    <h3>Google map with tooltips on Pushpins.</h3>
    Mouse hover on pushpins to see tooltips.<br /><br />
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>
</body>
</html>

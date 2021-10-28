<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="SimpleMapWithNoBubble.aspx.cs" Inherits="GoogleMapControl.SimpleMapWithNoBubble" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:GoogleMapForASPNet runat="server" ID="GoogleMapForASPNet1" />
        </div>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>
    </form>
</body>
</html>

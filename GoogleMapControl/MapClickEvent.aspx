<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapClickEvent.aspx.cs" Inherits="GoogleMapControl.MapClickEvent" %>

<%@ Register Src="~/GoogleMapControl/GoogleMapForASPNet.ascx" TagPrefix="uc1" TagName="GoogleMapForASPNet" %>


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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Clicked Position : <asp:Label ID="lblPushpin1" runat="server" Text="" ForeColor="Blue" Font-Bold=true></asp:Label><br />
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>
    </form>
</body>
</html>

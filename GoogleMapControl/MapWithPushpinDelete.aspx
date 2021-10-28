<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithPushpinDelete.aspx.cs" Inherits="GoogleMapControl.MapWithPushpinDelete" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3><a href="Default.aspx">Back</a></h3>
    <form id="form1" runat="server">
    <h3>Google map showing pushpin delete functionality</h3>
    Click on delete buttons
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="btnDeleteHorse" runat="server" Text="Delete horse" OnClick="btnDeleteHorse_Click" />
        <asp:Button ID="btnDeletePushpin" runat="server" Text="Delete pushpin" OnClick="btnDeletePushpin_Click" />
        <asp:Button ID="btnDeleteArrows" runat="server" Text="Delete arrows" OnClick="btnDeleteArrows_Click" />
        <asp:Button ID="btnDeletePolyline1" runat="server" Text="Delete Polyline1" OnClick="btnDeletePolyline1_Click" />
        <asp:Button ID="btnDeletePolyline2" runat="server" Text="Delete Polyline2" OnClick="btnDeletePolyline2_Click" />
        <asp:Button ID="btnDeletePolygon" runat="server" Text="Delete Polygon" OnClick="btnDeletePolygon_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

    </form>
</body>
</html>

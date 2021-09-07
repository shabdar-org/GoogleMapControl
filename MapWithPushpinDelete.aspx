<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWithPushpinDelete.aspx.cs" Inherits="Samples_MapWithPushPinDelete" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Map with moving pushpins</title>
</head>
<body>
    <h3><a href="Default.aspx">Back</a></h3>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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

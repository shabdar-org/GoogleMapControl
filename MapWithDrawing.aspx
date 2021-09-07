<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWithDrawing.aspx.cs" Inherits="Samples_MapWithDrawing" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Drawings on Map</title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <h3><a href="Default.aspx">Back</a></h3>
    <h3>Drawings on Map</h3>
    Select an object and click on Map to draw it.
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Text="Pushpin" Value="Pushpin" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Polyline" Value="Polyline"></asp:ListItem>
            <asp:ListItem Text="Polygon" Value="Polygon"></asp:ListItem>
            <asp:ListItem Text="Direction" Value="Direction"></asp:ListItem>
            </asp:RadioButtonList>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Clicked Position : <asp:Label ID="lblPushpin1" runat="server" Text="" ForeColor="Blue" Font-Bold=true></asp:Label><br />
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>
</body>
</html>

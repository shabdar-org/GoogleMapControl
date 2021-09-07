<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWithRecenter.aspx.cs" Inherits="Samples_SimpleMapWithMovingPushPins" %>

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
    <h3>Re-center map</h3>
    Move map by dragging it and then click on <b>Recenter Map</b> button.
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="btnRecenter" runat="server" Text="Recenter Map" OnClick="btnRecenter_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

    </form>
</body>
</html>

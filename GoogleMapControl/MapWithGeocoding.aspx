<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithGeocoding.aspx.cs" Inherits="GoogleMapControl.MapWithGeocoding" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3><a href="Default.aspx">Back</a></h3>
    <form id="form1" runat="server">
        <h3>Google map with Geocoding capability.</h3>
    Enter address or place name or postalcode and click on "Geocode Address". <br />
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<table>
<tr><td valign="top" align="right">Address :</td><td><asp:TextBox ID="txtAddress" runat="server" Height="96px" TextMode="MultiLine" Width="200px">CN Tower, Toronto</asp:TextBox></td></tr>
<tr>
<td></td><td><asp:Button ID="btnGeocode" runat="server" Text="Geocode Address" OnClick="btnGeocode_Click"  /></td>
</tr>
<tr>
<tr><td valign="top" align="right">Formatted Address :</td><td><asp:TextBox ID="txtFormattedAddress" BackColor="LightGray" runat="server" Height="96px" ReadOnly=true TextMode="MultiLine" Width="200px"></asp:TextBox></td></tr>
<tr>
<tr><td valign="top" align="right">GPS Location :</td><td><asp:TextBox ID="txtLocation" runat="server" BackColor="LightGray"  ReadOnly=true TextMode="SingleLine" Width="400px"></asp:TextBox></td></tr>
<tr>
<td></td>
<td><asp:Label ID="lblError" ForeColor="red" runat="server" Text=""></asp:Label></td>
</tr>
</table>        
    
        </ContentTemplate>
        </asp:UpdatePanel>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

    </form>
</body>
</html>

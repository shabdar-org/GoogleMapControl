<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithReverseGeocoding.aspx.cs" Inherits="GoogleMapControl.MapWithReverseGeocoding" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3><a href="Default.aspx">Back</a></h3>
    <form id="form1" runat="server">
        <h3>Google map with Reverse Geocoding capability.</h3>
    
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>

    Enter Latitude/Longitude values below and click on "Reverse Geocode".<br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<table>
<tr>
<td valign="top" align="right">Latitude :</td><td><asp:TextBox ID="txtLatitude" runat="server" TextMode="SingleLine" Width="200px">-33.867425</asp:TextBox></td>
</tr>
<tr>
<td valign="top" align="right">Longitude :</td><td><asp:TextBox ID="txtLongitude" runat="server" TextMode="SingleLine" Width="200px">151.211776</asp:TextBox></td>
</tr>
<tr>
<td></td><td><asp:Button ID="btnGeocode" runat="server" Text="Reverse Geocode" 
        OnClick="btnGeocode_Click"  /></td>
</tr>
<tr>
    <td align="right" valign="top">
        &nbsp;Nearest Address :</td>
    <td>
        <asp:TextBox ID="txtAddress" runat="server" BackColor="LightGray" 
            Height="96px" ReadOnly="true" TextMode="MultiLine" Width="200px"></asp:TextBox>
    </td>
    <tr>
        <td>
        </td>
        <td>
            <asp:Label ID="lblError" runat="server" ForeColor="red" Text=""></asp:Label>
        </td>
    </tr>
</table>        
        
            
        </ContentTemplate>
        </asp:UpdatePanel>

        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

    </form>
</body>
</html>

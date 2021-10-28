<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithDirections.aspx.cs" Inherits="GoogleMapControl.MapWithDirections" %>
<%@ Register src="GoogleMapControl/GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3><a href="Default.aspx">Back</a></h3>
    <form id="form1" runat="server">
    <h3>Map with Driving Directions</h3>
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
<br />
        
            <table>
            <tr>
            <td align="right">First Address :</td><td><asp:TextBox ID="txtFirstAddress" runat="server" Text="11 Wall Street, NY" Width="395px"></asp:TextBox></td>
            </tr>
            <tr>
            <td align="right">Second Address :</td><td><asp:TextBox ID="txtSecondAddress" runat="server" Text="345 East 24th Street, New York, NY" Width="395px"></asp:TextBox></td>
            </tr>
            <tr>
            <td align="right">Third Address  :</td><td><asp:TextBox ID="txtThirdAddress" runat="server" Text="10001" Width="395px"></asp:TextBox>(Postal Code can be used as well)</td>
            </tr>
            <tr>
            <td align="right">Show direction instructions?  :</td><td><asp:CheckBox ID="chkShowDirections" runat="server" Checked=true ></asp:CheckBox></td>
            </tr>
            <tr>
            <td align="right">Hide Markers? :</td><td><asp:CheckBox ID="chkHideMarkers" runat="server"  ></asp:CheckBox></td>
            </tr>
            <tr>
            <td align="right">Color of direction line :</td><td><asp:TextBox ID="txtDirColor" runat="server" Text="#FF2200" Width="120px"></asp:TextBox>(Hex value)</td>
            </tr>
            <tr>
            <td align="right">Direction line width :</td><td><asp:TextBox ID="txtDirWidth" runat="server" Text="3" Width="120px"></asp:TextBox>(1 to 6)</td>
            </tr>
            <tr>
            <td align="right">Direction line opacity :</td><td><asp:TextBox ID="txtDirOpacity" runat="server" Text="0.6" Width="120px"></asp:TextBox>(0.1 to 1.0)</td>
            </tr>
            <tr>
            <td></td><td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnDrawDirections" runat="server" Text="Draw Directions" OnClick="btnDrawDirections_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>

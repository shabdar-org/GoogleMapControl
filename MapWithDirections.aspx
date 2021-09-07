<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWithDirections.aspx.cs" Inherits="MapWithDirections" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Map with Driving Directions</title>
</head>
<body>
    <h3><a href="Default.aspx">Back</a></h3>
    <form id="form1" runat="server">
    <h3>Map with Driving Directions</h3>
    <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
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
        <br /><br />
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
    </form>
</body>
</html>

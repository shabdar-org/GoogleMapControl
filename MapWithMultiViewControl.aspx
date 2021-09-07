<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWithMultiViewControl.aspx.cs" Inherits="Samples_MapWithMultiViewControl" %>

<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Google Map with customized icons</title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h3><a href="Default.aspx">Back</a></h3>
        <br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">View 1</asp:LinkButton>  
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">View 2</asp:LinkButton>  
                <br /><br />
                <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server" >
                    View 1<br /><br />
                    <div>
                        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
                    </div>
               
                </asp:View>
                <asp:View ID="View2" runat="server">
                    View 2
                </asp:View>
                </asp:MultiView>
                
                
                
        </ContentTemplate>
        </asp:UpdatePanel>        
    
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>
    
<script language="javascript">
function endRequestHandler(sender, args)
{
try    {
//    for(i=0;i<result.Points.length;i++)
//    {
//            var marker = markers.getValueById(result.Points[i].ID);
//            if(marker!=null)
//            {
//                markers.removeValueById(result.Points[i].ID);
//                map.removeOverlay(marker);
//            }

//    }
        DrawGoogleMap();
    }
    catch(err)
    {
    }
}
function pageLoad()
{
    if(!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack())
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
}
</script>     
</body>
</html>

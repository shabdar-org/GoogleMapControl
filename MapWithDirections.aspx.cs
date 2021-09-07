using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MapWithDirections : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
            //For samples to run properly, set GoogleAPIKey in Web.Config file.

            //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
            GoogleMapForASPNet1.GoogleMapObject.Width = "800px"; // You can also specify percentage(e.g. 80%) here
            GoogleMapForASPNet1.GoogleMapObject.Height = "400px";
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;
        }
        //Draw direction for default addresses
        //btnDrawDirections_Click(null, null);

    }

    protected void btnDrawDirections_Click(object sender, EventArgs e)
    {
        GoogleMapForASPNet1.GoogleMapObject.Directions.ShowDirectionInstructions = chkShowDirections.Checked;
        GoogleMapForASPNet1.GoogleMapObject.Directions.HideMarkers = chkHideMarkers.Checked;
        GoogleMapForASPNet1.GoogleMapObject.Directions.PolylineColor = txtDirColor.Text;
        GoogleMapForASPNet1.GoogleMapObject.Directions.PolylineWeight = int.Parse(txtDirWidth.Text);
        GoogleMapForASPNet1.GoogleMapObject.Directions.PolylineOpacity = double.Parse(txtDirOpacity.Text);
        //Provide addresses or postal codes in following lines
        GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Clear();
        GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Add(txtFirstAddress.Text);
        GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Add(txtSecondAddress.Text);
        GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Add(txtThirdAddress.Text);
    }
}

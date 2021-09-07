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

public partial class MapWithGeocoding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 15;
        
        //GoogleMapForASPNet1.
    }
    protected void btnGeocode_Click(object sender, EventArgs e)
    {
        GooglePoint GP = new GooglePoint();
        GP.Address = txtAddress.Text;
        //GeocodeAddress() function will geocode address and set Latitude and Longitude of GP(GooglePoint) to it's respected value.
        if (GP.GeocodeAddress())
        {
            //Once GP is geocoded, you can add it to google map.
            GP.InfoHTML = GP.Address;
            txtFormattedAddress.Text = GP.Address;
            txtLocation.Text = "lat="+GP.Latitude.ToString()+", lng="+GP.Longitude.ToString();
            lblError.Text = "";

            //Set GP as center point.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = GP;
            
            //Clear any existing
            GoogleMapForASPNet1.GoogleMapObject.Points.Clear();
            //Add geocoded GP to GoogleMapObject
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);
            GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;

            //Recenter map to GP.
        }
        else
        {
            txtFormattedAddress.Text = "Unable to geocode this address";
            txtLocation.Text = "";
            lblError.Text = "Unable to geocode this address.";
        }
    }
}

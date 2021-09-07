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

public partial class Samples_MapWithTrafficOverlay : System.Web.UI.Page
{
    bool TrafficOverlay = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
            //For samples to run properly, set GoogleAPIKey in Web.Config file.
            GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

            //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
            GoogleMapForASPNet1.GoogleMapObject.Width = "700px"; // You can also specify percentage(e.g. 80%) here
            GoogleMapForASPNet1.GoogleMapObject.Height = "400px";

            //Specify initial Zoom level.
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 10;

            //Specify Center Point for map. Map will be centered on this point.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 39.91394, -75.15747);

            GoogleMapForASPNet1.GoogleMapObject.ShowTraffic = true;
        }
    }

    protected void btnToggleTraffic_Click(object sender, EventArgs e)
    {
        //Move pushpin GP3 vertically.
        //GoogleMapForASPNet1.GoogleMapObject.Points["GP3"].Latitude += 0.001;
        GoogleMapForASPNet1.GoogleMapObject.ShowTraffic = !GoogleMapForASPNet1.GoogleMapObject.ShowTraffic;
    }

}

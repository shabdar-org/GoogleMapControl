using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleMapControl
{
    public partial class MapWithRecenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
                //For samples to run properly, set GoogleAPIKey in Web.Config file.
                GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

                //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
                GoogleMapForASPNet1.GoogleMapObject.Width = "800px"; // You can also specify percentage(e.g. 80%) here
                GoogleMapForASPNet1.GoogleMapObject.Height = "400px";

                //Specify initial Zoom level.
                GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;

                //Specify Center Point for map. Map will be centered on this point.
                GooglePoint GP = new GooglePoint();  //"1", , 
                GP.Latitude = 43.67619;
                GP.Longitude = -79.45268;
                GP.ToolTip = "Center Point";
                GP.InfoHTML = "This is center point";
                //Disable Automatic Boundary and Zoom to allow positioning map to a new point.
                GoogleMapForASPNet1.GoogleMapObject.AutomaticBoundaryAndZoom = false;
                GoogleMapForASPNet1.GoogleMapObject.CenterPoint = GP;
                GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);
            }
        }
        protected void btnRecenter_Click(object sender, EventArgs e)
        {
            //Note that buttons are placed inside an Ajax UpdatePanel. This is to prevent postback of the page.
            //Recenter Map.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = GoogleMapForASPNet1.GoogleMapObject.Points[0];

            //You must set following property in order to Recenter a map.
            GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;

        }
    }
}
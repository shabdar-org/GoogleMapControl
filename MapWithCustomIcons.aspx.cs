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

public partial class Samples_SimpleMapWithCustomIcons : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
        //For samples to run properly, set GoogleAPIKey in Web.Config file.
        GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"]; 

        //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
        GoogleMapForASPNet1.GoogleMapObject.Width = "800px"; // You can also specify percentage(e.g. 80%) here
        GoogleMapForASPNet1.GoogleMapObject.Height = "600px";

        //Specify initial Zoom level.
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;

        //Specify Center Point for map. Map will be centered on this point.
        GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 43.66619, -79.44268);

        //Add push pins for map. 
        //This should be done with intialization of GooglePoint class. 
        //ID is to identify a pushpin. It must be unique for each pin. Type is string.
        //Other properties latitude and longitude.
        GooglePoint GP1 = new GooglePoint();
        GP1.ID = "1";
        GP1.Latitude = 43.65669;
        GP1.Longitude = -79.44268;
        //Specify bubble text here. You can use standard HTML tags here.
        GP1.InfoHTML = "This is Point 1";

        //Specify icon image. This should be relative to root folder.
        GP1.IconImage = "icons/pushpin-blue.png";
        
        GP1.IconShadowImage = "icons/pushpin-blue.png";

        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);

        GooglePoint GP2 = new GooglePoint();
        GP2.ID = "2";
        GP2.Latitude = 43.66619;
        GP2.Longitude = -79.44268;
        GP2.InfoHTML = "This is point 2";
        GP2.IconImage = "icons/horse.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP2);


        GooglePoint GP3 = new GooglePoint();
        GP3.ID = "3";
        GP3.Latitude = 43.67689;
        GP3.Longitude = -79.43270;
        GP3.InfoHTML = "This is point 3";
        GP3.IconImage = "icons/recycle.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP3);
        
    }
}

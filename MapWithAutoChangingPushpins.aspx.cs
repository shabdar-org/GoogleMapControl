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

public partial class MapWithAutoChangingPushpins : System.Web.UI.Page
{
    string[] sIcons = { "icons/sun.png", "icons/rain.png", "icons/snow.png", "icons/storm.png" };
    Random Rand = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
        //For samples to run properly, set GoogleAPIKey in Web.Config file.
        GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"]; 

        //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
        GoogleMapForASPNet1.GoogleMapObject.Width = "800px"; // You can also specify percentage(e.g. 80%) here
        GoogleMapForASPNet1.GoogleMapObject.Height = "600px";

        //Specify initial Zoom level.
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 5;

        //Specify Center Point for map. Map will be centered on this point.
        GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 45.52174, -73.65234);

        //Add pushpins for map. 
        //This should be done with intialization of GooglePoint class. 
        //ID is to identify a pushpin. It must be unique for each pin. Type is string.
        //Other properties latitude and longitude.
        GooglePoint GP1 = new GooglePoint();
        GP1.ID = "Toronto";
        GP1.Latitude = 43.73935;
        GP1.Longitude  =-79.36523;
        //Specify bubble text here. You can use standard HTML tags here.
        GP1.InfoHTML = "This is Pushpin 1";

        //Specify icon image. This should be relative to root folder.
        GP1.IconImage = "icons/sun.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);


        GooglePoint GP2 = new GooglePoint();
        GP2.ID = "Montreal";
        GP2.Latitude = 45.52174; //+0.001
        GP2.Longitude = -73.65234;
        GP2.InfoHTML = "This is Pushpin 2";
        GP2.IconImage = "icons/snow.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP2);


        GooglePoint GP3 = new GooglePoint();
        GP3.ID = "Halifax";
        GP3.Latitude = 44.62175;
        GP3.Longitude = -63.58886;
        GP3.InfoHTML = "This is Pushpin 3";
        GP3.IconImage = "icons/rain.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP3);
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //Get random icon from sIcon[] array and assign it to various pushpins.
        GoogleMapForASPNet1.GoogleMapObject.Points["Toronto"].IconImage = sIcons[Rand.Next(0,3)];
        GoogleMapForASPNet1.GoogleMapObject.Points["Montreal"].IconImage = sIcons[Rand.Next(0, 3)];
        GoogleMapForASPNet1.GoogleMapObject.Points["Halifax"].IconImage = sIcons[Rand.Next(0, 3)];
    }
}

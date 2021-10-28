using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleMapControl
{
    public partial class MapWithAutoMovingPushpins : System.Web.UI.Page
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
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 13;
            GoogleMapForASPNet1.GoogleMapObject.AutomaticBoundaryAndZoom = false;
            //Specify Center Point for map. Map will be centered on this point.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 43.66619, -79.44268);

            //Add pushpins for map. 
            //This should be done with intialization of GooglePoint class. 
            //ID is to identify a pushpin. It must be unique for each pin. Type is string.
            //Other properties latitude and longitude.
            GooglePoint GP1 = new GooglePoint();
            GP1.ID = "RedCar";
            GP1.Latitude = 43.65669;
            GP1.Longitude = -79.47268;  //+0.001
                                        //Specify bubble text here. You can use standard HTML tags here.
            GP1.InfoHTML = "This is Pushpin 1";

            //Specify icon image. This should be relative to root folder.
            GP1.IconImage = "icons/RedCar.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);

            GooglePoint GP2 = new GooglePoint();
            GP2.ID = "YellowCar";
            GP2.Latitude = 43.63619; //+0.001
            GP2.Longitude = -79.44268;
            GP2.InfoHTML = "This is Pushpin 2";
            GP2.IconImage = "icons/YellowCar.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP2);


            GooglePoint GP3 = new GooglePoint();
            GP3.ID = "SchoolBus";
            GP3.Latitude = 43.67689;
            GP3.Longitude = -79.43270;
            GP3.InfoHTML = "This is Pushpin 3";
            GP3.IconImage = "icons/SchoolBus.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP3);

        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            // Move Red Car. 
            //Increment longitude value to move car horizontally. 
            GoogleMapForASPNet1.GoogleMapObject.Points["RedCar"].Longitude += 0.001;

            //Increment latitude value to move car vertically. 
            GoogleMapForASPNet1.GoogleMapObject.Points["YellowCar"].Latitude += 0.001;

            //Increment latitude value and decrement longitude value to move car diagonally.
            GoogleMapForASPNet1.GoogleMapObject.Points["SchoolBus"].Latitude += 0.001;
            GoogleMapForASPNet1.GoogleMapObject.Points["SchoolBus"].Longitude -= 0.002;
        }
    }
}
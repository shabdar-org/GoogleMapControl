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

public partial class Samples_MapWithPolygons : System.Web.UI.Page
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
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 43.66675, -79.4042);
            
            //Define Points for polygon
            GooglePoint GP1 = new GooglePoint();
            GP1.ID = "GP1";
            GP1.Latitude = 43.66675;
            GP1.Longitude = -79.4042;

            GooglePoint GP2 = new GooglePoint();
            GP2.ID = "GP2";
            GP2.Latitude = 43.67072;
            GP2.Longitude = -79.38677;

            GooglePoint GP3 = new GooglePoint();
            GP3.ID = "GP3";
            GP3.Latitude = 43.66706;
            GP3.Longitude = -79.37879;

            GooglePoint GP4 = new GooglePoint();
            GP4.ID = "GP4";
            GP4.Latitude = 43.66135;
            GP4.Longitude = -79.383;

            GooglePoint GP5 = new GooglePoint();
            GP5.ID = "GP5";
            GP5.Latitude = 43.65787;
            GP5.Longitude = -79.40016;
            
            GooglePoint GP6 = new GooglePoint();
            GP6.ID = "GP6";
            GP6.Latitude = 43.66066;
            GP6.Longitude = -79.40943;

            GooglePoint GP7 = new GooglePoint();
            GP7.ID = "GP7";
            GP7.Latitude = 43.66656;
            GP7.Longitude = -79.40445;

            //Create Polygon using above points
            GooglePolygon PG1 = new GooglePolygon();
            PG1.ID = "PG1";
            //Give Hex code for line color
            PG1.FillColor = "#0000FF";
            PG1.FillOpacity = 0.4;
            PG1.StrokeColor = "#0000FF";
            PG1.StrokeOpacity = 1;
            PG1.StrokeWeight = 2;

            PG1.Points.Add(GP1);
            PG1.Points.Add(GP2);
            PG1.Points.Add(GP3);
            PG1.Points.Add(GP4);
            PG1.Points.Add(GP5);
            PG1.Points.Add(GP6);
            PG1.Points.Add(GP7);

            //Add polygon to GoogleMap object
            GoogleMapForASPNet1.GoogleMapObject.Polygons.Add(PG1);
        }
    }

    protected void btnMovePoint_Click(object sender, EventArgs e)
    {
        //Move pushpin GP3 vertically.
        //GoogleMapForASPNet1.GoogleMapObject.Points["GP3"].Latitude += 0.001;
        GoogleMapForASPNet1.GoogleMapObject.Polygons["PG1"].Points["GP1"].Latitude += 0.001;
        GoogleMapForASPNet1.GoogleMapObject.Polygons["PG1"].FillColor = "#FF0000";
        GoogleMapForASPNet1.GoogleMapObject.Polygons["PG1"].FillOpacity = 0.2;
        GoogleMapForASPNet1.GoogleMapObject.Polygons["PG1"].StrokeColor = "#FF0000";
        GoogleMapForASPNet1.GoogleMapObject.Polygons["PG1"].StrokeWeight= 3;

    }

}

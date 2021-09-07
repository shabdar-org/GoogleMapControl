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

public partial class Samples_MapWithPolyline : System.Web.UI.Page
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
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 43.66619, -79.44268);

            //Add pushpins for map.
            //This should be done with intialization of GooglePoint class. 
            //ID is to identify a pushpin. It must be unique for each pin. Type is string.
            //Other properties latitude and longitude.
            
            GooglePoint GP1 = new GooglePoint();
            GP1.ID = "GP1";
            GP1.Latitude = 43.65669;
            GP1.Longitude = -79.44268;
            GP1.InfoHTML = "This is point 1";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);

            GooglePoint GP2 = new GooglePoint();
            GP2.ID = "GP2";
            GP2.Latitude = 43.66619;
            GP2.Longitude = -79.44268;
            GP2.InfoHTML = "This is point 2";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP2);


            GooglePoint GP3 = new GooglePoint();
            GP3.ID = "GP3";
            GP3.Latitude = 43.67689;
            GP3.Longitude = -79.43270;
            GP3.InfoHTML = "This is point 3";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP3);



            //Create Polylines between points GP1, GP2 and GP3.
            GooglePolyline PL1 = new GooglePolyline();
            PL1.ID = "PL1";
            //Give Hex code for line color
            PL1.ColorCode = "#0000FF";
            //Specify width for line
            PL1.Width = 5;

            PL1.Points.Add(GP1);
            PL1.Points.Add(GP2);
            PL1.Points.Add(GP3);

            //Add polyline to GoogleMap object
            GoogleMapForASPNet1.GoogleMapObject.Polylines.Add(PL1);
        }
    }

    protected void btnMovePoint_Click(object sender, EventArgs e)
    {
        //Move pushpin GP3 vertically.
        GoogleMapForASPNet1.GoogleMapObject.Points["GP3"].Latitude -= 0.001;
    }
    protected void btnAddPoint_Click(object sender, EventArgs e)
    {

        GooglePoint GP4 = new GooglePoint();
        GP4.ID = "GP4";
        GP4.Latitude = 43.66689;
        GP4.Longitude = -79.42470;
        GP4.InfoHTML = "This is point 4";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP4);

        GoogleMapForASPNet1.GoogleMapObject.Polylines["PL1"].Points.Add(GP4);
    }
}

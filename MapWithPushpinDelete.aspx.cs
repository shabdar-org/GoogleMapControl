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

public partial class Samples_MapWithPushPinDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
            GoogleMapForASPNet1.GoogleMapObject.Width = "700px"; // You can also specify percentage(e.g. 80%) here
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
            GP1.ID = "pushpin";
            GP1.Latitude = 43.65669;
            GP1.Longitude = -79.44268;
            //Specify bubble text here. You can use standard HTML tags here.
            GP1.InfoHTML = "This is Pushpin 1";

            //Specify icon image. This should be relative to root folder.
            GP1.IconImage = "icons/pushpin-blue.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);

            GooglePoint GP2 = new GooglePoint();
            GP2.ID = "horse";
            GP2.Latitude = 43.66619;
            GP2.Longitude = -79.44268;
            GP2.InfoHTML = "This is Pushpin 2";
            GP2.IconImage = "icons/horse.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP2);

            GooglePoint GP3 = new GooglePoint();
            GP3.ID = "arrows";
            GP3.Latitude = 43.67689;
            GP3.Longitude = -79.43270;
            GP3.InfoHTML = "This is Pushpin 3";
            GP3.IconImage = "icons/recycle.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP3);

            GooglePolyline poly1 = new GooglePolyline();
            poly1.ID = "Poly1";
            poly1.Points.Add(GP1);
            poly1.Points.Add(GP2);
            poly1.Width = 3;
            GoogleMapForASPNet1.GoogleMapObject.Polylines.Add(poly1);

            GooglePolyline poly2 = new GooglePolyline();
            poly2.ID = "Poly2";
            poly2.Points.Add(GP2);
            poly2.Points.Add(GP3);
            poly2.Width = 3;
            GoogleMapForASPNet1.GoogleMapObject.Polylines.Add(poly2);

            GooglePolygon polygon1 = new GooglePolygon();
            polygon1.ID = "Polygon1";

            polygon1.Points.Add(new GooglePoint("p1",43.67689,-79.42370));
            polygon1.Points.Add(new GooglePoint("p2", 43.66689, -79.42570));
            polygon1.Points.Add(new GooglePoint("p3", 43.65789, -79.41570));

            GoogleMapForASPNet1.GoogleMapObject.Polygons.Add(polygon1);

        }
    }
    protected void btnDeleteHorse_Click(object sender, EventArgs e)
    {
        //Delete Horse pushpin
        GoogleMapForASPNet1.GoogleMapObject.Points.Remove("horse");
    }
    protected void btnDeletePushpin_Click(object sender, EventArgs e)
    {
        //Delete pushpin
        GoogleMapForASPNet1.GoogleMapObject.Points.Remove("pushpin");
    }
    protected void btnDeleteArrows_Click(object sender, EventArgs e)
    {
        //Delete pushpin
        GoogleMapForASPNet1.GoogleMapObject.Points.Remove("arrows");
    }
    protected void btnDeletePolyline1_Click(object sender, EventArgs e)
    {
        //Delete Polyline1
        GoogleMapForASPNet1.GoogleMapObject.Polylines.Remove("Poly1");
    }
    protected void btnDeletePolyline2_Click(object sender, EventArgs e)
    {
        //Delete Polyline2
        GoogleMapForASPNet1.GoogleMapObject.Polylines.Remove("Poly2");
    }

    protected void btnDeletePolygon_Click(object sender, EventArgs e)
    {
        //Delete Polyline2
        GoogleMapForASPNet1.GoogleMapObject.Polygons.Remove("Polygon1");

    }


}

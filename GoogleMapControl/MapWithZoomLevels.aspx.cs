using GoogleMapControl.GoogleMapControl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleMapControl
{
    public partial class MapWithZoomLevels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleMapForASPNet1.ZoomChanged += new GoogleMapForASPNet.ZoomChangedHandler(OnZoomChanged);
            if (!IsPostBack)
            {

                //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
                //For samples to run properly, set GoogleAPIKey in Web.Config file.
                GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

                //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
                GoogleMapForASPNet1.GoogleMapObject.Width = "700px"; // You can also specify percentage(e.g. 80%) here
                GoogleMapForASPNet1.GoogleMapObject.Height = "400px";
            }
        }
        //Add event handler for PushpinDrag event
        void OnZoomChanged(int pZoomLevel)
        {
            //pID is ID of pushpin which was moved.
            lblZoomLevel.Text = pZoomLevel.ToString();
        }
    }
}
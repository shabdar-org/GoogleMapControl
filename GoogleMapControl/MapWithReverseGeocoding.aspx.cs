using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleMapControl
{
    public partial class MapWithReverseGeocoding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 15;

            //GoogleMapForASPNet1.
        }
        protected void btnGeocode_Click(object sender, EventArgs e)
        {
            GooglePoint GP = new GooglePoint();
            GP.Latitude = cCommon.GetNumericValue(txtLatitude.Text);
            GP.Longitude = cCommon.GetNumericValue(txtLongitude.Text);

            //GeocodeAddress() function will geocode address and set Latitude and Longitude of GP(GooglePoint) to it's respected value.
            if (GP.ReverseGeocode())
            {
                //Once GP is geocoded, you can add it to google map.
                GP.InfoHTML = GP.Address;
                txtAddress.Text = GP.Address;
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
                txtAddress.Text = "Unable to reverse geocode this lat/lng";
                lblError.Text = "Unable to reverse geocode this lat/lng";
            }
        }
    }
}
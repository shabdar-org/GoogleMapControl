using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleMapControl.GoogleMapControl
{
    public partial class GoogleMapForASPNet : System.Web.UI.UserControl
    {
        public delegate void PushpinDragHandler(string pID);
        public delegate void PushpinClickedHandler(string pID);
        public delegate void MapClickedHandler(double dLatitude, double dLongitude);
        public delegate void ZoomChangedHandler(int pZoomLevel);
        public event PushpinDragHandler PushpinDrag;
        public event PushpinClickedHandler PushpinClicked;
        public event MapClickedHandler MapClicked;
        public event ZoomChangedHandler ZoomChanged;
        // The method which fires the Event

        public void OnPushpinDrag(string pID)
        {
            // Check if there are any Subscribers
            if (PushpinDrag != null)
            {
                // Call the Event
                GoogleMapObject = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
                PushpinDrag(pID);
            }
        }

        public void OnPushpinClicked(string pID)
        {
            // Check if there are any Subscribers
            if (PushpinClicked != null)
            {
                // Call the Event
                GoogleMapObject = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
                PushpinClicked(pID);
            }
        }

        public void OnMapClicked(double dLatitude, double dLongitude)
        {
            // Check if there are any Subscribers
            if (MapClicked != null)
            {
                // Call the Event
                GoogleMapObject = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
                MapClicked(dLatitude, dLongitude);
                System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"] = GoogleMapObject;
            }
        }

        public void OnZoomChanged(int pZoomLevel)
        {
            // Check if there are any Subscribers
            if (ZoomChanged != null)
            {
                // Call the Event
                GoogleMapObject = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
                ZoomChanged(pZoomLevel);
            }
        }

        #region Properties

        GoogleObject _googlemapobject = new GoogleObject();
        public GoogleObject GoogleMapObject
        {
            get { return _googlemapobject; }
            set { _googlemapobject = value; }
        }


        bool _showcontrols = false;
        public bool ShowControls
        {
            get { return _showcontrols; }
            set { _showcontrols = value; }
        }


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Session["GOOGLE_MAP_OBJECT"] = GoogleMapObject;
            }
            else
            {
                GoogleMapObject = (GoogleObject)Session["GOOGLE_MAP_OBJECT"];
                GoogleMapObject.IsPostback = true;
                if (GoogleMapObject == null)
                {
                    GoogleMapObject = new GoogleObject();
                    Session["GOOGLE_MAP_OBJECT"] = GoogleMapObject;
                }

            }

            if (hidEventName.Value == "MapClicked")
            {
                string[] sLatLng = hidEventValue.Value.Split(new char[] { ',' }, StringSplitOptions.None);
                if (sLatLng.Length > 0)
                {
                    double dLat = double.Parse(sLatLng[0]);
                    double dLng = double.Parse(sLatLng[1]);
                    //Set event name to blank string, so on next postback same event doesn't fire again.
                    hidEventName.Value = "";
                    OnMapClicked(dLat, dLng);
                }
            }
            if (hidEventName.Value == "PushpinClicked")
            {
                //Set event name to blank string, so on next postback same event doesn't fire again.
                hidEventName.Value = "";
                OnPushpinClicked(hidEventValue.Value);
            }
            if (hidEventName.Value == "PushpinDrag")
            {
                //Set event name to blank string, so on next postback same event doesn't fire again.
                hidEventName.Value = "";
                OnPushpinDrag(hidEventValue.Value);
            }
            if (hidEventName.Value == "ZoomChanged")
            {
                //Set event name to blank string, so on next postback same event doesn't fire again.
                hidEventName.Value = "";
                OnZoomChanged(int.Parse(hidEventValue.Value));
            }


            //API initialization is now moved to GoogleMapForASPNet.ascx page code.        
            /*string sScript = "<script type='text/javascript' src='https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false'></script>\n";
            sScript += "<script type='text/javascript' src='GoogleMapAPIWrapper.js'></script>\n";
            //sScript+= "<script language='javascript'> if (window.DrawGoogleMap) { DrawGoogleMap(); } </script>";
           // sScript += "<script language='javascript'>  </script>\n";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "onLoadCall", sScript);*/
        }

    }
}
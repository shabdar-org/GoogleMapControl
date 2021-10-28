using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace GoogleMapControl
{
    /// <summary>
    /// Summary description for GService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(EnableSession = true)]
        public void SetLatLon(string pID, double pLatitude, double pLongitude)
        {
            GoogleObject objGoogleNew = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
            GoogleObject objGoogleOld = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"];
            objGoogleNew.Points[pID].Latitude = pLatitude;
            objGoogleNew.Points[pID].Longitude = pLongitude;
            objGoogleOld.Points[pID].Latitude = pLatitude;
            objGoogleOld.Points[pID].Longitude = pLongitude;
        }
    [WebMethod(EnableSession = true)]
    public void SetZoom(string pID, int pZoomLevel)
    {
        GoogleObject objGoogleNew = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
        GoogleObject objGoogleOld = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"];
        objGoogleNew.ZoomLevel = pZoomLevel;
        objGoogleOld.ZoomLevel = pZoomLevel;
    }

    //This method will be used once map centering is complete. This will set RecenterMap flag to false. So next time map will not recenter automatically.
    [WebMethod(EnableSession = true)]
    public void RecenterMapComplete()
    {
        GoogleObject objGoogleNew = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
        GoogleObject objGoogleOld = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"];
        objGoogleNew.RecenterMap = false;
        objGoogleOld.RecenterMap = false;
    }

    [WebMethod(EnableSession = true)]
    public GoogleObject GetGoogleObject()
    {
        GoogleObject objGoogle = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];

        System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"] = new GoogleObject(objGoogle);
        return objGoogle;
    }


    [WebMethod(EnableSession = true)]
    public GoogleObject GetOptimizedGoogleObject()
    {
        GoogleObject objGoogleNew = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
        GoogleObject objGoogleOld = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"];
        GoogleObject objGoogle = new GoogleObject();

        if (objGoogleOld != null)
        {
            for (int i = 0; i < objGoogleNew.Points.Count; i++)
            {
                string pointStatus = "";
                GooglePoint NewPoint = objGoogleNew.Points[i];
                GooglePoint OldPoint = objGoogleOld.Points[NewPoint.ID];
                //if old point not found, means this is a new point.
                if (OldPoint == null)
                {
                    pointStatus = "N"; //New
                }
                else
                {
                    //If old point found and old not equal to new point, means it's value is changed.
                    if (!OldPoint.Equals(NewPoint))
                    {
                        pointStatus = "C"; //Changed
                    }
                    //Remove found point from old object. This is to reduce iteration in next loop.
                    objGoogleOld.Points.Remove(OldPoint.ID);
                }
                if (pointStatus != "")
                {
                    //If new point is changed, add it in list which is to be sent to client.
                    NewPoint.PointStatus = pointStatus;
                    objGoogle.Points.Add(NewPoint);
                }
            }
            //Loop through rest of old points to mark them as deleted.
            for (int i = 0; i < objGoogleOld.Points.Count; i++)
            {
                GooglePoint OldPoint = objGoogleOld.Points[i];
                OldPoint.PointStatus = "D";
                objGoogle.Points.Add(OldPoint);
            }

            //********************************************
            for (int i = 0; i < objGoogleNew.Polylines.Count; i++)
            {
                string lineStatus = "";
                GooglePolyline NewLine = objGoogleNew.Polylines[i];
                GooglePolyline OldLine = objGoogleOld.Polylines[NewLine.ID];
                //if old point not found, means this is a new point.
                if (OldLine == null)
                {
                    lineStatus = "N"; //New
                }
                else
                {
                    //If old point found and old not equal to new point, means it's value is changed.
                    if (!OldLine.Equals(NewLine))
                    {
                        lineStatus = "C"; //Changed
                    }
                    //Remove found point from old object. This is to reduce iteration in next loop.
                    objGoogleOld.Polylines.Remove(OldLine.ID);
                }
                if (lineStatus != "")
                {
                    //If new point is changed, add it in list which is to be sent to client.
                    NewLine.LineStatus = lineStatus;
                    objGoogle.Polylines.Add(NewLine);
                }
            }
            //Loop through rest of old points to mark them as deleted.
            for (int i = 0; i < objGoogleOld.Polylines.Count; i++)
            {
                GooglePolyline OldPolyline = objGoogleOld.Polylines[i];
                OldPolyline.LineStatus = "D";
                objGoogle.Polylines.Add(OldPolyline);
            }

            //********************************************
            for (int i = 0; i < objGoogleNew.Polygons.Count; i++)
            {
                string gonStatus = "";
                GooglePolygon NewGon = objGoogleNew.Polygons[i];
                GooglePolygon OldGon = objGoogleOld.Polygons[NewGon.ID];
                //if old point not found, means this is a new point.
                if (OldGon == null)
                {
                    gonStatus = "N"; //New
                }
                else
                {
                    //If old point found and old not equal to new point, means it's value is changed.
                    if (!OldGon.Equals(NewGon))
                    {
                        gonStatus = "C"; //Changed
                    }
                    //Remove found point from old object. This is to reduce iteration in next loop.
                    objGoogleOld.Polygons.Remove(OldGon.ID);
                }
                if (gonStatus != "")
                {
                    //If new point is changed, add it in list which is to be sent to client.
                    NewGon.Status = gonStatus;
                    objGoogle.Polygons.Add(NewGon);
                }
            }
            //Loop through rest of old points to mark them as deleted.
            for (int i = 0; i < objGoogleOld.Polygons.Count; i++)
            {
                GooglePolygon OldPolygon = objGoogleOld.Polygons[i];
                OldPolygon.Status = "D";
                objGoogle.Polygons.Add(OldPolygon);
            }
        }

        objGoogle.CenterPoint = objGoogleNew.CenterPoint;
        objGoogle.ZoomLevel = objGoogleNew.ZoomLevel;
        objGoogle.ShowTraffic = objGoogleNew.ShowTraffic;
        objGoogle.RecenterMap = objGoogleNew.RecenterMap;
        objGoogle.MapType = objGoogleNew.MapType;
        objGoogle.AutomaticBoundaryAndZoom = objGoogleNew.AutomaticBoundaryAndZoom;
        //Save new Google object state in session variable.
        //System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"] = objGoogleNew;
        System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"] = new GoogleObject(objGoogleNew);

        return objGoogle;

    }

    }
}

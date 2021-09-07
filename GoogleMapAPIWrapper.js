// JScript File
var markers = new fMarkers();
var polylines = new fPolylines();
var polygons = new fPolygons();
var map;
var trafficInfo = null;
var gdir;
//var geocoder = null;
var addressMarker;
var returned_result = null;
var infowindow = null;
var directionDisplay;
var directionsService;


function MapClickFunction(position) {
    if (position) {
        //Pass latitude longitude values as comma separated
        RaiseEvent('MapClicked', position.latLng.lat() + "," + position.latLng.lng());
        //__doPostBack(null, null);
    }
}

function PolylineClickFunction(latlng) {
    if (latlng) {
        //Pass latitude longitude values as comma separated
        //RaiseEvent('MapClicked', latlng.lat() + "," + latlng.lng());
        alert("Polyline clicked at " + latlng.lat() + "," + latlng.lng());
    }
}

function ZoomChangeFunction(overlay, latlng) {
    //alert(map.getZoom());
    RaiseEvent('ZoomChanged', map.getZoom());
}

function fGetGoogleObject(result, userContext) {
    returned_result = result;
    if (!result.IsPostback) {
        map.setCenter(new google.maps.LatLng(result.CenterPoint.Latitude, result.CenterPoint.Longitude));
        map.setZoom(result.ZoomLevel);
        google.maps.event.addListener(map, "click", MapClickFunction);
        google.maps.event.addListener(map, "zoom_changed", ZoomChangeFunction);
    }
    else {

        if (result.RecenterMap) {
            map.setCenter(new google.maps.LatLng(result.CenterPoint.Latitude, result.CenterPoint.Longitude));
            GService.RecenterMapComplete();
        }

        

        if (result.ShowTraffic) {
            trafficInfo = new google.maps.TrafficLayer();
            trafficInfo.setMap(map);
        }
        else {
            if (trafficInfo != null) {

                trafficInfo.setMap(null);
            }
        }
    }
    if (result.ShowMapTypesControl) {
        //**map.addControl(new google.maps.GMapTypeControl());
    }

    if (result.ShowZoomControl) {
        //** map.addControl(new GLargeMapControl());
    }


    if (result.MapType != '') {
        map.setMapTypeId(eval(result.MapType));
    }



    var i;
    if (markers == null) {
        markers = new fMarkers();
    }

    //Find markers that are deleted on postback and remove them from map
    for (i = 0; i < markers.getLength(); i++) {
        if (!CheckIfObjectExist(markers.getValue(i).value, result.Points)) {
            markers.getValue(i).setMap(null);
            markers.removeValueById(markers.getValue(i).value);
            i--;
        }
    }

    for (i = 0; i < result.Points.length; i++) {
        var myIcon_google;

        var myPoint = new google.maps.LatLng(result.Points[i].Latitude, result.Points[i].Longitude);

        myIcon_google = null;
        if (result.Points[i].IconImage != '') {
            myIcon_google = new Object();
            markerOptions = { icon: myIcon_google };
            myIcon_google.image = result.Points[i].IconImage;
            myIcon_google.shadow = result.Points[i].IconShadowImage;
            myIcon_google.size = new google.maps.Size(result.Points[i].IconImageWidth, result.Points[i].IconImageHeight);
        }

        var marker;

        //Find marker if it already exist
        marker = markers.getValueById(result.Points[i].ID);

        if (marker == null) {
            marker = CreateMarker(result.Points[i].ID, myPoint, myIcon_google, result.Points[i].InfoHTML, result.Points[i].Draggable, result.Points[i].ToolTip);
            marker.value = result.Points[i].ID;
            markers.pushValue(marker);
            google.maps.event.addListener(markers.getLastValue(), "click", function () {
                OpenInfoWindow(markers.getLastValue(), result.Points[i].InfoHTML);
                RaiseEvent('PushpinClicked', this.value);
            });
            google.maps.event.addListener(markers.getLastValue(), "dragend", function () { GService.SetLatLon(this.value, this.position.lat(), this.position.lng()); RaiseEvent('PushpinDrag', this.value); });

        }
        else {
            ChangeMarker(marker, myPoint, myIcon_google, result.Points[i].InfoHTML, result.Points[i].Draggable, result.Points[i].ToolTip);
        }
        //map.addOverlay(markers.getLastValue());

    }

    //Add polylines
    // alert('adding polyline');

    if (polylines == null) {
        polylines = new fPolylines();
    }


    //Find polylines that are deleted on postback and remove them from map
    for (i = 0; i < polylines.getLength(); i++) {
        if (!CheckIfObjectExist(polylines.getValue(i).value, result.Polylines)) {
            polylines.getValue(i).setMap(null);
            polylines.removeValueById(polylines.getValue(i).value);
            i--;
        }
    }


    for (i = 0; i < result.Polylines.length; i++) {
        var polypoints = new Array();
        var j;
        for (j = 0; j < result.Polylines[i].Points.length; j++) {
            polypoints.push(new google.maps.LatLng(result.Polylines[i].Points[j].Latitude, result.Polylines[i].Points[j].Longitude));
        }

        var polyline;
        polyline = polylines.getValueById(result.Polylines[i].ID);

        if (polyline == null) {
            polyline = CreatePolyline(polypoints, result.Polylines[i].ColorCode, result.Polylines[i].Width, result.Polylines[i].Geodesic);
            polyline.value = result.Polylines[i].ID;
            polylines.pushValue(polyline, result.Polylines[i].ID);
        }
        else {
            polyline.setPath(polypoints);
            polyline.setOptions({
                path: polypoints,
                strokeColor: result.Polylines[i].ColorCode,
                strokeOpacity: 1.0,
                strokeWeight: result.Polylines[i].Width
            });
        }

    }

    if (polygons == null) {
        polygons = new fPolygons();
    }

    //Find polygons that are deleted on postback and remove them from map
    for (i = 0; i < polygons.getLength(); i++) {
        if (!CheckIfObjectExist(polygons.getValue(i).value, result.Polygons)) {
            polygons.getValue(i).setMap(null);
            polygons.removeValueById(polygons.getValue(i).value);
            i--;
        }
    }


    for (i = 0; i < result.Polygons.length; i++) {
        var polypoints = new Array();
        var j;
        for (j = 0; j < result.Polygons[i].Points.length; j++) {
            polypoints.push(new google.maps.LatLng(result.Polygons[i].Points[j].Latitude, result.Polygons[i].Points[j].Longitude));
        }
        var polygon;
        polygon = polygons.getValueById(result.Polygons[i].ID);

        if (polygon == null) {
            polygon = CreatePolygon(polypoints, result.Polygons[i].StrokeColor, result.Polygons[i].StrokeWeight, result.Polygons[i].StrokeOpacity, result.Polygons[i].FillColor, result.Polygons[i].FillOpacity);
            polygon.value = result.Polygons[i].ID;
            polygons.pushValue(polygon, result.Polygons[i].ID);
        }
        else {
            polygon.setPath(polypoints);
            polygon.setOptions({
                paths: polypoints,
                strokeColor: result.Polygons[i].StrokeColor,
                strokeOpacity: result.Polygons[i].StrokeOpacity,
                strokeWeight: result.Polygons[i].StrokeWeight,
                fillColor: result.Polygons[i].FillColor,
                fillOpacity: result.Polygons[i].FillOpacity
            });
        }
    }


    if (result.ShowTraffic) {
        trafficInfo = new google.maps.TrafficLayer();
        trafficInfo.setMap(map);
    }
    if (result.AutomaticBoundaryAndZoom) {
        RecenterAndZoom(true, result);
    }

    //Direction: if the ShowDirection is true then load the listeners and call the Direction API
    if (result.Directions.Addresses.length > 1) {

        if (directionsService == null) {
            directionsService = new google.maps.DirectionsService();
        }

        var renderOptions = {
            suppressMarkers: result.Directions.HideMarkers,
            polylineOptions: { 
                strokeColor: result.Directions.PolylineColor,
                strokeOpacity: result.Directions.PolylineOpacity,
                strokeWeight: result.Directions.PolylineWeight
            }
        };

        if (directionDisplay != null) {
            directionDisplay.setMap(null);
        }
        directionDisplay = new google.maps.DirectionsRenderer(renderOptions); 
        //set the directions display service to the map
        directionDisplay.setMap(map);
        //set the directions display panel
        //panel is usually just and empty div.  
        //This is where the turn by turn directions appear.

        if (result.Directions.ShowDirectionInstructions) {
            //Direction
            //gdir = new GDirections(map, document.getElementById("directions_canvas"));
            document.getElementById("directions_canvas").innerHTML = "";
            directionDisplay.setPanel(document.getElementById("directions_canvas"));
        }
        else {
            document.getElementById("directions_canvas").innerHTML = "";
        }

        //GEvent.addListener(gdir, "load", onGDirectionsLoad);
        //GEvent.addListener(gdir, "error", onGDirectionsErrors);
        //gdir.load("from: " + result.Directions.Addresses[0] + " to: " + result.Directions.Addresses[1], { "locale": result.Directions.Locale });

        var waypoints = [];
        var from_address;
        var to_address;
        from_address = result.Directions.Addresses[0];
        to_address = result.Directions.Addresses[result.Directions.Addresses.length - 1];
        for (var m = 1; m < result.Directions.Addresses.length - 1; m++) {
            address = result.Directions.Addresses[m];
            if (address !== "") {
                waypoints.push({ location: address, stopover: true });
            }
        }

        var request = {
            origin: from_address,
            destination: to_address,
            waypoints: waypoints, //an array of waypoints
            optimizeWaypoints: true, //set to true if you want google to determine the shortest route or false to use the order specified.
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };

        //get the route from the directions service
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {

                directionDisplay.setDirections(response);

            }
            else {
                //handle error
            }
        });
    }
}



function DrawGoogleMap() {
    var mylatlng = new google.maps.LatLng(42, -87);
    var myOptions = {
        zoom: 4,
        center: mylatlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    map = new google.maps.Map(document.getElementById("GoogleMap_Div"), myOptions);
    infowindow = new google.maps.InfoWindow();

    /*
    directionsDisplay = new google.maps.DirectionsRenderer();
    var chicago = new google.maps.LatLng(41.850033, -87.6500523);
    directionsDisplay.setMap(map);
    var start = "new york, ny";
    var end = "toronto, on";
    var request = {
        origin: start,
        destination: end,
        travelMode: google.maps.TravelMode.DRIVING
    };
    directionsService.route(request, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
        }
    });*/

    GService.GetGoogleObject(fGetGoogleObject);
}



//This function causes Recentering of map. It finds all visible markers on map and decides center point and zoom level based on these markers.
function RecenterAndZoom(bRecenter, result) {
    if (bRecenter) {
        //Check if there is any visible pushpin on map.
        var cnt = 0;
        bounds = new google.maps.LatLngBounds();
        for (i = 0; i < markers.getLength(); i++) {
            if (markers.markers[i].getVisible()) {
                bounds.extend(markers.markers[i].getPosition());
                //Increment visible pushpin count
                cnt++;
            }
        }
        //var iZoomLevel = map.getBoundsZoomLevel(bounds);
        //var point = bounds.getCenter();

        //if(iZoomLevel>14)
        // {
        //     iZoomLevel = 14;
        // }

        if (!AreMarkersWithinMapBounds()) {
            //map.setZoom(iZoomLevel);
            if (cnt > 0) {
                map.fitBounds(bounds);
                //map.panToBounds(bounds);
                //map.setZoom(map.getZoom() + 1);
            }
            //map.setCenter(point);
        }
    }
}

function AreMarkersWithinMapBounds() {
    var map_bounds = map.getBounds();
    //for ( var i = 0; i<map_bounds.length; ++i)
    if (map_bounds) {

        for (var j = 0; j < markers.markers.length; ++j) {
            var lat = markers.markers[j].getPosition().lat();
            var lng = markers.markers[j].getPosition().lng();
            if (lat > map_bounds.getSouthWest().lat() && lat < map_bounds.getNorthEast().lat() &&
            lng > map_bounds.getSouthWest().lng() && lng < map_bounds.getNorthEast().lng()) {

            }
            else {
                return false;
            }

            // marker within cell, do whatever you need to do
        }
    }
    return true;
}

function endRequestHandler(sender, args) {
    if (sender._postBackSettings.sourceElement != null) {
        var element_id = sender._postBackSettings.sourceElement.id;
        if (element_id.indexOf("UpdatePanelXXXYYY") == -1) {
            //Above condition is to prevent loop with Directions.
            GService.GetGoogleObject(fGetGoogleObject);
        }
    }
    else {
        //following is useful when sourceElement is null and postback is caused by MapClick, pushpin drag etc.
        GService.GetGoogleObject(fGetGoogleObject);
    }
}

function pageLoad() {
    if (!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack())
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
}

function IgnoreZeroLatLongs(bIgnore) {
    //Check if there is any visible pushpin on map.
    var cnt = 0;
    bounds = new GLatLngBounds();
    for (var i = 0; i < markers.getLength(); i++) {
        var ignoremarker = false;
        var point1 = markers.markers[i].getPoint();
        if (bIgnore) {
            if ((point1.x == 0) && (point1.y == 0)) {
                ignoremarker = true;
            }
        }
        if (!ignoremarker) {
            if (!markers.markers[i].isHidden()) {
                bounds.extend(markers.markers[i].getPoint());
                //Increment visible pushpin count
                cnt++;
            }
        }

    }
    var iZoomLevel = map.getBoundsZoomLevel(bounds);
    var point = bounds.getCenter();

    map.setZoom(iZoomLevel);
    map.setCenter(point);

}

function CheckIfObjectExist(pID, pArrayObject) {
    for (var i = 0; i < pArrayObject.length; i++) {
        if (pID == pArrayObject[i].ID) {
            return true;
        }
    }
    return false;
}

function ShowFullScreenMap() {

    var objButton = document.getElementById('btnFullScreen');
    if (objButton.value == 'Full Screen') {
        var objMap = document.getElementById('GoogleMap_Div');
        var objDiv = document.getElementById('GoogleMap_Div_Container');
        objMap.style.width = '100%';
        objMap.style.height = '100%';

        objDiv.style.position = 'absolute';
        objDiv.style.left = '0px';
        objDiv.style.top = '0px';
        objDiv.style.width = '99%';
        objDiv.style.height = '95%';
        objDiv.style.backgroundColor = 'LightGrey';

        objButton.value = 'Close Fullscreen';
        DrawGoogleMap();
    }
    else {
        var objMap = document.getElementById('GoogleMap_Div');
        var objDiv = document.getElementById('GoogleMap_Div_Container');
        objMap.style.width = '<%=GoogleMapObject.Width %>';
        objMap.style.height = '<%=GoogleMapObject.Height %>';

        objDiv.style.position = '';
        objDiv.style.left = '';
        objDiv.style.top = '';
        objDiv.style.width = '';
        objDiv.style.height = '';

        objButton.value = 'Full Screen';
        //DrawGoogleMap();
    }
}


//function fListeners()
//{
//    this.listeners = new Array();
//    this.getLength = function() { return this.listeners.length; };
//    this.pushValue = function(v) { this.listeners.push(v); }
//    this.getValue = function(i)  { return this.listeners[i]; }
//}
function fMarkers() {
    this.markers = new Array();
    this.getLength = function () { return this.markers.length; };
    this.pushValue = function (v) { this.markers.push(v); }
    this.getValue = function (i) { return this.markers[i]; }
    this.getLastValue = function () { return this.markers[this.markers.length - 1]; }
    this.getValueById = function (ID) {
        var i;
        for (i = 0; i < this.markers.length; i++) {
            if (this.markers[i].value == ID) {
                // alert('marker found : '+this.markers[i].value);
                return this.markers[i];
            }
        }
        return null;
    }
    this.removeValueById = function (ID) {
        var i;
        for (i = 0; i < this.markers.length; i++) {
            if (this.markers[i].value == ID) {
                // alert('marker found : '+this.markers[i].value);
                this.markers.splice(i, 1);
                //alert('changed marker removed');

            }
        }
        return null;
    }
}

function fPolylines() {
    this.polylines = new Array();
    this.polylinesID = new Array();
    this.getLength = function () { return this.polylines.length; };
    this.pushValue = function (v, ID) { this.polylines.push(v); this.polylinesID.push(ID); }
    this.getValue = function (i) { return this.polylines[i]; }
    this.getLastValue = function () { return this.polylines[this.polylines.length - 1]; }
    this.getValueById = function (ID) {
        var i;
        for (i = 0; i < this.polylinesID.length; i++) {
            if (this.polylinesID[i] == ID) {
                // alert('polyline found : '+this.polylines[i].value);
                return this.polylines[i];
            }
        }
        return null;
    }
    this.removeValueById = function (ID) {
        var i;
        for (i = 0; i < this.polylinesID.length; i++) {
            if (this.polylinesID[i] == ID) {
                this.polylines.splice(i, 1);
                this.polylinesID.splice(i, 1);
            }
        }
        return null;
    }
}

function fPolygons() {
    this.polygons = new Array();
    this.polygonsID = new Array();
    this.getLength = function () { return this.polygons.length; };
    this.pushValue = function (v, ID) { this.polygons.push(v); this.polygonsID.push(ID); }
    this.getValue = function (i) { return this.polygons[i]; }
    this.getLastValue = function () { return this.polygons[this.polygons.length - 1]; }
    this.getValueById = function (ID) {
        var i;
        for (i = 0; i < this.polygonsID.length; i++) {
            if (this.polygonsID[i] == ID) {
                return this.polygons[i];
            }
        }
        return null;
    }
    this.removeValueById = function (ID) {
        var i;
        for (i = 0; i < this.polygonsID.length; i++) {
            if (this.polygonsID[i] == ID) {
                this.polygons.splice(i, 1);
                this.polygonsID.splice(i, 1);
            }
        }
        return null;
    }
}

function CreateMarker(pID, point, icon1, InfoHTML, bDraggable, sTitle) {
    var marker;
    var icon2 = null;
    if (icon1 != null)
        icon2 = icon1.image;
    marker = new google.maps.Marker({ position: point, map: map, icon: icon2, draggable: bDraggable, title: sTitle });
    return marker;
}

function ChangeMarker(marker, point, icon1, InfoHTML, bDraggable, sTitle) {
    var icon2 = null;
    if (icon1 != null)
        icon2 = icon1.image;
    marker.setPosition(point);
    marker.setIcon(icon2);
    marker.setDraggable(bDraggable);
    marker.setTitle(sTitle);
    if (InfoHTML != '') {
        google.maps.event.addListener(marker, "click", function () { OpenInfoWindow(this, InfoHTML); RaiseEvent('PushpinClicked', this.value); });
    }
    else {
        google.maps.event.clearListeners(marker, 'click');
    }
}

function OpenInfoWindow(marker, InfoHTML) {

    //var marker = markers.getValueById(id);
    if (marker != null && InfoHTML!='') {

        infowindow.setContent(InfoHTML);

        infowindow.open(map, marker);

        //OpenInfoWindowUsingLatLng(marker.getPosition(),InfoHTML);
    }
}

function CreatePolyline(points, color, width, isgeodesic) {
    var polyline = new google.maps.Polyline({
        path: points,
        strokeColor: color,
        strokeOpacity: 1.0,
        strokeWeight: width
    });

    polyline.setMap(map); return polyline;
}

function CreatePolygon(points, strokecolor, strokeweight, strokeopacity, fillcolor, fillopacity) {
    var polygon;

    // var polygon = new GPolygon(points, strokecolor, strokeweight, strokeopacity, fillcolor, fillopacity);
    polygon = new google.maps.Polygon({
        paths: points,
        strokeColor: strokecolor,
        strokeOpacity: strokeopacity,
        strokeWeight: strokeweight,
        fillColor: fillcolor,
        fillOpacity: fillopacity
    });

    polygon.setMap(map);
    return polygon;
}

function OpenInfoWindowUsingLatLng(latlng, contentString) {
    infowindow.setContent(contentString);
    infowindow.setPosition(latlng);
    infowindow.open(map);
}
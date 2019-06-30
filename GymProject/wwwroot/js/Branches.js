//var lat, lng;

//function convertAddress(address) {
//    $.ajax({
//        url: "https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=AIzaSyBaXwNfoIKrVcAuApGr_QH9CUqyGrCCot4",
//        type: "POST",
//        success: function (res) {
//           lat = res.results[0].geometry.location.lat;
//           lng = res.results[0].geometry.location.lng;
//        }
//    });
//}

//// Initialize and add the map
//function initMap() {
//  // The location of Uluru
//  var address = {lat: lat, lng: lng};
//  // The map, centered at Uluru
//  var map = new google.maps.Map(
//  document.getElementById('map'), { zoom: 8, center: address});
//  // The marker, positioned at Uluru
//  var marker = new google.maps.Marker({ position: address, map: map});
//}
$(document).ready(function () {
    var geocoder;
    var map;
    var address = "San Diego, CA";
        debugger;
        geocoder = new google.maps.Geocoder();
        var latlng = new google.maps.LatLng(-34.397, 150.644);
        var myOptions = {
            zoom: 8,
            center: latlng,
            mapTypeControl: true,
            mapTypeControlOptions: { style: google.maps.MapTypeControlStyle.DROPDOWN_MENU },
            navigationControl: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById("map"), myOptions);
        if (geocoder) {
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (status != google.maps.GeocoderStatus.ZERO_RESULTS) {
                        map.setCenter(results[0].geometry.location);
    
                        var infowindow = new google.maps.InfoWindow(
                            {
                                content: '<b>' + address + '</b>',
                                size: new google.maps.Size(150, 50)
                            });
    
                        var marker = new google.maps.Marker({
                            position: results[0].geometry.location,
                            map: map,
                            title: address
                        });
                        google.maps.event.addListener(marker, 'click', function () {
                            infowindow.open(map, marker);
                        });
    
                    } else {
                        alert("No results found");
                    }
                } else {
                    alert("Geocode was not successful for the following reason: " + status);
                }
            });
        
    }
});

function getCurrentUrl() {
    return document.URL;
}


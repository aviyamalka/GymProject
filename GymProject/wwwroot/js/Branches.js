

    

//func getCurrentUrl() {
//    rn document.URL;
//}

$(document).ready(function () {
    var url = 'https://aaa:44353/Branches/Details/2';

    $('.fb-share-button').attr('data-href', url);

    function renderMap() {
        var geocoder;
        var address = document.getElementById("address").innerHTML;;
        var map;
        geocoder = new google.maps.Geocoder();
        var latlng = new google.maps.LatLng(-34.397, 150.644);
        var myOptions = {
            zoom: 15,
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
    }

    renderMap();
});

//window.fbAsyncInit = function () {
//    FB.init({
//        appId: 'your-app-id',
//        xfbml: true,
//        version: 'v2.3'
//    });
//};

//(function (d, s, id) {
//    var js, fjs = d.getElementsByTagName(s)[0];
//    if (d.getElementById(id)) { return; }
//    js = d.createElement(s); js.id = id;
//    js.src = "//connect.facebook.net/en_US/sdk.js";
//    fjs.parentNode.insertBefore(js, fjs);
//}(document, 'script', 'facebook-jssdk'));

//$('#fb-share-button').click(function() {
//    FB.ui({
//          method: 'feed',
//        link: 'https://stackoverflow.com/questions/26021781/testing-facebook-share-dialog-with-localhost-unable-to-resolve-object-at-url/26514593', 
//          picture: 'The picture url',
//          name: "The name who will be displayed on the post",
//          description: "The description who will be displayed"
//        }, function(response){
//            console.log(response);
//        }
//    );
//});


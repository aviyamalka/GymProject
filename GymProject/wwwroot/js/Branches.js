
////func getCurrentUrl() {
////    rn document.URL;
////}
//$(document).ready(function () {


//    console.log('pen reloaded');

//    //Based on http://bl.ocks.org/d3noob/8952219


//    var margin = { top: 20, right: 20, bottom: 80, left: 40 },
//        width = 500 - margin.left - margin.right,
//        height = 400 - margin.top - margin.bottom;

//    var x = d3.scaleBand()
//        .rangeRound([0, width])
//        .padding(0.1);//.rangeRoundBands([0, width], .05);


//    var y = d3.scaleLinear().range([height, 0]);


//    var svg = d3.select("body").append("svg")
//        .attr("width", width + margin.left + margin.right)
//        .attr("height", height + margin.top + margin.bottom)
//        .append("g")
//        .attr("transform",
//            "translate(" + margin.left + "," + margin.top + ")");

//    x.domain(barData.map(function (d) { return d.section; }));
//    y.domain([0, d3.max(barData, function (d) { return d.frequency; })]);


//    var xAxis = d3.axisBottom(x).tickFormat(function (d) {
//        return d;
//    });
//    var yAxis = d3.axisLeft(y);


//    svg.append("g")
//        .attr("class", "x axis")
//        .attr("transform", "translate(0," + height + ")")
//        .call(xAxis)
//        .selectAll("text")
//        .style("text-anchor", "end")
//        .attr("dx", "-.8em")
//        .attr("dy", "-.55em")
//        .attr("transform", "rotate(-90)");

//    svg.append("g")
//        .attr("class", "y axis")
//        .call(yAxis)
//        .append("text")
//        .attr("transform", "rotate(-90)")
//        .attr("y", 6)
//        .attr("dy", ".71em")
//        .style("text-anchor", "end")
//        .text("Value ($)");

//    //First line
//    svg.append('line')
//        .attr('class', 'bg-line')
//        //.style("stroke", "black")
//        .attr('x1', 0)
//        .attr('x2', width)
//        .attr('y1', 1)
//        .attr('y2', 1);

//    var line2Y = height * 0.25;
//    svg.append('line')
//        .attr('class', 'bg-line')
//        //.style("stroke", "black")
//        .attr('x1', 0)
//        .attr('x2', width)
//        .attr('y1', line2Y)
//        .attr('y2', line2Y);

//    var line3Y = height * 0.5;
//    svg.append('line')
//        .attr('class', 'bg-line')
//        //.style("stroke", "black")
//        .attr('x1', 0)
//        .attr('x2', width)
//        .attr('y1', line3Y)
//        .attr('y2', line3Y);

//var line4Y = height * 0.75;
//svg.append('line')
//    .attr('class', 'bg-line')
//    //.style("stroke", "black")
//    .attr('x1', 0)
//    .attr('x2', width)
//    .attr('y1', line4Y)
//    .attr('y2', line4Y);



    $(document).ready(function () {
        var url = 'https://aaa:44353/Branches/Details/2';
        $('.fb-share-button').attr('data-href', url);


    function renderMap() {
        var geocoder;
        var address = document.getElementById("address").innerHTML;
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



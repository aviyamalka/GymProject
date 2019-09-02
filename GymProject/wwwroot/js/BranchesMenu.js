$(document).ready(function () {
    debugger;
 $(".navbar").css("position", "absolute");
    $(".navbar-nav").css("display", "inline-block");
    $(".navbar").css("paddiing","0rem 0rem");
    var salesData = [
        { label: "Basic", color: "#03fccf" },
        { label: "Plus", color: "#52c3f7" },
        { label: "Lite", color: "#2042b3" },
        { label: "Elite", color: "#4fa3c9" },
        { label: "Delux", color: "#16175c" }
    ];

    var svg = d3.select("body").append("svg").attr("width", 700).attr("height", 300);

    svg.append("g").attr("id", "salesDonut");
    Donut3D.draw("salesDonut", getData(), 150, 150, 130, 100, 30, 0.4);
   
    function changeData() {
        Donut3D.transition("salesDonut", getData(), 130, 100, 30, 0.4);
    }

    function getData() {
        debugger;
        var res = DbConnection.GetAllLessonsGroupByBranch();
        var lessonsArr = [];
        for (var i = 0; i < res.length; i++)  
        {
            var x = { "label": res[i].name, "value": res[i].count, "color": salesData[i].color };
            lessonsArr.push(x);
        }
        return lessonsArr;
    }
});
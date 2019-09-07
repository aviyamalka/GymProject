$(document).ready(function () {
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

    
    var elements = document.querySelectorAll("#citySelect, #time");
    searchButton = document.querySelector('#searchBtn')
    searchButton.disabled = true
    $("#searchBtnLabel").css('background-color', 'pink');

    for (i = 0; i < elements.length; i++) {
        elements[i].addEventListener('change', () => {
            let values = []
            elements.forEach(v => values.push(v.value))
            if (values.includes('') || values.includes('-עיר-')) {
                searchButton.disabled = true;
                $("#searchBtnLabel").css('background-color', 'pink');
            } else {
                searchButton.disabled = false;
                $("#searchBtnLabel").css('background-color', '#d43f3a');
            }
        })
    }
    

    var svg = d3.select("body").append("svg").attr("width", 700).attr("height", 300);

    svg.append("g").attr("id", "salesDonut");
    Donut3D.draw("salesDonut", getData(), 150, 150, 130, 100, 30, 0.4);
   
    function changeData() {
        Donut3D.transition("salesDonut", getData(), 130, 100, 30, 0.4);
    }

    function getData() {
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

function searchBranch() {
    debugger;
    selectedIsBabySitter = $("#babysitterSelect").val();
    selectedCity = $("#citySelect").val();
    selctedTime = $("#time").val();

    $('.card ').each(function (i, obj) {
        if ($(obj).find("#babysitter").html() != selectedIsBabySitter || $(obj).find("#city").html() != selectedCity ||
            !(selctedTime > $(obj).find("#openHour").html() && selctedTime < $(obj).find("#closeHour").html())) {
            $(obj).css('display', 'none');
        }
    });

}
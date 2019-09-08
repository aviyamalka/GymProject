$(document).ready(function () {
    function addZeroInDateTimeFormat() {

    }

    debugger;
    var elements = document.querySelectorAll("#selectedCity, #selectedDate");
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

    function IsLessonEnabled() {
        $(".regRow").each(function (i, row) {
            var $row = $(row),
                $maxReg = $row.find('p[name*="max"]'),
                $numReg = $row.find('p[name*="num"]'),
                $editReg = $row.find('a[name*="edit"]'),
                $detailsReg = $row.find('a[name*="details"]'),
                $deleteReg = $row.find('a[name*="delete"]');
            if ($maxReg[0].innerText === $numReg[0].innerText) {
                $row.addClass("disaleRow");
                //$editReg.addClass("disaleLink");
                $detailsReg.addClass("disaleLink");
                //$deleteReg.addClass("disaleLink");
            }
        });
    }
    IsLessonEnabled();
    $("#searchBtn").click(function () {
        debugger;
        $("#frame").hide();
        $("#tbl").show();
    });
});

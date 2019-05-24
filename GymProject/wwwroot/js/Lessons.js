$(document).ready(function () {
    debugger;
    function addZeroInDateTimeFormat() {

    }
    function IsLessonEnabled() {
        debugger;
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
});

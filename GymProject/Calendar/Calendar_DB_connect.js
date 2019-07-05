(function (DbConnection) {
    DbConnection.getResultsFromServer = function (url, data, isAsync) {
        debugger;
        var res;
    isAsync = typeof isAsync !== 'undefined' ? isAsync : false;
    jQuery.support.cors = true;
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: isAsync,
        url: url,
        data: data,
        success: function (data, textStatus, XmlHttpRequest) {
            res = data;
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {
            res = null;
        }
        });

    return res;
    },
    DbConnection.getAllLessons = function ()
    {
        debugger;
        var url = "https://localhost:5001/Lessons/GetAllLessons";
        var data;
        var isAsync = true;
        var result = DbConnection.getResultsFromServer(url, data, isAsync);
        if (result !== null)
        {
            alert("success");
        }
    }
})(window.DbConnection = window.DbConnection || {});
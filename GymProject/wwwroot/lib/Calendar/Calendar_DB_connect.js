(function (DbConnection) {
    DbConnection.getResultsFromServer = function (url, data, isAsync) {
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
        DbConnection.getAllLessons = function () {
            var url = "https://localhost:5001/Lessons/GetAllLessons";
            var data;
            var isAsync = false;
            var result = DbConnection.getResultsFromServer(url, data, isAsync);
            if (result !== null) {
                return result;
            }
        },
        DbConnection.registerToLesson = function (UserId, LessonId) {
        var controllerURL = 'https://localhost:5001/Lessons/RegisterToLesson';
            var params = {
                UserId: UserId,
                LessonId: LessonId
            };
            $.ajax({
                type: "POST",
                url: controllerURL,
                data: params,
                contentType: "application/json; charset=utf-8",
                accepts: "application/json",
                dataType: "json",
                success: successFunc,
                error: errorFunc
        });
        function successFunc(data, status) {
            alert(data);
        }

        function errorFunc(error) {
            alert('error');
        }
        }
})(window.DbConnection = window.DbConnection || {});
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
        DbConnection.GetAllLessonsGroupByBranch = function () {
        var url = "https://localhost:5001/Lessons/GetAllLessonsGroupByBranch";
            var data;
            var isAsync = false;
            var result = DbConnection.getResultsFromServer(url, data, isAsync);
            if (result !== null) {
                return result;
            }
        },

        DbConnection.GetAllTrainingGroupByCategory = function () {
        var url = "https://localhost:44353/Trainings/GetAllTrainingGroupByCategory";
            var data;
            var isAsync = false;
            var result = DbConnection.getResultsFromServer(url, data, isAsync);
            if (result !== null) {
                return result;
            }
        }, 


        DbConnection.registerToLesson = function (UserId, LessonId) {
        var controllerURL = 'https://localhost:5001/Lessons/RegisterToLesson';
        $.ajax({
            type: "POST",
            url: controllerURL,
            data: JSON.stringify({ "UserId": UserId, "LessonId": LessonId }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc,
                error: errorFunc
        });
        function successFunc(data, status) {
            alert("ההרשמה בוצעה בהצלחה");
        }

        function errorFunc(error) {
            alert('error');
        }
        }
    DbConnection.cancelRegistration = function (UserId, LessonId) {
        var controllerURL = 'https://localhost:5001/Lessons/CancelRegistrant';
        $.ajax({
            type: "POST",
            url: controllerURL,
            data: JSON.stringify({ "UserId": UserId, "LessonId": LessonId }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
        function successFunc(data, status) {
            alert("הביטול בוצע בהצלחה");
        }

        function errorFunc(error) {
            alert('error');
        }
    }
})(window.DbConnection = window.DbConnection || {});
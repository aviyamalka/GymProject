function registerToLesson(UserId,LessonId) {
    var controllerURL = '/Controlers/LessonsControlller/';
    var params = {
        UserId
    };
    $.ajax({
        type: "POST",
        url: controllerURL,
        data: params
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert(data);
    }

    function errorFunc() {
        alert('error');
    }
}
function cancelRegistrant() {
    $ajax
}
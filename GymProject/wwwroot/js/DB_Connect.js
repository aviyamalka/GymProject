﻿var registerToLesson = new function (UserId, LessonId) {
    var controllerURL = '/Controlers/LessonsController/RegisterToLesson';
    var params = {
        UserId: UserId,
        LessonId: LessonId
    };
    $.ajax({
        type: "POST",
        url: controllerURL,
        dataType: "application/json",
        data: '{"UserId":"' + 1 + '"}',
        contentType: "application/json; charset=utf-8",
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
//function cancelRegistrant() {
//    $ajax
//}
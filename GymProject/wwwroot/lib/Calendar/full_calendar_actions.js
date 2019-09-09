$(document).ready(function () {
    $("#regisBtn").click(function () {
        debugger;
        var lessonId = $('#lessonId')[0].innerText;
        var usrName = $("#userName");
        DbConnection.registerToLesson(usrName, lessonId);
    });
    $("#cancelBtn").click(function () {
        var lessonId = $('#lessonId')[0].innerText;
        var usrName = $("#userName");
        DbConnection.cancelRegistration(usrName, lessonId);
    });
    
});
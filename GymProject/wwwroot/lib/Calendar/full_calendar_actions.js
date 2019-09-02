$(document).ready(function () {
    $("#regisBtn").click(function () {
        DbConnection.registerToLesson("547cd45e-d5fe-4fc7-9aef-ff5820468e01",13);
    });
    $("#cancelBtn").click(function () {
        DbConnection.cancelRegistration("547cd45e-d5fe-4fc7-9aef-ff5820468e01", 13);
    });
    
});
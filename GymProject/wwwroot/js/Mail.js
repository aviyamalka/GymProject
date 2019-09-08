$(document).ready(function () {
    debugger;

    $("#mailBtn").click(function () {
        debugger;
        var controllerURL = 'https://localhost:5001/Mail/SendMail';

        var email = $("#email").val();
        var name = $("#fullname").val();
        var description = $("description").val();
        //var params = {
        //    name: name,
        //    email: email

        //};
        $.ajax({
            type: "POST",
            url: controllerURL,
            dataType: "json",
            data: JSON.stringify({
                "email": email, "name": name, "description": description}),
            contentType: "application/json; charset=utf-8",
            success: successFunc,
            error: errorFunc
        });

        function successFunc(data, status) {
            alert(data);
        }

        function errorFunc(data) {
            alert('error');
        }

    });
});

var sendMail = function () {
    var controllerURL = 'Controlers/MailController/SendMail';
   
    var email = $("#email").val();
    var name = $("#fullname").val();
    var params = {
        name:name,
        email: email,
        
    };
    $.ajax({
        type: "POST",
        url: controllerURL,
        dataType: "json",
        data: params,
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

};
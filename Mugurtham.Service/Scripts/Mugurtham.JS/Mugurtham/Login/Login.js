$(document).ready(function () {

    $('#Password').keypress(function (e) {
        var key = e.which;
        if (key == 13)  // the enter key code
        {
            $('input[name = btnLogin]').click();
            return false;
        }
    });
    $("#btnLogin").click(function () {
        if ($('#LoginID').val().length == 0) {
            alert('Please enter Login ID');
            $('#LoginID').focus();
            return false;
        }
        if ($('#Password').val().length == 0) {
            alert('Please enter Password');
            $('#Password').focus();
            return false;
        }
        $("#container").mask("Signing in please wait...");
        $.post("/Home/validateLogin",
{    
    LoginID: $('#LoginID').val(),
    Password: $('#Password').val()
},
function (data, status) {
    $("#container").unmask();
    if (data.LoginStatus == '1') {
        location.reload();
        window.location = '/' + data.HomePagePath;
    }
    else if (data.LoginStatus == '2') {
        alert('In valid User');
    }
    else if (data.LoginStatus == '3') {
        alert('In valid Password');
    }
    else if (data.LoginStatus == '4') {
        alert('Your Sangam is deactivated from Mugurtham');
    }
    else if (data.LoginStatus == '5') {
        alert('Your profile is deactivated  by user sangam');
    }
}).fail(function (response) {
    alert('Error: ' + response.responseText);
    $("#container").unmask();
});

    });// Button Click

    $("#linkPublicUser").click(function () {
        $("#content").mask("Signing in please wait...");
        $.post("/Home/validateLogin",
{
    LoginID: 'publicuser',
    Password: 'publicuser'
},
function (data, status) {
    $("#content").unmask();
    if (data.LoginStatus == '1') {
        location.reload();
        window.location = data.HomePagePath;
    }
    else if (data.LoginStatus == '2') {
        alert('In valid User');
    }
    else if (data.LoginStatus == '3') {
        alert('In valid Password');
    }
    else if (data.LoginStatus == '4') {
        alert('Your Sangam is deactivated from Mugurtham');
    }
    else if (data.LoginStatus == '5') {
        alert('Your profile is deactivated  by user sangam');
    }
});

    });// Link click

});


window.onbeforeunload = function (event) {
    var message = 'Important: Please click on \'Save\' button to leave this page.';
    if (typeof event == 'undefined') {
        event = window.event;
    }
    if (event) {
        removeSessionData();
        // to prevent from loading the default confrimtation message
        //  event.returnValue = message;
    }
    //return message;
};

// This function is for global scope
$(function () {
    $("#tabLogout").click(function () {
            removeSessionData();
    });

    // Validation for Page Size on listing profiles
    //per page on all profiles list page
    ($("[ng-model=pageSize]").on('input', function () {
        if (this.value > 50) {
            this.value = 50;
            toastr.error('Please enter page size less than 50 profiles');
            return false;
        }
    }));



});
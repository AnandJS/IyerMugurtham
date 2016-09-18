
/*
This Learning controller is the global Mugurtham controller for global operations
*/


/*app.controller('Ctrl', function ($scope, $translate) {
  $scope.changeLanguage = function (key) {
    $translate.use(key);
  };*/
function displayThumbnailSlider() {
    if ($(".flexslider")[0]) {        
        $('.flexslider').flexslider({
            animation: "slide",
            controlsContainer: $(".custom-controls-container"),
            customDirectionNav: $(".custom-navigation a"),
            start: function (slider) {                
            }
        })
    }
}
var MugurthamController = angular.module('MugurthamApp').
    run(function ($rootScope) {
        $rootScope.globalProfileID = '';
        $rootScope.HomePageLink = 'ProfileID';
    }).
    controller('MugurthamController', ['$http', '$scope', '$location', '$translate',
         function ($http, $scope, $location, $translate) {

             //==================
             //HIGHLIGHT CLICKED TAB
             //==================
             $scope.setActiveTab = function (tabID) {
                 $('#navBarProfile li').removeClass('active');
                 $('#' + tabID).parent().addClass('active');
             }

             $scope.sangamName = 'Viswakarma Sangam';
             $scope.globalProfileID = '';
             // Switching Theme
             $('#ddlThemes > li').on("click", function (event) {
                 $("#stylesheet").attr({ href: $('#' + event.target.id).attr('cssurl') });
                 $("#ddlThemes > li").removeClass("active");
                 $('#' + event.target.id).parent().addClass("active");
                 //$('#aSelectStyle').html(event.target.id);
             });
             // Switching Locale
             $('#ddlLocale > li').on("click", function (event) {
                 $translate.use($('#' + event.target.id).attr('localeid'));
                 $("#ddlLocale > li").removeClass("active");
                 $('#' + event.target.id).parent().addClass("active");
             });


             /************TRANSALATE SETS ON PAGE LOAD ************************/
             $scope.changeLanguage = function (key) {
                 // Set loggedin user locale
                 $translate.use(key);
                 $("#ddlLocale > li").removeClass("active");
                 $('#' + key).parent().addClass("active");
             };
         }])


function setUserStyleLocale(themeID) {
    // Set loggedin user style
    $("#stylesheet").attr({ href: $('#' + themeID).attr('cssurl') });
    $("#ddlThemes > li").removeClass("active");
    $('#' + themeID).parent().addClass("active");
}

function NotifySuccessStatus(intStatus) {
    if (intStatus == '1') {
        toastr.success('BasicInfo created successfully');
    }
    else if (intStatus == '2') {
        toastr.success('BasicInfo updated successfully');
    }
    else if (intStatus == '3') {
        toastr.success('Career updated successfully');
    }
    else if (intStatus == '4') {
        toastr.success('Contact updated successfully');
    }
    else if (intStatus == '5') {
        toastr.success('Family updated successfully');
    }
    else if (intStatus == '6') {
        toastr.success('Horoscope updated successfully');
    }
    else if (intStatus == '7') {
        toastr.success('Location updated successfully');
    }
    else if (intStatus == '8') {
        toastr.success('Reference updated successfully');
    }
    else if (intStatus == '9') {
        toastr.success('User added successfully');
    }
    else if (intStatus == '10') {
        toastr.success('User updated successfully');
    }
    else if (intStatus == '11') {
        toastr.success('Role added successfully');
    }
    else if (intStatus == '12') {
        toastr.success('Role updated successfully');
    }
    else if (intStatus == '13') {
        toastr.success('Sangam added successfully');
    }
    else if (intStatus == '14') {
        toastr.success('Sangam updated successfully');
    }
    else if (intStatus == '15') {
        toastr.success('Interest shown on this profile successfully');
    }
    else if (intStatus == '16') {
        toastr.success('Interest removed on this profile successfully');
    }
    else if (intStatus == '17') {
        toastr.success('Profile picture updated successfully');
    }
    else if (intStatus == '18') {
        toastr.success('Profile picture deleted successfully');
    }

}
function NotifyErrorStatus(data, status) {
    toastr.error(status + ' : ' + data.Message);
}

//This method listens to open the Modal window only when loggedin first time
function landingPageCounter() {
    if (typeof (Storage) !== "undefined") {
        if (localStorage.landingFirstTimeCount) {
            localStorage.landingFirstTimeCount = Number(localStorage.landingFirstTimeCount) + 1;
        } else {
            localStorage.landingFirstTimeCount = 0;
        }
        if (Number(localStorage.landingFirstTimeCount) < 2) {
            $('#squarespaceModal').modal('show');
        }
    } else {
        toastr.error("Sorry, your browser does not support web storage...");
    }
}
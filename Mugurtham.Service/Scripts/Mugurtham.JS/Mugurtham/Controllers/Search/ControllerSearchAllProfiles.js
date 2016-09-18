/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR ALL-PROFILES PAGE ON SEARCH MODULE
==========================================================================================
*/
var ControllerSearchAllProfiles = angular.module('MugurthamApp').controller('ControllerSearchAllProfiles',
        ['$http', '$scope', '$filter', function ($http, $scope, $filter) {

            $scope.ControllerName = 'ControllerSearchAllProfiles';            
            //===================================================
            //AJAX GET REQUEST - GETTING ALL PROFILES
            //===================================================
            $scope.getAllProfiles = function () {
                if (typeof (Storage) !== "undefined") {
                    if ((!sessionStorage.getItem('AllProfiles'))) 
                        $scope.getAllProfilesfromAPI();
                    else 
                        $scope.getAllProfilesfromSession();
                }
                else 
                    $scope.getAllProfilesfromAPI();
            }

            $scope.getAllProfilesfromSession = function () {
                if ((sessionStorage.getItem('AllProfiles'))) 
                    $scope.initData(JSON.parse(sessionStorage.getItem('AllProfiles')));
            }
            $scope.getAllProfilesfromAPI = function () {
                var strGetURL = "Search/Search/getAllProfiles";
                $("#divContainer").mask("Searching profiles please wait...");
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $("#divContainer").unmask();
                initData(data);
            }).
                error(function (data, status, headers, config) {
                    $("#divContainer").unmask();
                    NotifyStatus('2');
                });
            }

            $scope.initData = function (data) {
                $scope.AllProfiles = $.parseJSON(sessionStorage.getItem('AllProfiles'));
                $scope.currentPage = 1;
                $scope.pageSize = 15;
                $scope.SearchedProfiles = ($.parseJSON(sessionStorage.getItem('AllProfiles')).ProfileBasicInfoViewCoreEntityList);
                $scope.profilePhotos = ($.parseJSON(sessionStorage.getItem('AllProfiles')).PhotoCoreEntityList);
                $scope.pageChangeHandler = function (num) {
                    setTimeout(displayThumbnailSlider, 1000);
                    console.log('Profiles page changed to ' + num);
                };
                setTimeout(displayThumbnailSlider, 1000);
            }
            $scope.setProfileIDBySangamAdminForProfilePic = function(ProfileID)
            {
                localStorage.setItem("ProfileIDBySangamAdminForProfilePic", ProfileID);
            }
        }])


function NotifyStatus(intStatus) {
    /*
         1-> Success
         2-> Error
    */
    if (intStatus == '1') {
        toastr.success('Profiles Received Successfully');
    }
    else if (intStatus == '2') {
        toastr.Error('Error occured in ControllerSearchAllProfiles - getData');
    }
}
 
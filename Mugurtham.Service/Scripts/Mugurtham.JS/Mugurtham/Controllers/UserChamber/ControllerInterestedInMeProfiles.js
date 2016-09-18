/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR DISPLAYING VIEWED PROFILES IN USER HOME PAGE
==========================================================================================
*/
var ControllerInterestedInMeProfiles = angular.module('MugurthamApp').controller('ControllerInterestedInMeProfiles',
        ['$http', '$scope', function ($http, $scope) {

            $scope.ControllerName = 'ControllerInterestedInMeProfiles';
            //===================================================
            //AJAX GET REQUEST - GETTING ALL PROFILES
            //===================================================
            $scope.getInterestedInMeProfiles = function () {
                if (typeof (Storage) !== "undefined") {
                    if ((!sessionStorage.getItem('InterestedInMeProfiles')))
                        $scope.getInterestedInMeProfilesfromAPI();
                    else
                        $scope.getInterestedInMeProfilesfromSession();
                }
                else
                    $scope.getInterestedInMeProfilesfromAPI();
            }

            $scope.getInterestedInMeProfilesfromSession = function () {
                if ((sessionStorage.getItem('InterestedInMeProfiles')))
                    $scope.initData(JSON.parse(sessionStorage.getItem('InterestedInMeProfiles')));
            }
            $scope.getInterestedInMeProfilesfromAPI = function () {
                var strGetURL = "Search/Search/getAllProfiles";
                $("#divContainer").mask("Searching profiles please wait...");
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $("#divContainer").unmask();
                $scope.initData(data);
            }).
                error(function (data, status, headers, config) {
                    $("#divContainer").unmask();
                    NotifyStatus('2');
                });
            }

            $scope.initData = function (data) {
                $scope.AllProfiles = data;
                $scope.currentPage = 1;
                $scope.pageSize = 15;
                $scope.SearchedProfiles = data.ProfileBasicInfoViewCoreEntityList;
                $scope.pageChangeHandler = function (num) {
                    setTimeout(displayThumbnailSlider, 1000);
                    console.log('Profiles page changed to ' + num);
                };
                setTimeout(displayThumbnailSlider, 1000);
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
        toastr.Error('Error occured in ControllerInterestedInMeProfiles - getData');
    }
}
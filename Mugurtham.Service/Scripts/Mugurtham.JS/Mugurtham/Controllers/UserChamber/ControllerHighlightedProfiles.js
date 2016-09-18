/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR DISPLAYING HIGHLIGHTED PROFILES USER HOME PAGE
==========================================================================================
*/
var ControllerHighlightedProfiles = angular.module('MugurthamApp').controller('ControllerHighlightedProfiles',
        ['$http', '$scope', function ($http, $scope) {
            $scope.ControllerName = 'ControllerHighlightedProfiles';


            //===================================================
            //AJAX GET REQUEST - GETTING ALL PROFILES
            //===================================================
            $scope.getHighlightedProfiles = function () {
                if (typeof (Storage) !== "undefined") {
                    if ((!sessionStorage.getItem('HiglightedProfiles')))
                        $scope.getHighlightedProfilesfromAPI();
                    else
                        $scope.getHighlightedProfilesfromSession();
                }
                else
                    $scope.getHighlightedProfilesfromAPI();
            }

            $scope.getHighlightedProfilesfromSession = function () {
                if ((sessionStorage.getItem('HiglightedProfiles')))
                    $scope.initData(JSON.parse(sessionStorage.getItem('HiglightedProfiles')));
            }
            $scope.getHighlightedProfilesfromAPI = function () {
                var strGetURL = "Search/Search/getHighlightedProfiles";
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
                $("#divContainer").unmask();
                $scope.AllProfiles = data;
                $scope.currentPage = 1;
                $scope.pageSize = 15;
                $scope.SearchedProfiles = data.ProfileBasicInfoViewCoreEntityList;
                $scope.profilePhotos = data.PhotoCoreEntityList;
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
        toastr.Error('Error occured in ControllerHighlightedProfiles - getData');
    }
}

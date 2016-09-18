/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR ALL-PROFILES PAGE ON SEARCH MODULE
==========================================================================================
*/
var ControllerSearchProfileID = angular.module('MugurthamApp').controller('ControllerSearchProfileID',
        ['$http', '$scope', '$filter', function ($http, $scope, $filter) {

            $scope.ControllerName = 'ControllerSearchProfileID';
            //===================================================
            //AJAX GET REQUEST - GET PROFILE BY PROFILEID
            //===================================================
            $scope.getByProfileID = function () {
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
                $scope.MyAllProfiles = data;
                $scope.AllProfilesSearch = data.ProfileBasicInfoViewCoreEntityList;
                $scope.AllProfiles = [];
                //angular.forEach($scope.AllProfiles, function (item) {
                //});
                if ($scope.frmData[0].ProfileID.length) {
                    $.each($scope.AllProfilesSearch, function (index, element) {
                        if ($scope.AllProfilesSearch[index].MugurthamProfileID.toLowerCase() === $scope.frmData[0].ProfileID.toLowerCase()) {
                            $scope.AllProfiles.push(element);
                            return false;
                        }
                    });
                }
                else {
                    return false;
                }
                setTimeout(displayThumbnailSlider, 1000);
            }
            $scope.hideDiv = function () {
                $('#divProfileBasicView').hide();
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
        toastr.Error('Error occured in ControllerSearchProfileID - getData');
    }
}
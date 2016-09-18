/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR DISPLAYING VIEWED PROFILES IN USER HOME PAGE
==========================================================================================
*/
var ControllerUserChamber = angular.module('MugurthamApp').controller('ControllerUserChamber',
        ['$http', '$scope', function ($http, $scope) {
            $scope.ControllerName = 'ControllerUserChamber';
            //===================================================
            //AJAX GET REQUEST - GETTING ALL PROFILES
            //===================================================
            $scope.geUserChamberBadgeCount = function () {
                if (typeof (Storage) !== "undefined") {
                    if ((!sessionStorage.getItem('UserBadgeCount')))
                        $scope.geUserChamberBadgeCountfromAPI();
                    else
                        $scope.geUserChamberBadgeCountfromSession();
                }
                else
                    $scope.geUserChamberBadgeCountfromAPI();
            }

            $scope.geUserChamberBadgeCountfromSession = function () {
                if ((sessionStorage.getItem('UserBadgeCount')))
                    setBadgeValue(JSON.parse(sessionStorage.getItem('UserBadgeCount')));
            }
            $scope.geUserChamberBadgeCountfromAPI = function () {
                var strGetURL = "User/User/getUserBadgeCount";
                $("#divContainer").mask("Searching profiles please wait...");
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $("#divContainer").unmask();
                setBadgeValue(data);
            }).
                error(function (data, status, headers, config) {
                    $("#divContainer").unmask();
                    NotifyStatus('2');
                });
            }
        }])


function setBadgeValue(objData) {

    $('#badgeInterestedInMeProfiles').text(objData.InterestedProfiles);
    $('#badgeInterestedInMeProfilesInGblNav').text(objData.InterestedProfiles);

    $('#badgeInterestedProfiles').text(objData.InterestedInMeProfiles);
    $('#badgeInterestedProfilesInGblNav').text(objData.InterestedInMeProfiles);

    $('#badgeViewNotifications').text(objData.ViewedProfiles);
    $('#badgeViewNotificationsInGblNav').text(objData.ViewedProfiles);

    $('#badgeRecentlyJoined').text(objData.RecentlyJoined);
    $('#badgeRecentlyJoinedInGblNav').text(objData.RecentlyJoined);

    $('#badgeHighlightedProfiles').text(objData.HighlightedProfiles);
    $('#badgeHighlightedProfilesInGblNav').text(objData.HighlightedProfiles);
}

function NotifyStatus(intStatus) {
    /*
         1-> Success
         2-> Error
    */
    if (intStatus == '1') {
        toastr.success('Profiles Received Successfully');
    }
    else if (intStatus == '2') {
        toastr.Error('Error occured in ControllerUserChamber - getData');
    }
}
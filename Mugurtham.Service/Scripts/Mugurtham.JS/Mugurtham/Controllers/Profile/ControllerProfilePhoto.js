/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR PHOTO PAGE ON PROFILE REGISTRATION
==========================================================================================
*/
var ControllerProfilePhoto = angular.module('MugurthamApp').controller('ControllerProfilePhoto',
        ['$http', '$scope', '$rootScope', function ($http, $scope, $rootScope) {
            //========================================
            //GLOBAL VARIABLES FOR THIS CONTROLLER
            //=========================================
            $scope.controllerName = 'ControllerProfilePhoto';
            $scope.globalProfileID = $rootScope.globalProfileID;
            //===================================================
            //AJAX GET REQUEST - GET PROFILE BY PROFILEID
            //===================================================
            $scope.getByProfileID = function () {
                if ($rootScope.globalProfileID == '') { //Uploading
                }
                else { // Viewing
                    localStorage.setItem("ProfileID", $rootScope.globalProfileID);
                }
                $rootScope.globalProfileID = localStorage.getItem("ProfileID");
                if (localStorage.getItem("ProfileIDBySangamAdminForProfilePic") === null) {
                }
                $('#ProfileID').val($rootScope.globalProfileID);
                $http({
                    method: "GET", url: '/SearchAPI/AllProfilesAPI/getByProfileID/' + $rootScope.globalProfileID
                }).
success(function (data, status, headers, config) {
    localStorage.removeItem("ProfileIDBySangamAdminForProfilePic");
    $scope.AllProfiles = data;
}).
    error(function (data, status, headers, config) {
        NotifyStatus('2');
    });
            }

            //===================================================
            //AJAX PUT REQUEST - TO UPDATE PROFILE IMAGE
            //===================================================
            $scope.updateProfileImage = function (objProfile, strImagePath) {
                $http({
                    method: "PUT", url: '/BasicInfo/BasicInfoAPI/', data: $.param({
                        ProfileID: objProfile.BasicInfoCoreEntity.ProfileID,
                        SangamID: objProfile.BasicInfoCoreEntity.SangamID,
                        Name: objProfile.BasicInfoCoreEntity.Name,
                        Age: objProfile.BasicInfoCoreEntity.Age,
                        Gender: objProfile.BasicInfoCoreEntity.Gender,
                        DOB: objProfile.BasicInfoCoreEntity.DOB,
                        TOB: objProfile.BasicInfoCoreEntity.TOB,
                        MaritalStatus: objProfile.BasicInfoCoreEntity.MaritalStatus,
                        NoOfChildren: objProfile.BasicInfoCoreEntity.NoOfChildren,
                        ChildrenLivingStatus: objProfile.BasicInfoCoreEntity.ChildrenLivingStatus,
                        Height: objProfile.BasicInfoCoreEntity.Height,
                        Weight: objProfile.BasicInfoCoreEntity.Weight,
                        BodyType: objProfile.BasicInfoCoreEntity.BodyType,
                        Complexion: objProfile.BasicInfoCoreEntity.Complexion,
                        PhysicalGroup: objProfile.BasicInfoCoreEntity.PhysicalGroup,
                        BloodGroup: objProfile.BasicInfoCoreEntity.BloodGroup,
                        MotherTongue: objProfile.BasicInfoCoreEntity.MotherTongue,
                        ProfileCreatedBy: objProfile.BasicInfoCoreEntity.ProfileCreatedBy,
                        Religion: objProfile.BasicInfoCoreEntity.Religion,
                        Caste: objProfile.BasicInfoCoreEntity.Caste,
                        SubCaste: objProfile.BasicInfoCoreEntity.SubCaste,
                        Gothram: objProfile.BasicInfoCoreEntity.Gothram,
                        Star: objProfile.BasicInfoCoreEntity.Star,
                        Raasi: objProfile.BasicInfoCoreEntity.Raasi,
                        HoroscopeMatch: objProfile.BasicInfoCoreEntity.HoroscopeMatch,
                        AnyDhosham: objProfile.BasicInfoCoreEntity.AnyDhosham,
                        Eating: objProfile.BasicInfoCoreEntity.Eating,
                        Smoking: objProfile.BasicInfoCoreEntity.Smoking,
                        Drinking: objProfile.BasicInfoCoreEntity.Drinking,
                        PhysicalStatus: objProfile.BasicInfoCoreEntity.PhysicalStatus,
                        AboutMe: objProfile.BasicInfoCoreEntity.AboutMe,
                        PartnerExpectation: objProfile.BasicInfoCoreEntity.PartnerExpectation,
                        ElanUserID: objProfile.BasicInfoCoreEntity.ElanUserID,
                        PhotoPath: strImagePath,
                        CreatedDate: objProfile.BasicInfoCoreEntity.CreatedDate
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus(17);
                flipProfilePic(strImagePath);
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }


            //===================================================
            //AJAX PUT REQUEST - TO DELETE PROFILE IMAGE
            //===================================================
            $scope.deleteProfileImage = function (strPhotoID) {
                $http({
                    method: "GET", url: '/Profile/Profile/RemoveProfilePic/' + strPhotoID
                }).
success(function (data, status, headers, config) {
    NotifySuccessStatus(18);
}).
    error(function (data, status, headers, config) {
        NotifyStatus('2');
    });
            }

        }]) // Class


// Native functions
function flipProfilePic(strImagePath) {
    $('#imgProfilePic').attr("src", strImagePath);
}




/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR ALL-PROFILES PAGE ON SEARCH MODULE
==========================================================================================
*/
var ControllerSearchGeneral = angular.module('MugurthamApp').controller('ControllerSearchGeneral',
        ['$http', '$scope', function ($http, $scope) {

            $scope.ControllerName = 'ControllerSearchGeneral';
            $('#BottomPagination').hide();
            $('#TopPagination').hide();
            $scope.SangamID = '';
            $scope.Gender = '';
            $scope.Star = '';
            $scope.arrStar = ['Anusham', 'Aswini', 'Avittam', 'Aayilyam', 'Bharani', 'Chithirai', 'Hastham', 'Karthigai', 'Kettai', 'Makam', 'Moolam', 'Mrigasheersham', 'Pooraadam', 'Pooram', 'Poorattathi', 'Poosam', 'Punarpoosam', 'Revathi', 'Rohini', 'Sadayam', 'Swaathi', 'Thiruvaathirai', 'Thiruvonam', 'Uthiraadam', 'Uthiram', 'Uthirattathi', 'Visaakam'];
            $scope.arrSubCaste = ['Kamalar', 'Achari'];
            
            //===================================================
            //AJAX GET REQUEST - GETTING LOOKUP DTO
            //===================================================
            $scope.getLookup = function () {
                var strGetURL = '/Lookup/LookupAPI';
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $scope.getAllGeneralSearchProfiles();
                $scope.arrSangamID = data.SangamCoreEntity;
                $scope.arrRoleID = data.RoleCoreEntity;
                $('#ddlSangam').empty();                
                getUserByID();
            }).
            error(function (data, status, headers, config) {
                NotifyStatus('2');
            });
            }
            //===================================================
            //AJAX GET REQUEST - GETTING ALL PROFILES
            //===================================================
            $scope.getAllGeneralSearchProfiles = function () {
                if (typeof (Storage) !== "undefined") {
                    if ((!sessionStorage.getItem('AllProfiles')))
                        $scope.getAllGeneralSearchProfilesfromAPI();
                    else
                        $scope.getAllGeneralSearchProfilesfromSession();
                }
                else
                    $scope.getAllGeneralSearchProfilesfromAPI();
            }

            $scope.getAllGeneralSearchProfilesfromSession = function () {
                if ((sessionStorage.getItem('AllProfiles')))
                    $scope.initData(JSON.parse(sessionStorage.getItem('AllProfiles')));
            }
            $scope.getAllGeneralSearchProfilesfromAPI = function () {
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
        toastr.Error('Error occured in ControllerSearchGeneral - getData');
    }
}
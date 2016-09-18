/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR SANGAM REGISTRATION
==========================================================================================
*/
var ControllerSangam = angular.module('MugurthamApp').controller('ControllerSangam',
        ['$http', '$scope', '$rootScope', '$routeParams', function ($http, $scope, $rootScope, $routeParams) {
            //========================================
            //GLOBAL VARIABLES FOR THIS CONTROLLER
            //=========================================            
            $scope.controllerName = 'ControllerSangam';
            $scope.globalProfileID = $rootScope.globalProfileID;
            $scope.globalSangamID = '';
            if (typeof $routeParams.SangamID != 'undefined') {
                $scope.globalSangamID = $routeParams.SangamID;
            }
            $scope.frmData = []; // To store the values of the controls in form
            // Form Control Variables            
            $scope.ID = '';
            $scope.Name = '';
            $scope.Address = '';
            $scope.ContactNumber = '';
            $scope.ProfileIDStartsWith = '';
            $scope.AboutSangam = '';
            $scope.LogoPath = '';
            $scope.BannerPath = '';            
            //========================================
            //GLOBAL EVENT HANDLER FOR THIS CONTROLLER
            //=========================================
            $scope.saveFormData = function () {
                $scope.initFormData();
                if ($scope.globalSangamID == '') {
                    $scope.Add();
                } else {
                    $scope.Edit();
                }
            }

            //=====================================
            //PRIVATE METHODS FOR THIS CONTROLLER
            //=====================================
            $scope.initFormData = function () {
                $scope.Name = $scope.frmData[0].Name;
                $scope.Address = $scope.frmData[0].Address;
                $scope.ContactNumber = $scope.frmData[0].ContactNumber;
                $scope.ProfileIDStartsWith = $scope.frmData[0].ProfileIDStartsWith;
                $scope.AboutSangam = $scope.frmData[0].AboutSangam;
                $scope.LogoPath = $scope.frmData[0].LogoPath;
                $scope.BannerPath = $scope.frmData[0].BannerPath;
            }

            //===================================================
            //AJAX POST REQUEST - CREATING NEW SANGAM
            //===================================================
            $scope.Add = function () {
                $http({
                    method: "post", url: '/Sangam/SangamAPI', data: $.param({
                        Name: $scope.frmData[0].Name,
                        ID: $scope.frmData[0].ID,
                        Address: $scope.frmData[0].Address,
                        ContactNumber: $scope.frmData[0].ContactNumber,
                        ProfileIDStartsWith: $scope.frmData[0].ProfileIDStartsWith,
                        AboutSangam: $scope.frmData[0].AboutSangam,
                        LogoPath: $scope.frmData[0].LogoPath,
                        BannerPath: $scope.frmData[0].BannerPath,
                        IsActivated: geSangamActivation()
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {               
                NotifySuccessStatus('13');
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }


            //===================================================
            //AJAX GET REQUEST - GETTING SANGAM BY ID
            //===================================================
            $scope.getSangamByID = function () {
                if ($scope.globalSangamID == '')
                    return;
                var strGetURL = '/Sangam/SangamAPI/' + $scope.globalSangamID;
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $scope.frmData.push({
                    ID: data.ID,
                    Name: data.Name,
                    Address: data.Address,
                    ContactNumber: data.ContactNumber,
                    ProfileIDStartsWith: data.ProfileIDStartsWith,
                    AboutSangam: data.AboutSangam,
                    LogoPath: data.LogoPath,
                    BannerPath: data.BannerPath,
                    IsActivated: setSangamActivation(data.IsActivated)
                });
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

            //===================================================
            //AJAX PUT REQUEST - EDIT SANGAM
            //===================================================
            $scope.Edit = function () {
                $http({
                    method: "PUT", url: '/Sangam/SangamAPI', data: $.param({
                        Name: $scope.frmData[0].Name,
                        ID: $scope.frmData[0].ID,
                        Address: $scope.frmData[0].Address,
                        ContactNumber: $scope.frmData[0].ContactNumber,
                        ProfileIDStartsWith: $scope.frmData[0].ProfileIDStartsWith,
                        AboutSangam: $scope.frmData[0].AboutSangam,
                        LogoPath: $scope.frmData[0].LogoPath,
                        BannerPath: $scope.frmData[0].BannerPath,
                        IsActivated: geSangamActivation()
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus('14');
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

            //===================================================
            //AJAX GET REQUEST - GET ALL SANGAMS
            //===================================================
            $scope.getAllSangams = function () {
                $("#divContainer").mask("Loading all sangams please wait...");
                $http({
                    method: "GET", url: '/SangamAPI/SangamAPI/GetAllWithoutRestrictions'
                }).
            success(function (data, status, headers, config) {
                $("#divContainer").unmask();
                $scope.AllSangams = data;
            }).
                error(function (data, status, headers, config) {
                    $("#divContainer").unmask();
                    NotifyErrorStatus(data, status);
                });
            }

        }])

function geSangamActivation() {
    var chkId = '';
    $('.sangamActivationCheckbox:checked').each(function () {
        chkId += $(this).val() + ",";
    });
    chkId = chkId.slice(0, -1);// Remove last comma        
    if (chkId == '')
        chkId = 0;
    return chkId;
}
function setSangamActivation(strActivation) {
    var arrActivation = strActivation.split(',');
    $.each(arrActivation, function (index, item) {
        $('.sangamActivationCheckbox').each(function () {
            if (item.toString().trim() == '1') {
                $(this).attr('checked', 'true');
            };
        });
    });
}




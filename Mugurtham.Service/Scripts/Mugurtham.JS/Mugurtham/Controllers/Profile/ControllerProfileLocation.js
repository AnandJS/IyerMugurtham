/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR FAMILY PAGE ON PROFILE REGISTRATION
==========================================================================================
*/
var ControllerProfileLocation = angular.module('MugurthamApp').controller('ControllerProfileLocation',
        ['$http', '$scope', '$rootScope', function ($http, $scope, $rootScope) {

            //========================================
            //GLOBAL VARIABLES FOR THIS CONTROLLER
            //=========================================
            $scope.controllerName = 'ControllerProfileLocation';
            $scope.globalProfileID = $rootScope.globalProfileID;
            $scope.frmData = []; // To store the values of the controls in form
            // Form Control Variables
            getLocationByProfileID();
            $scope.LocationID = '';
            $scope.ProfileID = '';
            $scope.CountryLivingIn = '';
            $scope.Citizenship = '';
            $scope.ResidentialStatus = '';
            $scope.ResidentState = '';
            $scope.ResidentCity = '';


            //========================================
            //GLOBAL EVENT HANDLER FOR THIS CONTROLLER
            //=========================================
            $scope.saveFormData = function () {
                $scope.initFormData();
                if ($scope.globalProfileID == '') {
                    $scope.Add();
                } else {
                    $scope.Edit();
                }
            }

            //=====================================
            //PRIVATE METHODS FOR THIS CONTROLLER
            //=====================================
            $scope.initFormData = function () {
                $scope.CountryLivingIn = $scope.frmData[0].CountryLivingIn;
                $scope.Citizenship = $scope.frmData[0].Citizenship;
                $scope.ResidentialStatus = $scope.frmData[0].ResidentialStatus;
                $scope.ResidentState = $scope.frmData[0].ResidentState;
                $scope.ResidentCity = $scope.frmData[0].ResidentCity;
            }


            //===================================================
            //AJAX POST REQUEST - CREATING NEW COTNACT FOR PROFILE
            //===================================================
            $scope.Add = function () {
                $http({
                    method: "post", url: '/Location/LocationAPI', data: $.param({
                        LocationID: $scope.LocationID,
                        ProfileId: $scope.globalProfileID,
                        CountryLivingIn: $scope.CountryLivingIn,
                        CitizenShip: $scope.Citizenship,
                        ResidentStatus: $scope.ResidentialStatus,
                        ResidingState: $scope.ResidentState,
                        ResidingCity: $scope.ResidentCity
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifyStatus('1');
            }).
            error(function (data, status, headers, config) {
                NotifyStatus('2');

            });
            }

            //===================================================
            //AJAX PUT REQUEST - EDIT FAMILY FOR PROFILE
            //===================================================
            $scope.Edit = function () {
                $http({
                    method: "PUT", url: '/Location/LocationAPI', data: $.param({
                        LocationID: $scope.LocationID,
                        ProfileId: $scope.globalProfileID,
                        CountryLivingIn: $scope.CountryLivingIn,
                        CitizenShip: $scope.Citizenship,
                        ResidentStatus: $scope.ResidentialStatus,
                        ResidingState: $scope.ResidentState,
                        ResidingCity: $scope.ResidentCity
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus('7');
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status)
            });
            }

            //===================================================
            //AJAX GET REQUEST - GETTING LOCATION BY ID
            //===================================================
            function getLocationByProfileID() {
                var strGetURL = '/Location/LocationAPI/' + $scope.globalProfileID;
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $scope.frmData.push({
                    CountryLivingIn: data.CountryLivingIn,
                    Citizenship: data.CitizenShip,
                    ResidentialStatus: data.ResidentStatus,
                    ResidentState: data.ResidingState,
                    ResidentCity: data.ResidingCity
                });
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

        }])






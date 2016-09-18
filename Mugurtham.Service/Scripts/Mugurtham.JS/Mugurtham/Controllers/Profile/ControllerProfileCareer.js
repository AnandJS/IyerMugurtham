/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR EDUCATION PAGE ON PROFILE REGISTRATION
==========================================================================================
*/
var ControllerProfileCareer = angular.module('MugurthamApp').controller('ControllerProfileCareer',
        ['$http', '$scope', '$rootScope', function ($http, $scope, $rootScope) {

            //========================================
            //GLOBAL VARIABLES FOR THIS CONTROLLER
            //=========================================
            $scope.controllerName = 'ControllerProfileCareer';
            $scope.frmData = []; // To store the values of the controls in form
            $scope.globalProfileID = $rootScope.globalProfileID;
            getCareerByProfileID();
            $scope.arrEmployedIn = ['Business', 'Defence', 'Private Job', 'Government Job', 'Self Employed'];
            // Form Control Variables
            $scope.CareerID = '';
            $scope.ProfileID = '';
            $scope.Education = '';
            $scope.EducationInDetail = '';
            $scope.EmployedIn = '';
            $scope.Occupation = '';
            $scope.OccupationInDetail = '';
            $scope.AnnualIncome = '';
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
            //====================================
            $scope.initFormData = function () {
                $scope.Education = $scope.frmData[0].Education;
                $scope.EducationInDetail = $scope.frmData[0].EducationInDetail;
                $scope.EmployedIn = $scope.frmData[0].EmployedIn;
                $scope.Occupation = $scope.frmData[0].Occupation;
                $scope.OccupationInDetail = $scope.frmData[0].OccupationInDetail;
                $scope.AnnualIncome = $scope.frmData[0].AnnualIncome;
            }

            //===================================================
            //AJAX POST REQUEST - CREATING NEW CAREER FOR PROFILE
            //===================================================
            $scope.Add = function () {
                $http({
                    method: "POST", url: '/Career/CareerAPI', data: $.param({
                        CareerID: $scope.CareerID,
                        ProfileID: $scope.globalProfileID,
                        Education: $scope.Education,
                        EducationInDetail: $scope.EducationInDetail,
                        EmployedIn: $scope.EmployedIn,
                        Occupation: $scope.Occupation,
                        OccupationInDetail: $scope.OccupationInDetail,
                        AnnualIncome: $scope.AnnualIncome
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus(3);
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

            //===================================================
            //AJAX PUT REQUEST - EDIT CAREER FOR PROFILE
            //===================================================
            $scope.Edit = function () {
                $http({
                    method: "PUT", url: '/Career/CareerAPI', data: $.param({
                        CareerID: $scope.CareerID,
                        ProfileID: $scope.globalProfileID,
                        Education: $scope.Education,
                        EducationInDetail: $scope.EducationInDetail,
                        EmployedIn: $scope.EmployedIn,
                        Occupation: $scope.Occupation,
                        OccupationInDetail: $scope.OccupationInDetail,
                        AnnualIncome: $scope.AnnualIncome
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus('3');
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

            //===================================================
            //AJAX GET REQUEST - GETTING PROFILE BY ID
            //===================================================
            function getCareerByProfileID() {
                var strGetURL = '/Career/CareerAPI/' + $scope.globalProfileID;
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $scope.frmData.push({
                    ID: data.ID,
                    Education: data.Education,
                    EducationInDetail: data.EducationInDetail,
                    EmployedIn: data.EmployedIn,
                    Occupation: data.Occupation,
                    OccupationInDetail: data.OccupationInDetail,
                    AnnualIncome: data.AnnualIncome
                });
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }
        }])





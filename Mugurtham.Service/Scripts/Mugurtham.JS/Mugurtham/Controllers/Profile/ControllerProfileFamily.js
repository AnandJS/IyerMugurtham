/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR FAMILY PAGE ON PROFILE REGISTRATION
==========================================================================================
*/
var ControllerProfileFamily = angular.module('MugurthamApp').controller('ControllerProfileFamily',
        ['$http', '$scope', '$rootScope', function ($http, $scope, $rootScope) {

            //========================================
            //GLOBAL VARIABLES FOR THIS CONTROLLER
            //=========================================
            $scope.controllerName = 'ControllerProfileFamily';
            $scope.frmData = []; // To store the values of the controls in form
            $scope.globalProfileID = $rootScope.globalProfileID;
            $scope.arrFamilyValue = ['Traditional', 'Liberal', 'Orthodox', 'Moderate'];
            $scope.arrFamilyType = ['Joint Family', 'Other', 'Nuclear Family'];
            $scope.arrFamilyStatus = ['Middle Class Family', 'Rich', 'Upper Middle Class Family', 'Affluent'];
            $scope.arrSiblings = ['0', '1', '2', '3','4','5','6'];
            // Form Control Variables
            getFamilyByProfileID();
            $scope.FamilyID = '';
            $scope.ProfileID = '';
            $scope.Familyvalue = '';
            $scope.FamilyType = '';
            $scope.FamilyStatus = '';
            $scope.FathersName = '';
            $scope.MothersName = '';
            $scope.FathersOccupation = '';
            $scope.MothersOccupation = '';
            $scope.FamilyOrigin = '';
            $scope.NoOfBrothers = '';
            $scope.MarriedBrothers = '';
            $scope.NoOfSisters = '';
            $scope.MarriedSisters = '';
            $scope.AboutFamily = '';

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
                $scope.Familyvalue = $scope.frmData[0].Familyvalue;
                $scope.FamilyType = $scope.frmData[0].FamilyType;
                $scope.FamilyStatus = $scope.frmData[0].FamilyStatus;
                $scope.FathersName = $scope.frmData[0].FathersName;
                $scope.MothersName = $scope.frmData[0].MothersName;
                $scope.FathersOccupation = $scope.frmData[0].FathersOccupation;
                $scope.MothersOccupation = $scope.frmData[0].MothersOccupation;
                $scope.FamilyOrigin = $scope.frmData[0].FamilyOrigin;
                $scope.NoOfBrothers = $scope.frmData[0].NoOfBrothers;
                $scope.MarriedBrothers = $scope.frmData[0].MarriedBrothers;
                $scope.NoOfSisters = $scope.frmData[0].NoOfSisters;
                $scope.MarriedSisters = $scope.frmData[0].MarriedSisters;
                $scope.AboutFamily = $scope.frmData[0].AboutFamily;
            }

            //===================================================
            //AJAX POST REQUEST - CREATING NEW FAMILY FOR PROFILE
            //===================================================
            $scope.Add = function () {
                $http({
                    method: "post", url: '/Family/FamilyAPI', data: $.param({
                        ProfileID: $scope.globalProfileID,
                        NoOfBrothers: $scope.NoOfBrothers,
                        MarriedBrothers: $scope.MarriedBrothers,
                        NoOfSisters: $scope.NoOfSisters,
                        MarriedSisters: $scope.MarriedSisters,
                        FamilyValue: $scope.Familyvalue,
                        FamilType: $scope.FamilyType,
                        FamilyStatus: $scope.FamilyStatus,
                        FathersName: $scope.FathersName,
                        Mothersname: $scope.MothersName,
                        FathersOccupation: $scope.FathersOccupation,
                        MothersOccupation: $scope.MothersOccupation,
                        FamilyOrigin: $scope.FamilyOrigin,
                        AboutFamily: $scope.AboutFamily
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
                    method: "PUT", url: '/Family/FamilyAPI', data: $.param({
                        ProfileID: $scope.globalProfileID,
                        NoOfBrothers: $scope.NoOfBrothers,
                        MarriedBrothers: $scope.MarriedBrothers,
                        NoOfSisters: $scope.NoOfSisters,
                        MarriedSisters: $scope.MarriedSisters,
                        FamilyValue: $scope.Familyvalue,
                        FamilType: $scope.FamilyType,
                        FamilyStatus: $scope.FamilyStatus,
                        FathersName: $scope.FathersName,
                        Mothersname: $scope.MothersName,
                        FathersOccupation: $scope.FathersOccupation,
                        MothersOccupation: $scope.MothersOccupation,
                        FamilyOrigin: $scope.FamilyOrigin,
                        AboutFamily: $scope.AboutFamily
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus('5');
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

            //===================================================
            //AJAX GET REQUEST - GETTING PROFILE BY ID
            //===================================================
            function getFamilyByProfileID() {
                var strGetURL = '/Family/FamilyAPI/' + $scope.globalProfileID;
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $scope.frmData.push({
                    ProfileID: data.ProfileID,
                    NoOfBrothers: data.NoOfBrothers,
                    MarriedBrothers: data.MarriedBrothers,
                    NoOfSisters: data.NoOfSisters,
                    MarriedSisters: data.MarriedSisters,
                    Familyvalue: data.FamilyValue,
                    FamilyType: data.FamilType,
                    FamilyStatus: data.FamilyStatus,
                    FathersName: data.FathersName,
                    MothersName: data.Mothersname,
                    FathersOccupation: data.FathersOccupation,
                    MothersOccupation: data.MothersOccupation,
                    FamilyOrigin: data.FamilyOrigin,
                    AboutFamily: data.AboutFamily
                });
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }
        }])





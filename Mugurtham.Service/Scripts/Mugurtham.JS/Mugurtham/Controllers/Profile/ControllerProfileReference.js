/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR FAMILY PAGE ON PROFILE REGISTRATION
==========================================================================================
*/
var ControllerProfileReference = angular.module('MugurthamApp').controller('ControllerProfileReference',
        ['$http', '$scope', '$rootScope', function ($http, $scope, $rootScope) {
            //========================================
            //GLOBAL VARIABLES FOR THIS CONTROLLER
            //=========================================
            $scope.controllerName = 'ControllerProfileReference';
            $scope.globalProfileID = $rootScope.globalProfileID;
            $scope.frmData = []; // To store the values of the controls in form
            // Form Control Variables
            getReferenceByProfileID();
            $scope.ReferenceID = '';
            $scope.ProfileID = '';
            $scope.NomineeName = '';
            $scope.ContactNumber = '';

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
                $scope.NomineeName = $scope.frmData[0].NomineeName;
                $scope.ContactNumber = $scope.frmData[0].ContactNumber;
            }

            //===================================================
            //AJAX POST REQUEST - CREATING NEW COTNACT FOR PROFILE
            //===================================================
            $scope.postData = function () {
                $http({
                    method: "post", url: '/Reference/ReferenceAPI', data: $.param({
                        ReferenceID: $scope.ReferenceID,
                        ProfileID: $scope.globalProfileID,
                        NomineeName: $scope.frmData[0].NomineeName,
                        ContactNo: $scope.frmData[0].ContactNumber
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
            //AJAX GET REQUEST - GETTING LOCATION BY ID
            //===================================================
            function getReferenceByProfileID() {
                var strGetURL = '/Reference/ReferenceAPI/' + $scope.globalProfileID;
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $scope.frmData.push({
                    NomineeName: data.NomineeName,
                    ContactNumber: data.ContactNo
                });
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

            //===================================================
            //AJAX PUT REQUEST - EDIT FAMILY FOR PROFILE
            //===================================================
            $scope.Edit = function () {
                $http({
                    method: "PUT", url: '/Reference/ReferenceAPI', data: $.param({
                        ReferenceID: $scope.ReferenceID,
                        ProfileID: $scope.globalProfileID,
                        NomineeName: $scope.frmData[0].NomineeName,
                        ContactNo: $scope.frmData[0].ContactNumber
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus('8');
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

        }])
function NotifyStatus(intStatus) {
    /*
         1-> Success
         2-> Error
    */
    if (intStatus == '1') {
        toastr.success('Reference updated Successfully');
    }
    else if (intStatus == '2') {
        toastr.error(' Error occured in ControllerProfileReference - postData');
    }
}




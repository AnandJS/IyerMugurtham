/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR ROLE REGISTRATION
==========================================================================================
*/

var ControllerRole = angular.module('MugurthamApp').controller('ControllerRole',
        ['$http', '$scope', '$rootScope', '$routeParams', function ($http, $scope, $rootScope, $routeParams) {
            //========================================
            //GLOBAL VARIABLES FOR THIS CONTROLLER
            //=========================================            
            $scope.controllerName = 'ControllerRole';
            $scope.globalProfileID = $rootScope.globalProfileID;
            $scope.globalRoleID = '';
            if (typeof $routeParams.RoleID != 'undefined') {
                $scope.globalRoleID = $routeParams.RoleID;
            }
            $scope.frmData = []; // To store the values of the controls in form
            // Form Control Variables            
            $scope.ID = '';
            $scope.Name = '';            
            $scope.Description = '';
            //========================================
            //GLOBAL EVENT HANDLER FOR THIS CONTROLLER
            //=========================================
            $scope.saveFormData = function () {
                $scope.initFormData();
                if ($scope.globalRoleID == '') {
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
                $scope.Description = $scope.frmData[0].Description;                
            }

            //===================================================
            //AJAX POST REQUEST - CREATING NEW ROLE
            //===================================================
            $scope.Add = function () {
                $http({
                    method: "post", url: '/Role/RoleAPI', data: $.param({
                        Name: $scope.frmData[0].Name,
                        ID: $scope.frmData[0].ID,
                        Description: $scope.frmData[0].Description                        
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus('11');
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }


            //===================================================
            //AJAX GET REQUEST - GETTING ROLE BY ID
            //===================================================
            $scope.getRoleByID = function () {
                var strGetURL = '/Role/RoleAPI/' + $scope.globalRoleID;
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                $scope.frmData.push({
                    ID: data.ID,
                    Name: data.Name,
                    Description: data.Description
                });
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

            //===================================================
            //AJAX PUT REQUEST - EDIT ROLE
            //===================================================
            $scope.Edit = function () {
                $http({
                    method: "PUT", url: '/Role/RoleAPI', data: $.param({
                        Name: $scope.frmData[0].Name,
                        ID: $scope.frmData[0].ID,
                        Description: $scope.frmData[0].Description
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus('12');
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }

            //===================================================
            //AJAX GET REQUEST - GET ALL ROLES
            //===================================================
            $scope.getAllRoles = function () {
                $("#divContainer").mask("Loading all roles please wait...");
                $http({
                    method: "GET", url: '/Role/RoleAPI'
                }).
            success(function (data, status, headers, config) {
                $("#divContainer").unmask();
                $scope.AllRoles = data;
            }).
                error(function (data, status, headers, config) {
                    $("#divContainer").unmask();
                    NotifyErrorStatus(data, status);
                });
            }
        }])




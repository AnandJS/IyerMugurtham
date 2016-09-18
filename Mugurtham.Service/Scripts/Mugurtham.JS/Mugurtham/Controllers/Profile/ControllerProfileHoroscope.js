/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR HOROSCOPE PAGE ON PROFILE REGISTRATION
==========================================================================================
*/
var ControllerProfileHoroscope = angular.module('MugurthamApp').controller('ControllerProfileHoroscope',
        ['$http', '$scope', '$rootScope', function ($http, $scope, $rootScope) {
            //========================================
            //GLOBAL VARIABLES FOR THIS CONTROLLER
            //=========================================
            $scope.controllerName = 'ControllerProfileHoroscope';
            $scope.frmData = []; // To store the values of the controls in form                        
            $scope.globalProfileID = $rootScope.globalProfileID;
            getHoroscopeByProfileID();
            // Storing Raasi varaibales
            $scope.RaasiKattam1 = '';
            $scope.RaasiKattam2 = '';
            $scope.RaasiKattam3 = '';
            $scope.RaasiKattam4 = '';
            $scope.RaasiKattam5 = '';
            $scope.RaasiKattam6 = '';
            $scope.RaasiKattam7 = '';
            $scope.RaasiKattam8 = '';
            $scope.RaasiKattam9 = '';
            $scope.RaasiKattam10 = '';
            $scope.RaasiKattam11 = '';
            $scope.RaasiKattam12 = '';
            // Storing Amsam varaibales
            $scope.AmsamKattam1 = '';
            $scope.AmsamKattam2 = '';
            $scope.AmsamKattam3 = '';
            $scope.AmsamKattam4 = '';
            $scope.AmsamKattam5 = '';
            $scope.AmsamKattam6 = '';
            $scope.AmsamKattam7 = '';
            $scope.AmsamKattam8 = '';
            $scope.AmsamKattam9 = '';
            $scope.AmsamKattam10 = '';
            $scope.AmsamKattam11 = '';
            $scope.AmsamKattam12 = '';
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
                //Raasi
                $scope.RaasiKattam1 = getKattamValues('ckKattam1_');
                $scope.RaasiKattam2 = getKattamValues('ckKattam2_');
                $scope.RaasiKattam3 = getKattamValues('ckKattam3_');
                $scope.RaasiKattam4 = getKattamValues('ckKattam4_');
                $scope.RaasiKattam5 = getKattamValues('ckKattam5_');
                $scope.RaasiKattam6 = getKattamValues('ckKattam6_');
                $scope.RaasiKattam7 = getKattamValues('ckKattam7_');
                $scope.RaasiKattam8 = getKattamValues('ckKattam8_');
                $scope.RaasiKattam9 = getKattamValues('ckKattam9_');
                $scope.RaasiKattam10 = getKattamValues('ckKattam10_');
                $scope.RaasiKattam11 = getKattamValues('ckKattam11_');
                $scope.RaasiKattam12 = getKattamValues('ckKattam12_');
                //Amsam
                $scope.AmsamKattam1 = getKattamValues('ckAmsamKattam1_');
                $scope.AmsamKattam2 = getKattamValues('ckAmsamKattam2_');
                $scope.AmsamKattam3 = getKattamValues('ckAmsamKattam3_');
                $scope.AmsamKattam4 = getKattamValues('ckAmsamKattam4_');
                $scope.AmsamKattam5 = getKattamValues('ckAmsamKattam5_');
                $scope.AmsamKattam6 = getKattamValues('ckAmsamKattam6_');
                $scope.AmsamKattam7 = getKattamValues('ckAmsamKattam7_');
                $scope.AmsamKattam8 = getKattamValues('ckAmsamKattam8_');
                $scope.AmsamKattam9 = getKattamValues('ckAmsamKattam9_');
                $scope.AmsamKattam10 = getKattamValues('ckAmsamKattam10_');
                $scope.AmsamKattam11 = getKattamValues('ckAmsamKattam11_');
                $scope.AmsamKattam12 = getKattamValues('ckAmsamKattam12_');
            }
            function getKattamValues(strKattamIndex) {
                var selectedItems = '';
                $('input[name^=' + strKattamIndex + ']').each(function () {
                    if ($(this).is(":checked"))
                        selectedItems += $(this).val() + ',';
                });
                return selectedItems.slice(0, -1);
            }
            function setKattamValues(strKattamIndex, strCSV) {
                if (strCSV != null) {
                    $.each(strCSV.split(","), function (Index, value) {
                        $('input[name^=' + strKattamIndex + ']').each(function () {
                            if ($(this).val() == value)
                                $(this).attr('checked', true);
                        });
                    });
                }
            }
            //===================================================
            //AJAX GET REQUEST - GETTING HOROSCOPE BY ID
            //===================================================
            function getHoroscopeByProfileID() {
                var strGetURL = '/mugurthamapi/HoroscopeAPI/' + $scope.globalProfileID;
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                // Maintainstate for Raasi checkbox
                setKattamValues('ckKattam1_', data.RaasiKattam1);
                setKattamValues('ckKattam2_', data.RaasiKattam2);
                setKattamValues('ckKattam3_', data.RaasiKattam3);
                setKattamValues('ckKattam4_', data.RaasiKattam4);
                setKattamValues('ckKattam5_', data.RaasiKattam5);
                setKattamValues('ckKattam6_', data.RaasiKattam6);
                setKattamValues('ckKattam7_', data.RaasiKattam7);
                setKattamValues('ckKattam8_', data.RaasiKattam8);
                setKattamValues('ckKattam9_', data.RaasiKattam9);
                setKattamValues('ckKattam10_', data.RaasiKattam10);
                setKattamValues('ckKattam11_', data.RaasiKattam11);
                setKattamValues('ckKattam12_', data.RaasiKattam12);
                // Maintainstate for Amsam checkbox
                setKattamValues('ckAmsamKattam1_', data.AmsamKattam1);
                setKattamValues('ckAmsamKattam2_', data.AmsamKattam2);
                setKattamValues('ckAmsamKattam3_', data.AmsamKattam3);
                setKattamValues('ckAmsamKattam4_', data.AmsamKattam4);
                setKattamValues('ckAmsamKattam5_', data.AmsamKattam5);
                setKattamValues('ckAmsamKattam6_', data.AmsamKattam6);
                setKattamValues('ckAmsamKattam7_', data.AmsamKattam7);
                setKattamValues('ckAmsamKattam8_', data.AmsamKattam8);
                setKattamValues('ckAmsamKattam9_', data.AmsamKattam9);
                setKattamValues('ckAmsamKattam10_', data.AmsamKattam10);
                setKattamValues('ckAmsamKattam11_', data.AmsamKattam11);
                setKattamValues('ckAmsamKattam12_', data.AmsamKattam12);
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }
            //===================================================
            //AJAX PUT REQUEST - EDIT HOROSCOPE FOR PROFILE
            //===================================================
            $scope.Edit = function () {
                $http({
                    method: "PUT", url: '/mugurthamapi/HoroscopeAPI', data: $.param({
                        ProfileID: $scope.globalProfileID,
                        RaasiKattam1: $scope.RaasiKattam1,
                        RaasiKattam2: $scope.RaasiKattam2,
                        RaasiKattam3: $scope.RaasiKattam3,
                        RaasiKattam4: $scope.RaasiKattam4,
                        RaasiKattam5: $scope.RaasiKattam5,
                        RaasiKattam6: $scope.RaasiKattam6,
                        RaasiKattam7: $scope.RaasiKattam7,
                        RaasiKattam8: $scope.RaasiKattam8,
                        RaasiKattam9: $scope.RaasiKattam9,
                        RaasiKattam10: $scope.RaasiKattam10,
                        RaasiKattam11: $scope.RaasiKattam11,
                        RaasiKattam12: $scope.RaasiKattam12,
                        AmsamKattam1: $scope.AmsamKattam1,
                        AmsamKattam2: $scope.AmsamKattam2,
                        AmsamKattam3: $scope.AmsamKattam3,
                        AmsamKattam4: $scope.AmsamKattam4,
                        AmsamKattam5: $scope.AmsamKattam5,
                        AmsamKattam6: $scope.AmsamKattam6,
                        AmsamKattam7: $scope.AmsamKattam7,
                        AmsamKattam8: $scope.AmsamKattam8,
                        AmsamKattam9: $scope.AmsamKattam9,
                        AmsamKattam10: $scope.AmsamKattam10,
                        AmsamKattam11: $scope.AmsamKattam11,
                        AmsamKattam12: $scope.AmsamKattam12
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                NotifySuccessStatus('6');
            }).
            error(function (data, status, headers, config) {
                NotifyErrorStatus(data, status);
            });
            }
        }])

/*
==========================================================================================
THIS CONTROLLER IS SPECIFICALLY FOR BASIC INFO PAGE ON PROFILE REGISTRATION
==========================================================================================
*/
var ControllerProfileBasicInfo = angular.module('MugurthamApp').controller('ControllerProfileBasicInfo',
        ['$http', '$scope', '$routeParams', '$rootScope', function ($http, $scope, $routeParams, $rootScope) {

            //Code commented - As to use the HTML5 DTPicker instead of JQuery DTPicker
            $("#dtDOB").datepicker({
                showOn: "button",
                buttonImage: "images/Mugurtham/calendar.gif",
                buttonImageOnly: true,
                buttonText: "Select date",
                changeMonth: true,
                changeYear: true
            });
            //========================================
            //GLOBAL VARIABLES FOR THIS CONTROLLER
            //=========================================
            $scope.controllerName = 'ControllerProfileBasicInfo';
            $scope.frmData = []; // To store the values of the controls in form            
            if (typeof $routeParams.ProfileID != 'undefined') {
                $rootScope.globalProfileID = $routeParams.ProfileID;
            }
            // Form Control Variables
            $scope.ProfileID = $rootScope.globalProfileID;
            $scope.globalProfileID = $rootScope.globalProfileID;
            //========================================
            //LOOKUP DATA FOR THIS CONTROLLER
            //=========================================
            $scope.arrMaritalStatus = ['Single', 'Widow', 'Awaiting Divorce', 'Widower'];
            $scope.arrChildrenLivingStatus = ['Yes not living togeather', 'Yes living togeather', 'No'];
            $scope.arrBodyType = ['Athletic', 'Slim', 'Average', 'Heavy'];
            $scope.arrComplexion = ['Fair', 'Very Fair', 'Dark', 'Wheatish'];
            $scope.arrPhysicalStatus = ['Normal', 'Physically Challenged'];
            $scope.arrMotherToungue = ['Tamil', 'Telugu', 'Malayalam'];
            //$scope.arrRaasi = ['Capricon', 'Libra', 'Aries', 'Scorpio', 'Leo', 'Cancer', 'Pisces', 'Virgo', 'Aquarius', 'Gemini', 'Sagittarius', 'Taurus'];
            $scope.arrRaasi = ['Mesham', 'Rishabam', 'Mithunam', 'Katakam', 'Simmam', 'Kanni', 'Thulam', 'Viruchigam', 'Dhanusu', 'Makaram', 'Kumbam', 'Meenam'];
            $scope.arrHoroscopeMatch = ['Yes', 'No'];
            $scope.arrDhosham = ['No', 'Naga', 'Sevvai', 'Kalathira'];
            $scope.arrEating = ['Eggetarian', 'Vegetarian', 'Non-Vegetarian'];
            $scope.arrSmoking = ['Occasionally', 'Yes', 'No'];
            $scope.arrDrinking = ['Occasionally', 'Yes', 'No'];

            $scope.arrHeight = ['4ft 5in - 134 cm', '4ft 6in - 137 cm', '4ft 7in - 139 cm', '4ft 8in - 142 cm', '4ft 9in - 144 cm', '4ft 10in - 147 cm', '4ft 11in - 149 cm', '5ft 1in - 154 cm', '5ft 2in - 157 cm', '5ft 3in - 160 cm', '5ft 4in - 162 cm', '5ft 5in - 165 cm', '5ft 6in - 167 cm', '5ft 7in - 170 cm', '5ft 8in - 172 cm', '5ft 9in - 175 cm', '5ft 10in - 177 cm', '5ft 11in - 180 cm', '6ft - 182 cm', '6ft 1in - 185 cm', '6ft 2in - 187 cm', '6ft 3in - 190 cm', '6ft 4in - 193 cm', '6ft 5in - 195 cm', '6in - 198 cm', '6ft 7in - 200 cm', '8in - 203 cm', '6ft 9in - 205 cm', '6ft 10in - 208 cm', '6ft 11in - 210 cm', '7ft - 213 cm'];
            $scope.arrBlodGroup = ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'];
            $scope.arrProfileCreatedBy = ['Self', 'Parents', 'Gaurdian', 'Relative', 'Friend'];
            $scope.arrSubCaste = ['Ashtasahasram', 'Brahacharnam', 'Vadama', 'Vathima', 'Others'];
            $scope.arrStar = ['Anusham', 'Aswini', 'Avittam', 'Aayilyam', 'Bharani', 'Chithirai', 'Hastham', 'Karthigai', 'Kettai', 'Makam', 'Moolam', 'Mrigasheersham', 'Pooraadam', 'Pooram', 'Poorattathi', 'Poosam', 'Punarpoosam', 'Revathi', 'Rohini', 'Sadayam', 'Swaathi', 'Thiruvaathirai', 'Thiruvonam', 'Uthiraadam', 'Uthiram', 'Uthirattathi', 'Visaakam'];

            if ($rootScope.globalProfileID != 'New')
                getBasicInfoByProfileID();
            $scope.SangamID = '';
            $scope.SangamProfileID = '';
            $scope.Name = '';
            $scope.Age = '';
            $scope.Gender = '';
            $scope.DOB = '';
            $scope.TOB = '';
            $scope.MaritalStatus = '';
            $scope.NoOfChildren = '';
            $scope.ChildrenLivingStatus = '';
            $scope.Height = '';
            $scope.Weight = '';
            $scope.BodyType = '';
            $scope.Complexion = '';
            $scope.PhysicalStatus = '';
            $scope.BloodGroup = '';
            $scope.MotherTongue = '';
            $scope.ProfileCreatedBy = '';
            $scope.Region = '';
            $scope.Caste = '';
            $scope.SubCaste = '';
            $scope.Gothram = '';
            $scope.Star = '';
            $scope.Raasi = '';
            $scope.HoroscopeMatch = '';
            $scope.AnyDhosham = '';
            $scope.Eating = '';
            $scope.Smoking = '';
            $scope.Drinking = '';
            $scope.AboutMe = '';
            $scope.PartnerExpectation = '';
            $scope.ElanUserID = '';
            $scope.PhotoPath = '';
            $scope.ProfileCreatedDate = '';

            //========================================
            //GLOBAL EVENT HANDLER FOR THIS CONTROLLER
            //=========================================
            $scope.saveFormData = function () {
                $scope.initFormData();
                if ($scope.ProfileID == '' || $scope.ProfileID == 'New') {
                    $scope.Add();
                } else {
                    $scope.Edit();
                }
            }
            //=====================================
            //PRIVATE METHODS FOR THIS CONTROLLER
            //====================================
            $scope.initFormData = function () {
                $scope.SangamProfileID = $scope.frmData[0].SangamProfileID;
                $scope.Name = $scope.frmData[0].Name;
                $scope.Age = $scope.frmData[0].Age;
                $scope.Gender = $('.radProfileGender:checked').val();
                $scope.DOB = $scope.frmData[0].DOB;
                $scope.TOB = $scope.frmData[0].TOB;
                $scope.MaritalStatus = $scope.frmData[0].MaritalStatus;
                $scope.NoOfChildren = $scope.frmData[0].NoOfChildren;
                $scope.ChildrenLivingStatus = $scope.frmData[0].ChildrenLivingStatus;
                $scope.Height = $scope.frmData[0].Height;
                $scope.Weight = $scope.frmData[0].Weight;
                $scope.BodyType = $scope.frmData[0].BodyType;
                $scope.Complexion = $scope.frmData[0].Complexion;
                $scope.PhysicalStatus = $scope.frmData[0].PhysicalStatus;
                $scope.BloodGroup = $scope.frmData[0].BloodGroup;
                $scope.MotherTongue = $scope.frmData[0].MotherTongue;
                $scope.ProfileCreatedBy = $scope.frmData[0].ProfileCreatedBy;
                $scope.Region = $scope.frmData[0].Religion;
                $scope.Caste = $scope.frmData[0].Caste;
                $scope.SubCaste = $scope.frmData[0].SubCaste;
                $scope.Gothram = $scope.frmData[0].Gothram;
                $scope.Star = $scope.frmData[0].Star;
                $scope.Raasi = $scope.frmData[0].Raasi;
                $scope.HoroscopeMatch = $scope.frmData[0].HoroscopeMatch;
                $scope.AnyDhosham = $scope.frmData[0].AnyDhosham;
                $scope.Eating = $scope.frmData[0].Eating;
                $scope.Smoking = $scope.frmData[0].Smoking;
                $scope.Drinking = $scope.frmData[0].Drinking;
                $scope.AboutMe = $scope.frmData[0].AboutMe;
                $scope.PartnerExpectation = $scope.frmData[0].PartnerExpectation;
                $scope.PhotoPath = $scope.frmData[0].PhotoPath;
                $scope.ProfileCreatedDate = $scope.frmData[0].ProfileCreatedDate;

            }

            //=========================================
            //AJAX POST REQUEST - CREATING NEW PROFILE
            //==========================================
            $scope.Add = function () {
                $("#body").mask("Saving Basic Information please wait...");
                $http({
                    method: "post", url: '/Profile/Profile/Add', data: $.param({
                        ProfileID: $scope.ProfileID,
                        SangamProfileID: $scope.SangamProfileID,
                        SangamID: $scope.SangamID,
                        Name: $scope.Name,
                        Age: $scope.Age,
                        Gender: $scope.Gender,
                        DOB: $scope.DOB,
                        TOB: $scope.TOB,
                        MaritalStatus: $scope.MaritalStatus,
                        NoOfChildren: $scope.NoOfChildren,
                        Height: $scope.Height,
                        Weight: $scope.Weight,
                        BodyType: $scope.BodyType,
                        Complexion: $scope.Complexion,
                        PhysicalGroup: $scope.PhysicalGroup,
                        BloodGroup: $scope.BloodGroup,
                        MotherTongue: $scope.MotherTongue,
                        ProfileCreatedBy: $scope.ProfileCreatedBy,
                        Religion: $scope.Religion,
                        Caste: $scope.Caste,
                        SubCaste: $scope.SubCaste,
                        Gothram: $scope.Gothram,
                        Star: $scope.Star,
                        Raasi: $scope.Raasi,
                        HoroscopeMatch: $scope.HoroscopeMatch,
                        AnyDhosham: $scope.AnyDhosham,
                        Eating: $scope.Eating,
                        Smoking: $scope.Smoking,
                        Drinking: $scope.Drinking,
                        AboutMe: $scope.AboutMe,
                        PartnerExpectation: $scope.PartnerExpectation,
                        PhotoPath: $scope.PhotoPath
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                $("#body").unmask();
                data = data.replace('"', ''); data = data.replace('"', '')
                $rootScope.globalProfileID = data;
                $scope.ProfileID = data;
                NotifySuccessStatus(1);
            }).
            error(function (data, status, headers, config) {
                $("#body").unmask();
                NotifyErrorStatus(data, status);
            });
            }


            //=========================================
            //AJAX PUT REQUEST - UPDATING EXISITING PROFILE
            //==========================================
            $scope.Edit = function () {
                $("#body").mask("Updating Basic Information please wait...");
                $http({
                    method: "PUT", url: '/BasicInfo/BasicInfoAPI/', data: $.param({
                        ProfileID: $scope.ProfileID,
                        SangamProfileID: $scope.SangamProfileID,
                        SangamID: $scope.SangamID,
                        Name: $scope.Name,
                        Age: $scope.Age,
                        Gender: $scope.Gender,
                        DOB: $scope.DOB,
                        TOB: $scope.TOB,
                        MaritalStatus: $scope.MaritalStatus,
                        NoOfChildren: $scope.NoOfChildren,
                        ChildrenLivingStatus: $scope.ChildrenLivingStatus,
                        Height: $scope.Height,
                        Weight: $scope.Weight,
                        BodyType: $scope.BodyType,
                        Complexion: $scope.Complexion,
                        PhysicalGroup: $scope.PhysicalGroup,
                        BloodGroup: $scope.BloodGroup,
                        MotherTongue: $scope.MotherTongue,
                        ProfileCreatedBy: $scope.ProfileCreatedBy,
                        Religion: $scope.Religion,
                        Caste: $scope.Caste,
                        SubCaste: $scope.SubCaste,
                        Gothram: $scope.Gothram,
                        Star: $scope.Star,
                        Raasi: $scope.Raasi,
                        HoroscopeMatch: $scope.HoroscopeMatch,
                        AnyDhosham: $scope.AnyDhosham,
                        Eating: $scope.Eating,
                        Smoking: $scope.Smoking,
                        Drinking: $scope.Drinking,
                        PhysicalStatus: $scope.PhysicalStatus,
                        AboutMe: $scope.AboutMe,
                        PartnerExpectation: $scope.PartnerExpectation,
                        ElanUserID: $scope.ElanUserID,
                        PhotoPath: $scope.PhotoPath,
                        CreatedDate: $scope.frmData[0].ProfileCreatedDate
                    }),
                    headers: { 'content-Type': 'application/x-www-form-urlencoded' }
                }).
            success(function (data, status, headers, config) {
                $("#body").unmask();
                NotifySuccessStatus(2);
            }).
            error(function (data, status, headers, config) {
                $("#body").unmask();
                NotifyErrorStatus(data, status);
            });
            }


            //===================================================
            //AJAX GET REQUEST - GETTING PROFILE BY ID
            //===================================================
            function getBasicInfoByProfileID() {
                var strGetURL = '/BasicInfo/BasicInfoAPI/' + $scope.ProfileID;
                $("#body").mask("Retreiving Profile please wait...");
                $http({
                    method: "GET", url: strGetURL
                }).
            success(function (data, status, headers, config) {
                MaintainState(data);
                $scope.SangamID = data.SangamID;
                $scope.ElanUserID = data.ElanUserID;
                $scope.frmData.push({
                    ID: data.ID,
                    SangamProfileID: data.SangamProfileID,
                    Name: data.Name,
                    Age: data.Age,
                    DOB: data.DOB,
                    TOB: data.TOB,
                    MaritalStatus: data.MaritalStatus,
                    NoOfChildren: data.NoOfChildren,
                    ChildrenLivingStatus: data.ChildrenLivingStatus,
                    Height: data.Height,
                    Weight: data.Weight,
                    BodyType: data.BodyType,
                    Complexion: data.Complexion,
                    PhysicalStatus: data.PhysicalStatus,
                    BloodGroup: data.BloodGroup,
                    MotherTongue: data.MotherTongue,
                    ProfileCreatedBy: data.ProfileCreatedBy,
                    Religion: data.Religion,
                    Caste: data.Caste,
                    SubCaste: data.SubCaste,
                    Gothram: data.Gothram,
                    Star: data.Star,
                    Raasi: data.Raasi,
                    HoroscopeMatch: data.HoroscopeMatch,
                    AnyDhosham: data.AnyDhosham,
                    Eating: data.Eating,
                    Smoking: data.Smoking,
                    Drinking: data.Drinking,
                    AboutMe: data.AboutMe,
                    PartnerExpectation: data.PartnerExpectation,
                    PhotoPath: data.PhotoPath
                });

                /*Logic to add 1 day to JQuery Formatting*/
                //<!--http://www.miuaiga.com/index.cfm/2009/11/11/Javascript-How-To-Add-a-Number-of-Days-to-a-Date-->
                var intAddNoOfDays = 1;
                var startDate = new Date(Date.parse(data.DOB));
                var dtDOB = startDate;
                dtDOB.setDate(startDate.getDate() + intAddNoOfDays);
                /*Logic to add 1 day to JQuery Formatting Ends*/

                if (data.DOB != null)
                    $scope.frmData[0].DOB = $.datepicker.formatDate('dd-M-yy', new Date(dtDOB));
                if (data.CreatedDate != null) {
                    $scope.frmData[0].ProfileCreatedDate = data.CreatedDate;
                }
                $("#body").unmask();
            }).
            error(function (data, status, headers, config) {
                $("#body").unmask();
                NotifyErrorStatus(data, status);
            });
            }
        }])

function MaintainState(arrFrmData) {
    $('input[name="radProfileGender"][value="' + arrFrmData.Gender + '"]').prop('checked', true);
}
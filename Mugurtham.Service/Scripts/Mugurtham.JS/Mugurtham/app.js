

(function () {



    var app = angular.module('MugurthamApp', ['ngRoute', 'pascalprecht.translate', 'angular-table', 'angularUtils.directives.dirPagination'])

    /*=====================================================================*/
    /*COMPLETE PAGINATION IS HANDLED BELOW*/
    /*=====================================================================*/
    //We already have a limitTo filter built-in to angular,
    //let's make a startFrom filter
    app.filter('startFrom', function () {
        return function (input, start) {
            start = +start; //parse to int
            return input.slice(start);
        }
    });
    /*=====================================================================*/
    /*COMPLETE ROUTING IS HANDLED BELOW*/
    /*=====================================================================*/

    app.config(['$routeProvider', '$translateProvider', function ($routeProvider, $translateProvider) {
        $routeProvider

             /*=====================================================================*/
            /*USER MODULE ROUTING DEFINED
            /*=====================================================================*/
            .when('/ProfileUserDashboard', {
                templateUrl: '/User/User/HighlightedProfiles',
                controller: 'ControllerHighlightedProfiles'
            })
            .when('/ViewNotifications', {
                templateUrl: '/User/User/ViewedProfiles',
                controller: 'ControllerViewedProfiles'
            })
            .when('/InterestedProfiles', {
                templateUrl: '/User/User/InterestedProfiles',
                controller: 'ControllerInterestedProfiles'
            })
            .when('/InterestedInMeProfiles', {
                templateUrl: '/User/User/InterestedInMeProfiles',
                controller: 'ControllerInterestedInMeProfiles'
            })
            // route for the Basic Information View
             .when('/BasicInfo', {
                 templateUrl: '/Profile/Profile/BasicInfo',
                 controller: 'ControllerProfileBasicInfo'
             })
             // route for the Basic Information View on specific profile ID
             .when('/BasicInfo/:ProfileID', {
                 templateUrl: '/Profile/Profile/BasicInfo',
                 controller: 'ControllerProfileBasicInfo'
             })
            // route for the Basic Education View
             .when('/Career', {
                 templateUrl: '/Profile/Profile/Career',
                 controller: 'ControllerProfileCareer'
             })

             // route for the  Contact View
             .when('/Contact', {
                 templateUrl: '/Profile/Profile/Contact',
                 controller: 'ControllerProfileContact'
             })

             // route for the  Family View
             .when('/Family', {
                 templateUrl: '/Profile/Profile/Family',
                 controller: 'ControllerProfileFamily'
             })

             // route for the  Location View
             .when('/Location', {
                 templateUrl: '/Profile/Profile/Location',
                 controller: 'ControllerProfileLocation'
             })
             // route for the  Reference View
             .when('/Reference', {
                 templateUrl: '/Profile/Profile/Reference',
                 controller: 'ControllerProfileReference'
             })
             // route for the Basic Horoscope View
             .when('/Horoscope', {
                 templateUrl: '/Profile/Profile/Horoscope',
                 controller: 'ControllerProfileHoroscope'
             })

             // route for the  Photo View
             .when('/Photo', {
                 templateUrl: '/Profile/Profile/Photo',
                 controller: 'ControllerProfilePhoto'
             })

             // route for the  Album View
            .when('/Album', {
                templateUrl: '/Profile/Profile/Album'
            })

       /*======================================================*/
       /*ROUTING FOR SEARCH MODULE STARTS HERE*/
       /*======================================================*/
        // route for the  ProfileID Search
             .when('/ProfileID', {
                 templateUrl: '/Search/Search/ProfileID',
                 controller: 'ControllerSearchProfileID'
             })
        // route for the  All Profiles Search
        .when('/AllProfiles', {
            templateUrl: '/Search/Search/AllProfiles',
            controller: 'ControllerSearchAllProfiles'
        })
         // route for the  General Search 
        .when('/GeneralSearch', {
            templateUrl: '/Search/Search/GeneralSearch',
            controller: 'ControllerSearchGeneral'
        })
          // route for the  SangamSearch 
        .when('/SangamSearch', {
            templateUrl: '/Search/Search/SangamSearch',
            controller: 'ControllerSearchSangam'
        })
       /*======================================================*/
       /*ROUTING FOR VIEW MODULE STARTS HERE*/
       /*======================================================*/
          // route for the  fullview View
        .when('/FullView/:ProfileID', {
            templateUrl: '/View/FullView/FullView',
            controller: 'ControllerViewFullView'
        })
         /*======================================================*/
       /*ROUTING FOR MUGURTHAM ADMIN STARTS HERE*/
       /*======================================================*/
          // route for the  fullview View
        .when('/MugurthamDashboard', {
            templateUrl: '/MugurthamAdmin/MugurthamAdmin/Dashboard'
        })
        .when('/SangamList', {
            templateUrl: '/MugurthamAdmin/Sangam/List',
            controller: 'ControllerSangam'
        })
      .when('/SangamForm', {
          templateUrl: '/MugurthamAdmin/Sangam/Form',
          controller: 'ControllerSangam'
      })
        .when('/SangamForm/:SangamID', {
            templateUrl: '/MugurthamAdmin/Sangam/Form',
            controller: 'ControllerSangam'
        })
        .when('/MugurthamProfiles', {
            templateUrl: '/MugurthamAdmin/MugurthamAdmin/Profiles',
            controller: 'ControllerUser'
        })
        /*======================================================*/
       /*ROUTING FOR SANGAM ADMIN STARTS HERE*/
       /*======================================================*/
        .when('/SangamDashboard', {
            templateUrl: '/SangamAdmin/SangamAdmin/Dashboard',
            controller: 'ControllerSangamDashboard'
        })
        .when('/SangamAdminSettings', {
            templateUrl: '/SangamAdmin/SangamAdmin/Settings'
        })
        .when('/SangamAdminProfiles', {
            templateUrl: '/SangamAdmin/SangamAdmin/SangamAdminProfiles',
            controller: 'ControllerSangamAdminProfiles'
        })
        .when('/SangamUserList', {
            templateUrl: '/SangamAdmin/SangamUser/List',
            controller: 'ControllerUser'
        })
        .when('/SangamUserForm/:UserID', {
            templateUrl: '/SangamAdmin/SangamUser/Form',
            controller: 'ControllerUser'
        })
         /*======================================================*/
       /*ROUTING FOR ROLE STARTS HERE*/
       /*======================================================*/
        .when('/RoleList', {
            templateUrl: '/MugurthamAdmin/Role/List',
            controller: 'ControllerRole'
        })
        .when('/RoleForm', {
            templateUrl: '/MugurthamAdmin/Role/Form',
            controller: 'ControllerRole'
        })
        .when('/RoleForm/:RoleID', {
            templateUrl: '/MugurthamAdmin/Role/Form',
            controller: 'ControllerRole'
        })
         /*======================================================*/
       /*ROUTING FOR USER STARTS HERE*/
       /*======================================================*/

        .when('/UserList', {
            templateUrl: '/MugurthamAdmin/User/List',
            controller: 'ControllerUser'
        })
        .when('/UserForm', {
            templateUrl: '/MugurthamAdmin/User/Form',
            controller: 'ControllerUser'
        })
        .when('/UserForm/:UserID', {
            templateUrl: '/MugurthamAdmin/User/Form',
            controller: 'ControllerUser'
        })
        .when('/UserSettingsForm', {
            templateUrl: '/User/User/UserSettingsForm',
            controller: 'ControllerUser'
        })
         .when('/RecentlyJoined', {
             templateUrl: '/User/User/RecentlyJoined',
             controller: 'ControllerRecentlyJoined'

         })


        ;

        //My Reference for transalation - best one
        //https://angular-translate.github.io/
        /*
        <p translate="FOO">Dies ist ein Paragraph.</p>
        <button class="btn ng-scope" ng-click="changeLanguage('en')" translate="BUTTON_LANG_EN">englisch</button>
        */

        /*****************TRANSALATION STARTS HERE ***********************************/
        //https://msdn.microsoft.com/en-us/goglobal/bb964664.aspx
        $translateProvider.translations('0409', {

            GENHOME: 'Home',
            GENSRCH: 'Search',
            GENVIEW: 'View',
            GENPROF: 'Profile',
            GENMALE: 'Male',
            GENFEMALE: 'Female',
            GENPROFID: 'Profile ID',
            GENSAVE: 'Save',
            GENCOPYRT: 'Copyright',
            GENSANGAM: 'Sangam',
            GENABOUT: 'About',
            LYTSRCH: 'Search for Profiles',
            LYTPROFILES: 'Profiles',
            LYTSHRTLISPROFILES: 'Profiles I liked',
            LYTEDITMYPROFILE: 'Edit My Profile',
            LYTSETTINGS: 'Settings',
            LYTUSRHOME: 'User Home',
            LYTPROFDASHBRD: 'Profile Dashboard',
            LYTPRFREGFOR: 'Profile Registration - for Profile ID',
            LYTPRFTABBI: 'Basic Information',
            LYTPRFTABCAR: 'Career',
            LYTPRFTABCONT: 'Contact',
            LYTPRFTABFAM: 'Family',
            LYTPRFTABLOC: 'Location',
            LYTPRFTABREF: 'Reference',
            LYTPRFTABHORO: 'Horoscope',
            LYTPRFTABPHO: 'Photo',
            BIBINFREGFRM: 'Basic Information Registration Form',
            BISANGAMUSERID: 'Sangam User ID',
            BINAME: 'Name',
            BIAGE: 'Age',
            BIGEN: 'Gender',
            BIDOB: 'Date of Birth',
            BITOB: 'Time of Birth',
            BIMARSTATUS: 'Marital Status',
            BINOOFCHIL: 'No Of Children',
            BICHILLVNGST: 'Children living status',
            BIHEIGHT: 'Height',
            BIWEIGHT: 'Weight',
            BIBDYTPE: 'Body Type',
            BICOMPLEXION: 'Complexion',
            BIPHYSTA: 'Physical Status',
            BIBLGRP: 'Blood Group',
            BIMOTONG: 'Mother Tongue',
            BIPROFCRBY: 'Profile created by',
            BIRLGN: 'Religion',
            BICST: 'Caste',
            BISUBCST: 'Subsect',
            BIGOTHRM: 'Gothra(m)',
            BISTR: 'Star',
            BIRAASI: 'Raasi',
            BIHORMTCH: 'Horoscope Match',
            BIANYDHSM: 'Any Dhosham',
            BIETNG: 'Eating',
            BISMKNG: 'Smoking',
            BIDRNKNG: 'Drinking',
            BIABTME: 'About Me',
            BIPRTNTEXPTN: 'Partner Expectation',
            BIHELP: 'This form is used to collect all the basic information about this profile which helps in showcasing this profile to the views who are in search.',
            CRIRF: 'Career Information Registration Form',
            CREDUC: 'Education',
            CREDUCDT: 'Education in detail',
            CREMPIN: 'Employed In',
            CROCCPTN: 'Occupation',
            CROCCPTNDTL: 'Occupation in detail',
            CRANINC: 'Annual Income',
            CRHELP: 'This form is used to collect information about the Education details, Occupation details of this profile',
            CONRF: 'Contact Information Registration Form',
            CONEMAIL: 'Email',
            CONMOBNO: 'Mobile Number',
            CONLNDNO: 'Landline Number',
            CONRESADR: 'Residential Address',
            CONREL: 'Relationship',
            CONTMETOCALL: 'Time to call',
            CONHELP: 'This form is used to collect information about the contact details about this profile',
            FAMIRF: 'Family Information Registration Form',
            FAMVAL: 'Family Value',
            FAMTYP: 'Family Type',
            FAMSTA: 'Family Status',
            FAMFATNAM: 'Fathers Name',
            FAMMOTNAM: 'Mothers Name',
            FAMFATOCC: 'Fathers Occupation',
            FAMMOTOCC: 'Mothers Occupation',
            FAMANSFAMORG: 'Native Place',
            FAMNOOFBRO: 'No of Brothers',
            FAMMARDBRO: 'Married Brothers',
            FAMNOOFSIS: 'No of Sisters',
            FAMMARDSIS: 'Married Sisters',
            FAMABTFAM: 'About Family',
            FAMHELP: 'This form is used to collect information about the family details of this profile',
            LOCIRF: 'Location Information Registration Form',
            LOCTRYLVNIN: 'Country Living In',
            LOCTNSHP: 'Citizenship',
            LOCRESSTS: 'Residential Status',
            LOCRESTATE: 'Resident State',
            LOCRESCTY: 'Resident City',
            LOCHLP: 'This form is used to collect information about the location information about this profile',
            REFIRF: 'Reference Information Registration Form',
            REFNOMNAME: 'Refered By',
            REFCONTNUM: 'Contact Number',
            REFHLP: 'This form is used to collect information about the people who are reference for this profile',
            HOROIRF: 'Horoscope Information Registration Form',
            HORSOORIYAN: 'SOORIYAN',
            HORBUDHAN: 'BUDHAN',
            HORGURU: 'GURU',
            HORKETHU: 'KETHU',
            HORCHANDRAN: 'CHANDRAN',
            HORSUKRAN: 'SUKRAN',
            HORRAGHU: 'RAGHU',
            HORLAGNAM: 'LAGNAM',
            HORSEVAI: 'SEVAI',
            HORSANI: 'SANI',
            PHOIRF: 'Profile Photo Information Registration Form ',
            PHOHLP: 'This form is used to upload the Profile / Album photos of this profile',
            LYTSRCPROFSRC: 'Profile Search',
            LYTSRCALLPROF: 'All Profiles',
            LYTGENSRC: 'General Search',
            LYTSGMSRC: 'Sangam Search',
            SRCIDPROFID: 'Search By Profile ID',
            SRCIDHLP: 'This form is used to collect profile ID and displays the profile information',
            SRCGENHLP: 'This form is used to collect profile ID and displays the profile information',
            SRCSGMSRCH: 'Search by Sangam',
            SRCSGMFLTRBYSGM: 'Filter by Sangam',
            SRCSGMHLP: 'This form is used to collect profile ID and displays the profile information',
            VWSGMINFOFORPROFID: 'Sangam Information for Profile ID',
            VWRESTXT: 'To view the full information of this Profile, you got to register in this Sangam. <br> Please find the Sangam details below to register. Once you registered, you will be able to access the full information.',
            VWCTADRS: 'Contact Address',
            VWABTSGM: 'About Sangam',
            VWFULLPROFVW: 'Full Profile View for Profile ID',
            LYTRCNTLYJNDPROFILES: 'Profiles joined  recently',
            LYTPROFILESLKDME: 'Profiles liked me',
            LYTPROFILESVWDME: 'Profiles viewed me',
            LYTPROFILESHGLTD: 'Highlighted Profiles',
            BIPAADHAM: 'Paadham',
            BIPOB: 'Place of Birth',
            FAMMOTSUBSEC: 'Mothers Subsect',
            FAMPARENTSALIVE: 'Parents Alive'
        });
        $translateProvider.translations('0449', {
            GENHOME: 'முகப்பு பக்கம்',
            GENSRCH: 'தேடல்',
            GENVIEW: 'காண்க',
            GENPROF: 'வரன்',
            GENMALE: 'ஆண்',
            GENFEMALE: 'பெண்',
            GENPROFID: 'வரன் எண்',
            GENSAVE: 'சேமி',
            GENCOPYRT: 'பதிப்புரிமை',
            GENSANGAM: 'சங்கம்',
            GENABOUT: 'குறிப்பு',
            LYTSRCH: 'தேடுக',
            LYTPROFILES: ' வரன்கள்',
            LYTSHRTLISPROFILES: 'என்னக்கு பிடித்தவர்கள்',
            LYTEDITMYPROFILE: 'சுய தகவல் திருத்தம்',
            LYTSETTINGS: 'அமைப்புகள்',
            LYTUSRHOME: 'பயனர் முகப்பு',
            LYTPROFDASHBRD: 'சுய தகவல்',
            LYTPRFREGFOR: 'Profile Registration - for Profile ID',
            LYTPRFTABBI: 'அடிப்படை தகவல்',
            LYTPRFTABCAR: 'கேரியர்',
            LYTPRFTABCONT: 'தொடர்பு',
            LYTPRFTABFAM: 'குடும்பம்',
            LYTPRFTABLOC: 'இடம்',
            LYTPRFTABREF: 'சான்றாதாரம்',
            LYTPRFTABHORO: 'ஜாதகம்',
            LYTPRFTABPHO: 'புகைப்படம்',
            BIBINFREGFRM: 'அடிப்படை தகவல் பதிவு படிவம்',
            BISANGAMUSERID: 'எண்',
            BINAME: 'பெயர்',
            BIAGE: 'வயது',
            BIGEN: 'பாலினம்',
            BIDOB: 'பிறந்த தேதி',
            BITOB: 'பிறந்த நேரம்',
            BIMARSTATUS: 'திருமண நிலை',
            BINOOFCHIL: 'குழந்தைகள் எண்ணிக்கை',
            BICHILLVNGST: 'குழந்தைகள் உங்களுடன் இருகிறார்களா',
            BIHEIGHT: 'உயரம்',
            BIWEIGHT: 'எடை',
            BIBDYTPE: 'உடல் அமைப்பு',
            BICOMPLEXION: 'நிறம்',
            BIPHYSTA: 'உடல் தகுதி',
            BIBLGRP: 'இரத்தப் பிரிவு',
            BIMOTONG: 'தாய்மொழி',
            BIPROFCRBY: 'சுயவிவரம் உருவாக்கிய்து யார்',
            BIRLGN: 'மதம்',
            BICST: 'ஜாதி',
            BISUBCST: 'ஜாதி உட்பிரிவு',
            BIGOTHRM: 'கோத்ரம்',
            BISTR: 'ஸ்டார்',
            BIRAASI: 'ராசி',
            BIHORMTCH: 'ஜாதகப்பொருத்தம்',
            BIANYDHSM: 'தோஷம் இருக்கிறதா',
            BIETNG: 'Eating',
            BISMKNG: 'புகைபிடிக்கும் பழக்கம் உண்டா',
            BIDRNKNG: 'மது அருந்தும் பழக்கம் உண்டா',
            BIABTME: 'என்னைப் பற்றி',
            BIPRTNTEXPTN: 'துணை பற்றிய எதிர்பார்ப்பு',
            BIHELP: 'இந்த வடிவம் தேடி இருந்தால் யார் பார்வையாளர்கள் இந்த சுயவிவரத்தை காண்பிக்கும் உதவுகிறது இந்த சுயவிவரம் பற்றி அனைத்து அடிப்படை தகவல்களைச் சேகரிக்கக்',
            CRIRF: 'தொழில் விவர பதிவு படிவம்',
            CREDUC: 'கல்வித்தகுதி',
            CREDUCDT: 'கல்வித்தகுதி பற்றி விரிவாக',
            CREMPIN: 'பணி புரியும் இடம்',
            CROCCPTN: 'தொழில்',
            CROCCPTNDTL: 'தொழில் விவரம்',
            CRANINC: 'ஆண்டு வருமானம்',
            CRHELP: 'இந்த படிவம் வரனின் படிப்பு மற்றும் தொழில்விவரம் பற்றி தகவல் சேகரிக்க பயன்படுத்தப்படுகிறது',
            CONRF: 'தகவல் தொடர்பு பதிவு படிவம்',
            CONEMAIL: 'மின்னஞ்சல்',
            CONMOBNO: 'அலைப்பேசி எண்',
            CONLNDNO: 'தொலைபேசி எண்',
            CONRESADR: 'வீட்டு முகவரி',
            CONREL: 'உறவு',
            CONTMETOCALL: 'அழைக்க தகுந்த நேரம்',
            CONHELP: 'This form is used to collect information about the contact details about this profile',
            FAMIRF: 'குடும்ப தகவல் பதிவு படிவம்',
            FAMVAL: 'Family Value',
            FAMTYP: 'Family Type',
            FAMSTA: 'Family Status',
            FAMFATNAM: 'தந்தை பெயர்',
            FAMMOTNAM: 'தாயார் பெயர்',
            FAMFATOCC: 'தந்தையின் தொழில்',
            FAMMOTOCC: 'தாயின் தொழில்',
            FAMANSFAMORG: 'பிறப்பிடம் / பூர்வீகம்',
            FAMNOOFBRO: 'சகோதரர்கள் எண்ணிக்கை',
            FAMMARDBRO: 'மணமான சகோதரர்கள்',
            FAMNOOFSIS: 'சகோதரிகள்  எண்ணிக்கை',
            FAMMARDSIS: 'மணமான சகோதரிகள்',
            FAMABTFAM: 'குடும்ப விவரம்',
            FAMHELP: 'இந்த படிவம் குடும்ப விவரம் பற்றி தகவல் சேகரிக்க பயன்படுத்தப்படுகிறது',
            LOCIRF: 'இருப்பிட தகவல் விண்ணப்ப படிவம்',
            LOCTRYLVNIN: 'வசிக்கும் நாடு',
            LOCTNSHP: 'குடியுரிமை',
            LOCRESSTS: 'குடியிருப்புத் தகுதி',
            LOCRESTATE: 'வசிக்கும் மாநிலம்',
            LOCRESCTY: 'வசிக்கும் நகரம்',
            LOCHLP: 'இந்தப்  படிவம், வரனின் இருப்பிடத் தகவல்கள் சேகரிக்க பயன்படுத்தப்படுகிறது',
            REFIRF: 'பரிந்துரைப்பவர் பற்றிய விண்ணப்ப படிவம்',
            REFNOMNAME: 'நியமிக்கப்பட்டவர் பெயர்',
            REFCONTNUM: 'தொடர்பு எண்',
            REFHLP: 'இந்தப்படிவம் வரனை சிபாரிசு செய்பவர்கள் பற்றிய விவரங்களை சேகரிக்க பயன்படுத்தப் படுகிறது ',
            HOROIRF: 'ஜாதகத் தகவல் பதிவுப்  படிவம்',
            HORSOORIYAN: 'சூரியன்',
            HORBUDHAN: 'புதன்',
            HORGURU: 'குரு',
            HORKETHU: 'கேது',
            HORCHANDRAN: 'சந்திரன்',
            HORSUKRAN: 'சுக்ரன்',
            HORRAGHU: 'ராகு',
            HORLAGNAM: 'லக்னம்',
            HORSEVAI: 'செவ்வாய்',
            HORSANI: 'சனி',
            PHOIRF: 'வரனின் புகைப்பட தகவல் பதிவு படிவம்',
            PHOHLP: 'இந்தப் படிவம் வரனின் புகைப்பட தகவல்களை சேகரிக்கப் பயன்படுகிறது',
            LYTSRCPROFSRC: 'வரன் தேடல் ',
            LYTSRCALLPROF: 'அணைத்து வரன்கள் தேடல்',
            LYTGENSRC: 'பொது தேடல்',
            LYTSGMSRC: 'சங்கம் தேடல் ',
            SRCIDPROFID: 'சுயவிவர அடையாள எண் மூலம் தேடல்',
            SRCIDHLP: 'இப்படிவம் வரனின் அடையாள எண்ணை தேட பயன்படுத்தப்படுகிறது',
            SRCGENHLP: 'இப்படிவம் வரனின் அடையாள எண்ணை தேட பயன்படுத்தப்படுகிறது',
            SRCSGMSRCH: 'சங்கம் தேடல்',
            SRCSGMFLTRBYSGM: 'பில்ட்டர் பை சங்கம்',
            SRCSGMHLP: 'இந்தப் படிவம் சுய விபர அடையாள எண்ணைப் பெற  உபயோகப்படுத்தப்படுகிறது ',
            VWSGMINFOFORPROFID: 'வரன் பற்றிய சங்கத் தகவல்கள் ',
            VWRESTXT: 'To view the full information of this Profile, you got to register in this Sangam. <br> Please find the Sangam details below to register. Once you registered, you will be able to access the full information.',
            VWCTADRS: 'தொடர்பு முகவரி',
            VWABTSGM: 'சங்கம் பற்றி',
            VWFULLPROFVW: 'வரனைப் பற்றிய முழு விபரங்கள்',
            LYTRCNTLYJNDPROFILES: 'சமீபத்தில் சேர்ந்தோர்',
            LYTPROFILESLKDME: 'என்னை பிடித்தவர்கள்',
            LYTPROFILESVWDME: 'என்னை நோக்கியவர்கள்',
            LYTPROFILESHGLTD: 'தனிச்சிறப்பான வரன்கள்',
            BIPOB: 'பிறந்த இடம்',
            BIPAADHAM: 'பாதம்'
        });
        $translateProvider.translations('0439', {
            GENHOME: 'घर',
            GENSRCH: 'खोज',
            GENVIEW: 'राय',
            GENPROF: 'प्रोफ़ाइल',
            GENMALE: 'नर',
            GENFEMALE: 'महिला',
            GENPROFID: 'प्रोफ़ाइल आईडी',
            GENSAVE: 'बचाना',
            GENCOPYRT: 'प्रतिलिप्याधिकार',
            GENSANGAM: 'संगम',
            GENABOUT: ' के बारे में',
            LYTSRCH: 'प्रोफाइल के लिए खोज',
            LYTPROFILES: 'प्रोफाइल',
            LYTSHRTLISPROFILES: 'प्रोफाइल मैं पसंद',
            LYTEDITMYPROFILE: 'मेरे प्रोफ़ाइल संपादित करे',
            LYTSETTINGS: 'सेटिंग्स',
            LYTUSRHOME: 'उपयोगकर्ता के घर',
            LYTPROFDASHBRD: 'प्रोफ़ाइल डैशबोर्ड',
            LYTPRFREGFOR: 'प्रोफ़ाइल पंजीकरण के लिए प्रोफ़ाइल आईडी',
            LYTPRFTABBI: 'मूलभूत जानकारी',
            LYTPRFTABCAR: 'व्यवसाय',
            LYTPRFTABCONT: 'संपर्क करें',
            LYTPRFTABFAM: 'परिवार',
            LYTPRFTABLOC: 'स्थान',
            LYTPRFTABREF: 'संदर्भ',
            LYTPRFTABHORO: 'राशिफल',
            LYTPRFTABPHO: 'तस्वीर',
            BIBINFREGFRM: 'बुनियादी जानकारी पंजीकरण फार्म',
            BISANGAMUSERID: 'संगम यूजर आईडी',
            BINAME: 'नाम',
            BIAGE: 'आयु',
            BIGEN: 'लिंग',
            BIDOB: 'जन्म की तारीख',
            BITOB: 'जन्म का समय',
            BIMARSTATUS: 'वैवाहिक स्थिति',
            BINOOFCHIL: 'बच्चो कि संख्या',
            BICHILLVNGST: 'स्थिति रहने वाले बच्चे',
            BIHEIGHT: 'ऊंचाई',
            BIWEIGHT: 'वजन',
            BIBDYTPE: 'शरीर के प्रकार',
            BICOMPLEXION: 'रंग',
            BIPHYSTA: 'शारीरिक स्थिति',
            BIBLGRP: 'रक्त समूह',
            BIMOTONG: 'मातृ भाषा',
            BIPROFCRBY: 'द्वारा बनाई गई प्रोफाइल',
            BIRLGN: 'धर्म',
            BICST: 'जाति',
            BISUBCST: 'उप जाति',
            BIGOTHRM: 'गोत्र (एम)',
            BISTR: 'तारा',
            BIRAASI: 'रासी',
            BIHORMTCH: 'कुंडली मिलान',
            BIANYDHSM: 'कोई भी दोष',
            BIETNG: 'खाना खा रहा हूँ',
            BISMKNG: 'धूम्रपान',
            BIDRNKNG: 'पीने',
            BIABTME: 'मेरे बारे में',
            BIPRTNTEXPTN: 'पार्टनर उम्मीद',
            BIHELP: 'यह फार्म इस प्रोफाइल जो विचारों का जो खोज में हैं इस प्रोफाइल के प्रदर्शन में मदद करता है के बारे में सभी बुनियादी जानकारी इकट्ठा करने के लिए प्रयोग किया जाता है',
            CRIRF: 'कैरियर सूचना पंजीकरण फार्म',
            CREDUC: 'शिक्षा',
            CREDUCDT: 'विस्तार में शिक्षा',
            CREMPIN: 'में कार्यरत',
            CROCCPTN: 'बायो',
            CROCCPTNDTL: 'व्यवसाय विस्तार से',
            CRANINC: 'वार्षिक आय',
            CRHELP: 'यह फार्म शिक्षा विवरण के बारे में जानकारी इकट्ठा करने के लिए, इस प्रोफाइल की बायो विवरण प्रयोग किया जाता है',
            CONRF: 'संपर्क करने संबंधी जानकारी पंजीकरण फार्म',
            CONEMAIL: 'ईमेल',
            CONMOBNO: 'मोबाइल नंबर',
            CONLNDNO: 'लैंडलाइन नंबर',
            CONRESADR: 'घर का पता',
            CONREL: 'संबंध',
            CONTMETOCALL: 'समय फोन करने के लिए',
            CONHELP: 'यह फार्म इस प्रोफाइल के बारे में संपर्क विवरण के बारे में जानकारी इकट्ठा करने के लिए प्रयोग किया जाता है',
            FAMIRF: 'परिवार की जानकारी पंजीकरण फार्म',
            FAMVAL: 'परिवार मान',
            FAMTYP: 'परिवार के प्रकार',
            FAMSTA: 'पारिवारिक स्थिति',
            FAMFATNAM: 'पिता का नाम',
            FAMMOTNAM: 'मां का नाम',
            FAMFATOCC: 'पिता का व्यवसाय',
            FAMMOTOCC: 'मां का व्यवसाय',
            FAMANSFAMORG: 'पैतृक परिवार की उत्पत्ति',
            FAMNOOFBRO: 'ब्रदर्स के नहीं',
            FAMMARDBRO: 'विवाहित ब्रदर्स',
            FAMNOOFSIS: 'बहनों का नहीं',
            FAMMARDSIS: 'विवाहित बहनों',
            FAMABTFAM: 'परिवार के बारे में',
            FAMHELP: 'यह फार्म इस प्रोफाइल की परिवार विवरण के बारे में जानकारी इकट्ठा करने के लिए प्रयोग किया जाता है',
            LOCIRF: 'स्थान की जानकारी पंजीकरण फार्म',
            LOCTRYLVNIN: 'देश के रहने',
            LOCTNSHP: 'नागरिकता',
            LOCRESSTS: 'आवासीय स्थिति',
            LOCRESTATE: 'राज्य के निवासी',
            LOCRESCTY: 'शहर निवासी',
            LOCHLP: 'यह फार्म इस प्रोफाइल के बारे में स्थान की जानकारी के बारे में जानकारी इकट्ठा करने के लिए प्रयोग किया जाता है',
            REFIRF: 'संदर्भ जानकारी पंजीकरण फार्म',
            REFNOMNAME: 'नामांकित व्यक्ति का नाम',
            REFCONTNUM: 'संपर्क संख्या',
            REFHLP: 'यह फार्म लोग हैं, जो इस प्रोफाइल के लिए संदर्भ के बारे में जानकारी इकट्ठा करने के लिए प्रयोग किया जाता है',
            HOROIRF: 'कुंडली सूचना पंजीकरण फार्म',
            HORSOORIYAN: 'SOORIYAN',
            HORBUDHAN: 'BUDHAN',
            HORGURU: 'गुरू',
            HORKETHU: 'केतु',
            HORCHANDRAN: 'चंद्रन',
            HORSUKRAN: 'Sukran',
            HORRAGHU: 'रघु',
            HORLAGNAM: 'LAGNAM',
            HORSEVAI: 'सेवई',
            HORSANI: 'शनि',
            PHOIRF: 'प्रोफाइल फोटो सूचना पंजीकरण फार्म',
            PHOHLP: 'यह फार्म रूपरेखा / एल्बम इस प्रोफाइल की तस्वीरें अपलोड करने के लिए प्रयोग किया जाता है',
            LYTSRCPROFSRC: 'प्रोफाइल',
            LYTSRCALLPROF: 'सभी प्रोफाइल',
            LYTGENSRC: 'जनरल खोजें',
            LYTSGMSRC: 'संगम खोजें',
            SRCIDPROFID: 'प्रोफाइल आईडी के आधार पर खोजें',
            SRCIDHLP: 'यह फार्म प्रोफ़ाइल आईडी इकट्ठा करने के लिए इस्तेमाल किया और प्रोफ़ाइल जानकारी प्रदर्शित करता है',
            SRCGENHLP: 'यह फार्म प्रोफ़ाइल आईडी इकट्ठा करने के लिए इस्तेमाल किया और प्रोफ़ाइल जानकारी प्रदर्शित करता है',
            SRCSGMSRCH: 'संगम के आधार पर खोजें',
            SRCSGMFLTRBYSGM: 'फ़िल्टर संगम द्वारा',
            SRCSGMHLP: 'यह फार्म प्रोफ़ाइल आईडी इकट्ठा करने के लिए इस्तेमाल किया और प्रोफ़ाइल जानकारी प्रदर्शित करता है',
            VWSGMINFOFORPROFID: 'प्रोफ़ाइल आईडी के लिए संगम सूचना',
            VWRESTXT: 'इस प्रोफाइल की पूरी जानकारी देखने के लिए, आप इस संगम में रजिस्टर करने के लिए मिला है। <br> कृपया संगम विवरण नीचे रजिस्टर करने लगता है। एक बार जब आप पंजीकृत है, तो आप पूर्ण जानकारी का उपयोग करने में सक्षम हो जाएगा',
            VWCTADRS: 'संपर्क पता',
            VWABTSGM: 'संगम के बारे में',
            VWFULLPROFVW: 'प्रोफ़ाइल आईडी के लिए पूर्ण प्रोफ़ाइल देखें',
            LYTRCNTLYJNDPROFILES: 'प्रोफाइल हाल ही में शामिल हुए',
            LYTPROFILESLKDME: 'प्रोफाइल मुझे पसंद है',
            LYTPROFILESVWDME: 'प्रोफाइल देखा मुझे',
            LYTPROFILESHGLTD: ' प्रकाश डाला प्रोफाइल',
            BIPOB: 'जन्म स्थान'
        });
        $translateProvider.translations('044a', {
            GENHOME: 'హోం',
            GENSRCH: 'శోధన',
            GENVIEW: 'చూడండి',
            GENPROF: 'ప్రొఫైల్',
            GENMALE: 'మగ',
            GENFEMALE: 'అవివాహిత',
            GENPROFID: 'ప్రొఫైల్ ID',
            GENSAVE: 'సేవ్',
            GENCOPYRT: 'కాపీరైట్',
            GENSANGAM: 'సంగం',
            GENABOUT: 'గురించి',
            LYTSRCH: 'ప్రొఫైల్స్ కోసం శోధన',
            LYTPROFILES: 'ప్రొఫైల్స్',
            LYTSHRTLISPROFILES: 'ప్రొఫైల్స్ నేను ఇష్టపడిన',
            LYTEDITMYPROFILE: 'సవరించు నా ప్రొఫైల్',
            LYTSETTINGS: 'సెట్టింగ్స్',
            LYTUSRHOME: 'వాడుకరి హోమ్',
            LYTPROFDASHBRD: 'ప్రొఫైల్ డాష్బోర్డ్',
            LYTPRFREGFOR: 'ప్రొఫైల్ నమోదు - ప్రొఫైల్ ID కొరకు',
            LYTPRFTABBI: 'ప్రాథమిక సమాచారం',
            LYTPRFTABCAR: 'కెరీర్',
            LYTPRFTABCONT: 'పరిచయం',
            LYTPRFTABFAM: 'కుటుంబ',
            LYTPRFTABLOC: 'స్థానం',
            LYTPRFTABREF: 'సూచన',
            LYTPRFTABHORO: 'జాతకం',
            LYTPRFTABPHO: 'ఫోటో',
            BIBINFREGFRM: 'ప్రాథమిక సమాచారం నమోదు ఫారం',
            BISANGAMUSERID: 'సంగం యూజర్ ID',
            BINAME: 'పేరు',
            BIAGE: 'పేరు',
            BIGEN: 'జెండర్',
            BIDOB: 'పుట్టిన తేది',
            BITOB: 'టైం పుట్టిన',
            BIMARSTATUS: 'వైవాహిక స్థితి',
            BINOOFCHIL: 'నో పిల్లల',
            BICHILLVNGST: 'పిల్లలు నివసిస్తున్న స్థితి',
            BIHEIGHT: 'ఎత్తు',
            BIWEIGHT: 'బరువు',
            BIBDYTPE: 'శరీర తత్వం',
            BICOMPLEXION: 'రంగు',
            BIPHYSTA: 'శరీర స్థితి',
            BIBLGRP: 'రక్తపు గ్రూపు',
            BIMOTONG: 'మాతృ భాష',
            BIPROFCRBY: 'ప్రొఫైల్ రూపొందించినవారు',
            BIRLGN: 'మతం',
            BICST: 'కులం',
            BISUBCST: 'ఉపకులం',
            BIGOTHRM: 'గోత్రం(ఎం)',
            BISTR: 'స్టార్',
            BIRAASI: 'రాసి',
            BIHORMTCH: 'జాతకం మ్యాచ్',
            BIANYDHSM: 'ఏదైనా దోషాలను',
            BIETNG: 'ఆహారపు',
            BISMKNG: 'ధూమపానం',
            BIDRNKNG: 'మద్యపానం',
            BIABTME: 'నా గురించి',
            BIPRTNTEXPTN: 'జీవిత భాగస్వామిలో అంచనాలకు',
            BIHELP: 'ఈ రూపం శోధన ఎవరు అభిప్రాయాలకు ఈ ప్రొఫైల్ ని చూపించడంలో సహాయపడుతుంది ఈ ప్రొఫైల్ గురించి అన్ని ప్రాథమిక సమాచారం సేకరించడానికి ఉపయోగిస్తారు.',
            CRIRF: 'కెరీర్ ఇన్ఫర్మేషన్ నమోదు ఫారం',
            CREDUC: 'చదువు',
            CREDUCDT: 'వివరాలు విద్య',
            CREMPIN: 'పనిచేస్తున్నరంగం',
            CROCCPTN: 'వృత్తి',
            CROCCPTNDTL: 'వృత్తి వివరాలు',
            CRANINC: 'వార్షిక ఆదాయం',
            CRHELP: 'ఈ రూపం ఎడ్యుకేషన్ వివరాలు, ఈ ప్రొఫైల్ వృత్తి వివరాలు గురించి సమాచారాన్ని సేకరించడానికి ఉపయోగిస్తారు',
            CONRF: 'సంప్రదింపు సమాచారం నమోదు ఫారం',
            CONEMAIL: 'ఇమెయిల్',
            CONMOBNO: 'మొబైల్ నంబర్',
            CONLNDNO: 'ల్యాండ్లైన్ సంఖ్య ',
            CONRESADR: 'నివాస చిరునామా',
            CONREL: 'సంబంధం',
            CONTMETOCALL: 'టైం కాల్',
            CONHELP: 'ఈ రూపం ఈ ప్రొఫైల్ గురించి సంప్రదింపు వివరాలు గురించి సమాచారాన్ని సేకరించడానికి ఉపయోగిస్తారు',
            FAMIRF: 'కుటుంబ ఇన్ఫర్మేషన్ నమోదు ఫారం',
            FAMVAL: 'కుటుంబ వ్యాల్యూ',
            FAMTYP: 'కుటుంబ పద్ధతి',
            FAMSTA: 'కుటుంబ హోదా',
            FAMFATNAM: 'తండ్రి పేరు',
            FAMMOTNAM: 'మదర్స్ పేరు',
            FAMFATOCC: 'తండ్రి వృత్తి',
            FAMMOTOCC: 'తల్లి వృత్తి',
            FAMANSFAMORG: 'పూర్వీకుల / ఫ్యామిలీ మూలం',
            FAMNOOFBRO: 'బ్రదర్స్ నో',
            FAMMARDBRO: 'వివాహితులు బ్రదర్స్',
            FAMNOOFSIS: 'సిస్టర్స్ నో',
            FAMMARDSIS: 'వివాహితులు సిస్టర్స్',
            FAMABTFAM: 'కుటుంబం గురించి',
            FAMHELP: 'ఈ రూపం ఈ ప్రొఫైల్ యొక్క కుటుంబం వివరాలు గురించి సమాచారాన్ని సేకరించడానికి ఉపయోగిస్తారు',
            LOCIRF: 'స్థానం ఇన్ఫర్మేషన్ నమోదు ఫారం',
            LOCTRYLVNIN: 'నివసిస్తున్నదేశం లో',
            LOCTNSHP: 'పౌరసత్వం',
            LOCRESSTS: 'నివాస హోదా',
            LOCRESTATE: 'రెసిడెంట్ స్టేట్',
            LOCRESCTY: 'రెసిడెంట్ సిటీ',
            LOCHLP: 'ఈ రూపం ఈ ప్రొఫైల్ గురించి స్థాన సమాచారాన్ని గురించి సమాచారం సేకరించడానికి ఉపయోగిస్తారు',
            REFIRF: 'రిఫరెన్స్ ఇన్ఫర్మేషన్ నమోదు ఫారం',
            REFNOMNAME: 'నామినీ పేరు',
            REFCONTNUM: 'సంఖ్య సంప్రదించండి',
            REFHLP: 'ఈ రూపం ఈ ప్రొఫైల్ కోసం ప్రస్తావనగా ఉంటాయి వ్యక్తుల గురించి సమాచారాన్ని సేకరించడానికి ఉపయోగిస్తారు',
            HOROIRF: 'జాతకం సమాచారం నమోదు ఫారం',
            HORSOORIYAN: 'SOORIYAN',
            HORBUDHAN: 'BUDHAN',
            HORGURU: 'గురు',
            HORKETHU: 'కేతు',
            HORCHANDRAN: 'చంద్రన్',
            HORSUKRAN: 'SUKRAN',
            HORRAGHU: 'రఘు ',
            HORLAGNAM: 'LAGNAM',
            HORSEVAI: 'సేవైకి',
            HORSANI: 'శని',
            PHOIRF: 'ప్రొఫైల్ ఫోటో సమాచారం నమోదు ఫారం',
            PHOHLP: 'ఈ రూపం ప్రొఫైల్ ఈ ప్రొఫైల్ యొక్క / ఆల్బమ్ ఫోటోలను అప్లోడ్ ఉపయోగించారు',
            LYTSRCPROFSRC: 'ప్రొఫైల్ శోధన',
            LYTSRCALLPROF: 'అన్ని ప్రొఫైళ్ళు',
            LYTGENSRC: 'జనరల్ శోధన',
            LYTSGMSRC: 'సంగం శోధన',
            SRCIDPROFID: 'ప్రొఫైల్ ID ద్వారా శోధన',
            SRCIDHLP: 'ఈ రూపం ప్రొఫైల్ ID సేకరించడానికి ఉపయోగిస్తారు మరియు ప్రొఫైల్ సమాచారం ప్రదర్శిస్తుంది, ఉంది',
            SRCGENHLP: 'ఈ రూపం ప్రొఫైల్ ID సేకరించడానికి ఉపయోగిస్తారు మరియు ప్రొఫైల్ సమాచారం ప్రదర్శిస్తుంది, ఉంది',
            SRCSGMSRCH: 'సంగం ద్వారా శోధించండి',
            SRCSGMFLTRBYSGM: 'సంగం ద్వారా వడపోత',
            SRCSGMHLP: 'ఈ రూపం ప్రొఫైల్ ID సేకరించడానికి ఉపయోగిస్తారు మరియు ప్రొఫైల్ సమాచారం ప్రదర్శిస్తుంది, ఉంది',
            VWSGMINFOFORPROFID: 'సంగం ప్రొఫైల్ ID ఫర్ ఇన్ఫర్మేషన్',
            VWRESTXT: 'ఈ ప్రొఫైల్ పూర్తి సమాచారాన్ని వీక్షించడానికి, మీరు ఈ సంగంలో నమోదు వచ్చింది. <br> దయచేసి నమోదు చేయడానికి క్రింద సంగం వివరాలు కనుగొనేందుకు. మీరు నమోదు ఒకసారి, మీరు పూర్తి సమాచారాన్ని యాక్సెస్ చెయ్యగలరు. ',
            VWCTADRS: 'సంప్రదించండి అడ్రస్',
            VWABTSGM: 'సంగం గురించి',
            VWFULLPROFVW: 'ప్రొఫైల్ ID పూర్తి ప్రొఫైల్ చూడండి',
            LYTRCNTLYJNDPROFILES: 'ప్రొఫైల్స్ ఇటీవల చేరారు',
            LYTPROFILESLKDME: 'ప్రొఫైల్స్ నాకు నచ్చింది',
            LYTPROFILESVWDME: 'ప్రొఫైల్స్ నాకు చూచుటకు ',
            LYTPROFILESHGLTD: 'హైలైట్ ప్రొఫైల్స్',
            BIPOB: 'పుట్టిన స్థలం'
        });
        $translateProvider.preferredLanguage('0409');
        /*****************TRANSALATION ENDS HERE ***********************************/


    }]);
})();
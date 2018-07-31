app.controller('IndexController', ['$scope', '$http', 'IndexService', '$location', '$window', '$filter', '$timeout','$q',
    function ($scope, $http, IndexService, $location, $window, $filter,$timeout,$q ) {
       
        var Init = function () {          
        }
        Init();

        $scope.openTypes = function () {
            window.location ='/AppAdministrator/RecordTypes'
        }
        $scope.openUsers = function () {
            window.location = '/AppAdministrator/AllUsers'
        }
        $scope.openMachines = function () {
            window.location = '/AppAdministrator/AllMachines'
        }
    }]);

app.service("IndexService", ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {
    //this.getGetSubtypes = function () {
    //    return $http({
    //        method: 'GET',
    //        url: '/AppAdministrator/GetSubtypes',
    //        contentType: "application/json; charset=utf-8",
    //        //params: {
    //        //    'step': step,
    //        //    'id': id
    //        //},
    //        dataType: "json"
    //    }).then(function (data) {
    //        var deferred = $q.defer();
    //        deferred.resolve(data);
    //        return deferred.promise;
    //    });
    //};


    //this.postSubmitApplication = function (modelPersonalData, recordId) {
    //    return $http.post('/Application/SubmitApplication', { 'inputModel': modelPersonalData, 'id': recordId });
    //}


}]);
﻿app.controller('DetailsController', ['$scope', '$http', 'IndexService', '$location', '$window', '$filter', '$timeout', '$q',
    function ($scope, $http, IndexService, $location, $window, $filter, $timeout, $q) {
        //$scope.helloWorld = "Hello world";
        var Init = function () {
            alert("Helou");
            //console.log();

            IndexService.getGetSubtypes().then(function (response) {
                console.log(response);
            });
        }
        Init();

    }]);

app.service("DetailsService", ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {
    this.getGetSubtypes = function () {
        return $http({
            method: 'GET',
            url: '/AppAdministrator/GetSubtypes',
            contentType: "application/json; charset=utf-8",
            //params: {
            //    'step': step,
            //    'id': id
            //},
            dataType: "json"
        }).then(function (data) {
            var deferred = $q.defer();
            deferred.resolve(data);
            return deferred.promise;
        });
    };


    //this.postSubmitApplication = function (modelPersonalData, recordId) {
    //    return $http.post('/Application/SubmitApplication', { 'inputModel': modelPersonalData, 'id': recordId });
    //}


}]);
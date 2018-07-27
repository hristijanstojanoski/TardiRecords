app.controller('RecordTypesController', ['$scope', '$http', 'RecordTypesService', '$location', '$window', '$filter', '$timeout', '$q',
    function ($scope, $http, RecordTypesService, $location, $window, $filter, $timeout, $q) {

        $scope.initData = null;
        $scope.showNewRecordDiv = false;

        var Init = function () {

            RecordTypesService.getAllObjectsOnInit().then(function (response) {
                $scope.initData = response.data;
                console.log("$scope.initData", $scope.initData);
            });
        }
        Init();
        $scope.showFriendlyDate = function (jDate) {
            return moment(jDate).format("DD/MM/YYYY");
        }
    }]);

app.service("RecordTypesService", ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {
    this.getAllObjectsOnInit = function () {
        return $http({
            method: 'GET',
            url: '/AppAdministrator/GetRecordTypesObjectsAndData',
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
app.controller('RecordTypesController', ['$scope', '$http', 'RecordTypesService', '$location', '$window', '$filter', '$timeout', '$q',
    function ($scope, $http, RecordTypesService, $location, $window, $filter, $timeout, $q) {

        $scope.initData = null;
        $scope.showNewRecordDiv = false;
        $scope.newRecord = {};

        var Init = function () {
            getInitTable();
        }
        Init();
        $scope.showFriendlyDate = function (jDate) {
            return moment(jDate).format("DD/MM/YYYY");
        }

        $scope.deactivateType = function (uid) {
            RecordTypesService.postRecordTypeChangeActive(uid).then(function (response) {
                getInitTable();
            });
        }

        $scope.deleteType = function (uid) {
            RecordTypesService.postDeleteRecordType(uid).then(function (response) {
                getInitTable();
            });
        }

        $scope.addNewRecord = function ()
        {
            RecordTypesService.postNewRecordType($scope.newRecord.TypeName, $scope.newRecord.SubtypeListId).then(function (response) {
                $scope.showNewRecordDiv = !$scope.showNewRecordDiv
                getInitTable();
            });

        }

        function getInitTable() {
            RecordTypesService.getAllObjectsOnInit().then(function (response) {
                $scope.initData = response.data;
                console.log("$scope.initData", $scope.initData);
            });
        }
    }]);

app.service("RecordTypesService", ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {
    this.getAllObjectsOnInit = function () {
        return $http({
            method: 'GET',
            url: '/AppAdministrator/GetRecordTypesObjectsAndData',
            contentType: "application/json; charset=utf-8",           
            dataType: "json"
        }).then(function (data) {
            var deferred = $q.defer();
            deferred.resolve(data);
            return deferred.promise;
        });
    };


    this.postRecordTypeChangeActive = function (recordId) {
        return $http.post('/AppAdministrator/RecordTypeChangeActive', { 'id': recordId });
    }

    this.postDeleteRecordType = function (recordId) {
        return $http.post('/AppAdministrator/DeleteRecordType', { 'id': recordId });
    }

    this.postNewRecordType = function (recordName, recordSubtype) {
        return $http.post('/AppAdministrator/AddOrUpdateRecordType', { 'typeName': recordName, 'subTypeId': recordSubtype });
    }
}]);
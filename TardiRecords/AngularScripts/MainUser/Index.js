app.controller('RecordListsController', ['$scope', '$http', 'RecordListsService', '$location', '$window', '$filter', '$timeout','$q',
    function ($scope, $http, RecordListsService, $location, $window, $filter, $timeout, $q) {

        $scope.initData = null;
        $scope.showNewRecordDiv = false;

        var Init = function () {
           
           
            RecordListsService.getAllObjectsOnInit().then(function (response) {
                $scope.initData = response.data;
                console.log("$scope.initData", $scope.initData);
            });
           
        }
        Init();
        $scope.showFriendlyDate = function (jDate) {
            return moment(jDate).format("DD/MM/YYYY");
        }
    }]);

app.service("RecordListsService", ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {
    this.getAllObjectsOnInit = function () {
        return $http({
            method: 'GET',
            url: '/MainUser/GetRecordListsObjectsAndData',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (data) {
            var deferred = $q.defer();
            deferred.resolve(data);
            return deferred.promise;
        });
    };

}]);
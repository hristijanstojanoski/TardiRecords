app.controller('AllUsersController', ['$scope', '$http', 'AllUsersService', '$location', '$window', '$filter', '$timeout', '$q',
    function ($scope, $http, AllUsersService, $location, $window, $filter, $timeout, $q) {
        $scope.initData = null;
        $scope.showNewRecordDiv = false;
        $scope.emailPattern = /^([a-zA-Z0-9])+([a-zA-Z0-9._%+-])+@([a-zA-Z0-9_.-])+\.(([a-zA-Z]){2,6})$/;
        $scope.newRecord = {};
        var Init = function () {
            getInitTable();
        }
        Init();
        $scope.showFriendlyDate = function (jDate) {
            return moment(jDate).format("DD/MM/YYYY");
        }
        function getInitTable() {
            AllUsersService.getAllObjectsOnInit().then(function (response) {
                $scope.initData = response.data;
                console.log("$scope.initData", $scope.initData);
            });
        }

        $scope.addNewRecord = function () {
            AllUsersService.postNewUserRecord($scope.newRecord).then(function (response) {
                $scope.showNewRecordDiv = !$scope.showNewRecordDiv;
                getInitTable();
            });

        }

        $scope.lockOrUnlockUser = function (id)
        {
            AllUsersService.postLockUnlockUser(id).then(function (response) {
                getInitTable();
            });
        }
    }]);

app.service("AllUsersService", ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {

    this.getAllObjectsOnInit = function () {
        return $http({
            method: 'GET',
            url: '/AppAdministrator/GetAllUsersData',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (data) {
            var deferred = $q.defer();
            deferred.resolve(data);
            return deferred.promise;
        });
    };
    this.postNewUserRecord = function (recordModel) {
        return $http.post('/AppAdministrator/AddNewUser', { 'firstName': recordModel.firstName, 'lastName': recordModel.lastName, 'eMail': recordModel.emailAddress, 'workPosition': recordModel.position});
    }
    this.postLockUnlockUser = function (uid) {
        return $http.post('/AppAdministrator/LockUnlockUser', { 'id': uid });
    }
}]);
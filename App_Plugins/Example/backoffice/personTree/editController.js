angular.module("umbraco").controller("Example.editController", function ($scope, $routeParams, personResource, navigationService, notificationsService) {
    $scope.loaded = false;

    if ($routeParams.id == -1) {
        $scope.person = {};
        $scope.loaded = true;
    } else {
        personResource.GetById($routeParams.id).then(function (response) {
            $scope.person = response.data;
            $scope.loaded = true;
        });
    }
    $scope.save = function (person) {
        personResource.save(person).then(function (response) {
            $scope.person = response.data;
            notificationsService.success("Success ", person.FirstName + " " + person.LastName + " has been saved");
            
        });
    };
    navigationService.syncTree({ tree: 'personTree', path: [-1, $scope.id], forceReload: true }).then(function (syncArgs) {
        navigationService.reloadNode(syncArgs.node);
    });
});
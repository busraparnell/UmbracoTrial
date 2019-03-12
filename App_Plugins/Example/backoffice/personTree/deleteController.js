angular.module("umbraco").controller("PersonDeleteController", function ($scope, personResource, navigationService, notificationsService) {

    $scope.delete = function (id) {
        personResource.deleteById(id).then(function () {
            navigationService.hideNavigation();
            navigationService.syncTree({ tree: 'personTree', path: [-1, $scope.id], forceReload: true }).then(function (syncArgs) {
                navigationService.reloadNode(syncArgs.node);
            });
            notificationsService.success("Successfully deleted");
        });

    };

    $scope.cancelDelete = function () {
        navigationService.hideNavigation();
    };

});
var homeIndexModule = angular.module("homeIndex", ['ngRoute', 'ui.bootstrap']);

homeIndexModule.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);
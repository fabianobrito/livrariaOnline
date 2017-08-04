angular.module('app', ['ngRoute']).config(function ($routeProvider, $locationProvider) {

    $locationProvider.html5Mode(true);
    $routeProvider.when('/livros',
    {
        templateUrl: '/Templates/Livros/index.html',
        controller: 'HomeController'
    });
    $routeProvider.otherwise({ redirectTo: '/livros' });

    $routeProvider.when('/livros/adicionar',
    {
        templateUrl: '/Templates/livros/adicionar.html',
        controller: 'HomeController'
    });
});
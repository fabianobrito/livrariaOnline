angular.module('app').controller('HomeController', function ($scope, $http) {
    $scope.livros = [];
    $http({
        method: 'GET',
        url: 'RetornaTodosOsLivros'
    }).then(function (success) {
        console.log(success.data);
        $scope.livros = success.data;
    }, function (error) {
        console.log(erro);
    });
});
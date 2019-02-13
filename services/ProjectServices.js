(function () {
    homeIndexModule.factory("dataService", function ($http, $q) { //this is a Angular Service.
         var _customers = [];
        var _isInit = false;

        var _isReady = function () {
            return _isInit;
        };

        var _getCustomers = function () {
            var deferred = $q.defer();

            $http.get("/api/Customer")
           .then(function (result) {
                
               angular.copy(result.data, _customers);  
               deferred.resolve();
               //angular.copy(result.data, _customers); 
              
           },
           function (error) {
               handleException(error);
               deferred.reject();
           });
            return deferred.promise;

        };

        function handleException(error) {
            alert(error.data.ExceptionMessage);
        }

        return {
            getCustomers: _getCustomers,
            Customers: _customers,
            cust: {
                FirstName: "hello!",LastName: "joke", CustomerId: 223

            }

        };
    }
    );
}());
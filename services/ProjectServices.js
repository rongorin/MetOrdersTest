(function () {
    homeIndexModule.factory("dataService", function ($http, $q) { //this is a Angular Service.
         var _customers = [];
         var _cust;
         var _isInit = false;

        var _isReady = function () {
            return _isInit;
        };
        var _getCust = function (id) {

            return $http.get("/api/Customer/" + id)   
        }
        var _getCustomers = function () {
            var deferred = $q.defer();

            $http.get("/api/Customer")
           .then(function (result) {  
               angular.copy(result.data, _customers); 
               deferred.resolve();
              
           },
           function (error) {
               handleException(error);
               deferred.reject();
           });
            return deferred.promise;

        };

        //var _addCustomer = function (newCust) {
        //    return $http.get("/api/Customer/Update" + newCust)
        //   // var deferred = $q.defer();
             
        //   //return deferred.promise; 
        //}
        var _insertCustomer = function (newcustomer) { 
            return $http.post("/api/Customer/Post", newcustomer) 
        };
 
        var _updateCustomer = function (customer) { 
            var request = $http({
                method: "put",
                url: "/api/Customer/Put",
                data: customer
            });
            return request;  // $http.post("/api/Customer/Update", customer);
        }; 

        var _deleteCustomer = function (CustomerId) {
            var request = $http({
                method: "delete",
                url: "/api/Customer/Delete/" + CustomerId ,
                data: CustomerId
            });
            return request;  // $http.post("/api/Customer/Update", customer);
        };

        function handleException(error) {
            alert(error.data.ExceptionMessage);
        }

        return {
            getCustomers: _getCustomers,
            getCust: _getCust,
            Customers: _customers,
            Customer: _cust,
            cust: {
                FirstName: "hello!",LastName: "joke", CustomerId: 223

            },
            //addCustomer: _addCustomer,
            insertCustomer: _insertCustomer,
            updateCustomer: _updateCustomer,
            deleteCustomer: _deleteCustomer
        };
    }
    );
}());
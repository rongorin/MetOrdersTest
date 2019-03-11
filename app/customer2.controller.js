 

 //var homeIndexModule = angular.module("homeIndex", ['ngRoute']);  this is define in app.js
 
(function () {

    var CustomerController = function ($scope, $location, dataService)
    { 
		$scope.Message = "The Customer Listing";
		
		var customers = []; 
		   
		$scope.Customers = dataService.Customers;
		dataService.getCustomers()
		  .then(function (results) { 
		      //success     
		},
		    function () { 
		        alert("cant load Customers!!.");
                
		 });
		$scope.createEmployeeForm = function () {
		    $location.path('/CustCreate');


		}; 
	
	};
	homeIndexModule.controller("CustomerController", CustomerController);

	var CustomerEditCreateController = function ($scope, $routeParams, $window, dataService) {
	    //if ($routeParams.id)
                 
	    $scope.Message = "Editing...";
	   
	    //$scope.Cust = dataServic  e.Customer;

	    if ($routeParams.id)
	       dataService.getCust($routeParams.id)
               .then(function (results) {  //the http returns us a Promise here.
                   $scope.Cust = results.data; 
               }), 
	        function () {
	            alert("cant load Customers.");
	     };
	       
	    $scope.saveForm = function (id) { 
	        if (id != null)
	        { 
	            // update the cust
	            dataService.updateCustomer($scope.Cust).then(
                    function (results) {
                        // on success
                        $scope.employee = angular.copy($scope.Cust); 
                        $window.history.back();
                    },
                    function (results) {
                        // on error
                        $scope.hasFormError = true;
                        $scope.formErrors = results.statusText;
                    });

	        }
	        else { //add new  
	            dataService.insertCustomer($scope.Cust).then(
                    function (results) {
                        // on success 
                        $scope.Cust = angular.copy($scope.Cust);
                        $scope.Cust.CustomerId = results.data; 
                        $window.history.back();
                    },
                    function (results) {
                        // on error
                        $scope.hasFormError = true;
                        $scope.formErrors = results.statusText;
                    });

	        }
             
	    };
	};
	homeIndexModule.controller("CustomerEditCreateController", CustomerEditCreateController);

	var CustomerDeleteController = function ($scope, $window, $routeParams, $location, dataService) {
	    $scope.Message = "Customer Delete";
	    alert($routeParams.id);
	    if ($routeParams.id)
	        dataService.deleteCustomer($routeParams.id)
                .then(function (results) {  //the http returns us a Promise here. 
                    alert(results.data); 
                    $window.history.back();
                }),
             function () {
                 alert("cant load Customers.");
             }; 
	};
	homeIndexModule.controller("CustomerDeleteController", CustomerDeleteController);

}()); 

homeIndexModule.config(function ($routeProvider) {
    $routeProvider.when("/CustListing", {
        controller: "CustomerController",
		templateUrl: "/app/templates/CustomerList.html"
	}); 
    $routeProvider.when("/CustEdit/:id", {
        controller: "CustomerEditCreateController",
	    templateUrl: "/app/templates/CustomerEdit.html"
    });
    $routeProvider.when("/CustCreate/", {
        controller: "CustomerEditCreateController",
        templateUrl: "/app/templates/CustomerEdit.html"
    });
    $routeProvider.when("/CustDelete/:id", {
        controller: "CustomerDeleteController",
        templateUrl: "/app/templates/CustomerList.html"
    });
    $routeProvider.otherwise({ redirectTo: "/CustListing" });


});
 
 

 //var homeIndexModule = angular.module("homeIndex", ['ngRoute']);  this is define in app.js
 
(function () {
	var CustomerController = function ($scope, $http, dataService) {
	    alert("my js controller is called");
		$scope.Message = "WelCome to Customercontroller!";
		
		var customers = []; 
		 
		$scope.Customers = dataService.Customers;
		dataService.getCustomers()
		  .then(function () {
			//success
		},
		function () { 
			alert("cant load Customers.");
		});
		// var customers = [{ FirstName: "aaaa", LastN,ame: "mylastname", CustomerId: 1 } ];
		//function customerList() {
		//	$http.get("/api/Customer")
		//	.then(function (result) { 
		//		angular.copy(result.data, customers); 
		//	},
		//	function (error) {
		//	 		alert("cant load custs.");
		//	});
		//}
		//$scope.Customers = customers;

	
	};
	homeIndexModule.controller("CustomerController", CustomerController);
     
}()); 

homeIndexModule.config(function ($routeProvider) {
    $routeProvider.when("/Customer/Index2/Customer", {
        controller: "CustomerController",
		templateUrl: "/app/templates/CustomerList.html"
	});
	//$routeProvider.when("/newmessage", {
	//	controller: "newTopicController",
	//	templateUrl: "/templates/newTopicView.html"
	//});
	//$routeProvider.when("/message/:id", {
	//	controller: "singleTopicController",	
	//	templateUrl: "/templates/singleTopicView.html"
	//});

    $routeProvider.otherwise({ redirectTo: "/Customer/Index2/Customer" });


});
 
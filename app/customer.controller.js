(function () {
    'use strict';
    angular.module('app')
            .controller('CustomerController', CustomerController);

    function CustomerController($http)
    { 
        var vm = this;
        vm.Message = "T  Listing";

        vm.customer =
            {
                firstname: "Ron",
                lastname: "Gorin"
            };

        var dataService = $http;
        vm.customers = [];

        productList();
        vm.editClick = editClick;

        //---------------------------------------

		

        function editClick(id) {
            //alert("ddd");
            customerGet(id);

        }
        function productList() {
            dataService.get("/api/Customer")
			.then(function (result) {
			    vm.customers = result.data;

			    //setUIState(pageMode.LIST);  //For the state
			},
			function (error) {
			    handleException(error);
			});
        }
        //function productList() {
        //    $scope.data = myDataService;

        //    myDataService.getCustomers()
		//	.then(function (result) {
		//	    vm.customers = result.data;

		//	    //setUIState(pageMode.LIST);  //For the state
		//	},
		//	function (error) {
		//	    handleException(error);
		//	});
        //}
        function customerGet(id) {
            // Call Web API to get a product
            dataService.get("/api/Customer/" + id)
              .then(function (result) {

                  // Display product
                  vm.customers = result.data;

                  //// Convert date to local date/time format
                  //if (vm.product.IntroductionDate != null) {
                  //    vm.product.IntroductionDate =
                  //      new Date(vm.product.IntroductionDate).
                  //      toLocaleDateString();
                  //    alert(vm.product.IntroductionDate);

                  //}
              }, function (error) {
                  handleException(error);
              });
        }
        function handleException(error) {
            alert(error.data.ExceptionMessage);
        }
    }

    //--------------------      
    

    })(); 
 
(function () {
	var EmployeesController = function ($scope) {

		var employees = [{ employeeName: "Books", designation: "Project Manager"},
						 { employeeName: "Pencils", designation: "Project Managerss" }];


		//var employees = {
		//	employeeName: "John Richard",
		//	designation: "Project Manager",
		//	contactNo: "+333 3888389",
		//	eMailID: "john@projects.com",
		//	skillSets: "ASP.NET, ASP.NET MVC"
		//};
		$scope.Title = "Employee Details Pages";
		$scope.Employees = employees;
	};
	homeIndexModule.controller("EmployeesController", EmployeesController);
	 
}());

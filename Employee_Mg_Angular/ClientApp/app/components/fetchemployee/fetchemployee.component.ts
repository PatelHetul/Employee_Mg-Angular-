import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { DepartmentService } from '../../services/Depservice.service';

@Component({
	templateUrl: './fetchemployee.component.html'
})

export class FetchEmployeeComponent {

	public empList: EmployeeData[];

	constructor(public http: Http, private _router: Router, private _departmentService: DepartmentService) {
		this.getEmployees();
	}

	getEmployees() {
		this._departmentService.getEmployees().subscribe(
			data => this.empList = data
		)
	}

	delete(employeeID) {
		var ans = confirm("Do you want to delete Employee with Id: " + employeeID);
		if (ans) {
			this._departmentService.deleteEmployee(employeeID).subscribe((data) => {
				this.getEmployees();
			}, error => console.error(error))
		}
	}
}

interface EmployeeData {
	employee_Id: number;
	employee_Name: string;
	department_Id: number;
	joiningDate: Date;
	address: string;
	email: string;
	mobileNo: string;	

}
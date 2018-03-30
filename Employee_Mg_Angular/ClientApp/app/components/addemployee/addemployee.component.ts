import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchEmployeeComponent } from '../fetchemployee/fetchemployee.component';
import { DepartmentService } from '../../services/Depservice.service';

@Component({
	templateUrl: './addemployee.component.html'
})

export class createemployee implements OnInit {
	employeeForm: FormGroup;
	title: string = "Create";
	employee_Id: number;
	errorMessage: any;
	departList: Array<any> = [];

	constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
		private _departmentService: DepartmentService, private _router: Router) {
		if (this._avRoute.snapshot.params["id"]) {
			this.employee_Id = this._avRoute.snapshot.params["id"];
		}

		this.employeeForm = this._fb.group({
			employee_Id: 0,
			employee_Name: ['', [Validators.required]],
			department_Id: ['', [Validators.required]],
			joiningDate: ['', [Validators.required]],
			address: ['', [Validators.required]],
			email: ['', [Validators.required]],
			mobileNo: ['', [Validators.required]],
			
		})
	}

	ngOnInit() {

		this._departmentService.getDepartmentsList().subscribe(
			data => this.departList = data
		)

		if (this.employee_Id > 0) {
			this.title = "Edit";
			this._departmentService.getEmployeeById(this.employee_Id)
				.subscribe(resp => this.employeeForm.setValue(resp)
				, error => this.errorMessage = error);
		}

	}

	save() {

		if (!this.employeeForm.valid) {
			return;
		}

		if (this.title == "Create") {
			this._departmentService.saveEmployee(this.employeeForm.value)
				.subscribe((data) => {
					this._router.navigate(['/fetch-employee']);
				}, error => this.errorMessage = error)
		}
		else if (this.title == "Edit") {
			this._departmentService.updateEmployee(this.employeeForm.value)
				.subscribe((data) => {
					this._router.navigate(['/fetch-employee']);
				}, error => this.errorMessage = error)
		}
	}

	cancel() {
		this._router.navigate(['/fetch-employee']);
	}

	get employee_Name() { return this.employeeForm.get('employee_Name'); }
	get joiningDate() { return this.employeeForm.get('joiningDate'); }
	get address() { return this.employeeForm.get('address'); }
	get email() { return this.employeeForm.get('email'); }
	get mobileNo() { return this.employeeForm.get('mobileNo'); }
	get department_Id() { return this.employeeForm.get('department_Id'); }
}
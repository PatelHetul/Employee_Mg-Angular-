
import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class DepartmentService {
	myAppUrl: string = "";

	constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
		this.myAppUrl = baseUrl;
	}
	getDepartments() {
		return this._http.get(this.myAppUrl + 'api/Department/Index')
			.map((response: Response) => response.json())
			.catch(this.errorHandler);
	}

	getDepartmentById(id: number) {
		return this._http.get(this.myAppUrl + "api/Department/Details/" + id)
			.map((response: Response) => response.json())
			.catch(this.errorHandler)
	}

	saveDepartment(department) {
		return this._http.post(this.myAppUrl + 'api/Department/Create', department)
			.map((response: Response) => response.json())
			.catch(this.errorHandler)
	}

	updateDepartment(department) {
		return this._http.put(this.myAppUrl + 'api/Department/Edit', department)
			.map((response: Response) => response.json())
			.catch(this.errorHandler);
	}

	deleteDepartment(id) {
		return this._http.delete(this.myAppUrl + "api/Department/Delete/" + id)
			.map((response: Response) => response.json())
			.catch(this.errorHandler);
	}


	//Employees Data

	getDepartmentsList() {
		return this._http.get(this.myAppUrl + 'api/Employee/GetDepartment')
			.map(res => res.json())
			.catch(this.errorHandler);
	}

	getEmployees() {
		return this._http.get(this.myAppUrl + 'api/Employee/Index')
			.map((response: Response) => response.json())
			.catch(this.errorHandler);
	}

	getEmployeeById(id: number) {
		return this._http.get(this.myAppUrl + "api/Employee/Details/" + id)
			.map((response: Response) => response.json())
			.catch(this.errorHandler)
	}

	saveEmployee(employee) {
		return this._http.post(this.myAppUrl + 'api/Employee/Create', employee)
			.map((response: Response) => response.json())
			.catch(this.errorHandler)
	}

	updateEmployee(employee) {
		return this._http.put(this.myAppUrl + 'api/Employee/Edit', employee)
			.map((response: Response) => response.json())
			.catch(this.errorHandler);
	}

	deleteEmployee(id) {
		return this._http.delete(this.myAppUrl + "api/Employee/Delete/" + id)
			.map((response: Response) => response.json())
			.catch(this.errorHandler);
	}

	errorHandler(error: Response) {
		console.log(error);
		return Observable.throw(error);
	}  
}
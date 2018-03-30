import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { DepartmentService } from '../../services/Depservice.service'

@Component({
	selector: 'fetchdepartment',
	templateUrl: './fetchdepartment.component.html'
})

export class FetchDepartmentComponent {
	public depList: DepartmentData[];

	constructor(public http: Http, private _router: Router, private _departmentService: DepartmentService) {
		this.getDepartments();
	}
	getDepartments() {
		this._departmentService.getDepartments().subscribe(
			data => this.depList = data
		)
	}

	delete(id) {
		var ans = confirm("Do you want to delete Department with Id: " + id);
		if (ans) {
			this._departmentService.deleteDepartment(id).subscribe((data) => {
				this.getDepartments();
			}, error => console.error(error))
		}
	}

}
interface DepartmentData {
	id: number;
	name: string;
	
}
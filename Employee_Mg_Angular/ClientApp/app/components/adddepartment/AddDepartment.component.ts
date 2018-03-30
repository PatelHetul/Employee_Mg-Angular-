import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchDepartmentComponent } from '../fetchdepartment/fetchdepartment.component';
import { DepartmentService } from '../../services/Depservice.service';

@Component({
	selector: 'createdepartment',
	templateUrl: './AddDepartment.component.html'
})


export class createdepartment implements OnInit {
	departmentForm: FormGroup;
	title: string = "Create";
	id: number;
	errorMessage: any;

	constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
		private _departmentService: DepartmentService, private _router: Router) {
		if (this._avRoute.snapshot.params["id"]) {
			this.id = this._avRoute.snapshot.params["id"];
		}

		this.departmentForm = this._fb.group({
			id: 0,
			name: ['', [Validators.required]]
		})
	}

	ngOnInit() {
		if (this.id > 0) {
			this.title = "Edit";
			this._departmentService.getDepartmentById(this.id)
				.subscribe(resp => this.departmentForm.setValue(resp)
				, error => this.errorMessage = error);
		}
	}

	save() {

		if (!this.departmentForm.valid) {
			return;
		}

		if (this.title == "Create") {
			this._departmentService.saveDepartment(this.departmentForm.value)
				.subscribe((data) => {
					this._router.navigate(['/fetch-department']);
				}, error => this.errorMessage = error)
		}
		else if (this.title == "Edit") {
			this._departmentService.updateDepartment(this.departmentForm.value)
				.subscribe((data) => {
					this._router.navigate(['/fetch-department']);
				}, error => this.errorMessage = error)
		}
	}

	cancel() {
		this._router.navigate(['/fetch-department']);
	}

	get name() { return this.departmentForm.get('name'); }
}
import { NgModule } from '@angular/core';
import { DepartmentService } from './services/Depservice.service'
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';  

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDepartmentComponent } from './components/fetchdepartment/fetchdepartment.component'
import { createdepartment } from './components/adddepartment/AddDepartment.component'
import { FetchEmployeeComponent } from './components/fetchemployee/fetchemployee.component'
import { createemployee } from './components/addemployee/addemployee.component'


@NgModule({
	declarations: [
		AppComponent,
		NavMenuComponent,
		HomeComponent,
		FetchDepartmentComponent,
		createdepartment,
		FetchEmployeeComponent,
		createemployee,
	],  
	imports: [
		CommonModule,
		HttpModule,
		FormsModule,
		ReactiveFormsModule,
		RouterModule.forRoot([
			{ path: '', redirectTo: 'home', pathMatch: 'full' },
			{ path: 'home', component: HomeComponent },
			{ path: 'fetch-department', component: FetchDepartmentComponent },
			{ path: 'register-department', component: createdepartment },
			{ path: 'department/edit/:id', component: createdepartment },
			{ path: 'fetch-employee', component: FetchEmployeeComponent },
			{ path: 'register-employee', component: createemployee },
			{ path: 'employee/edit/:id', component: createemployee },
			{ path: '**', redirectTo: 'home' }
		])
	],
	providers: [DepartmentService]
})
export class AppModuleShared {
}

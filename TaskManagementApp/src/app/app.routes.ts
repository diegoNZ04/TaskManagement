import { Routes } from '@angular/router';
import { ManagementPanelComponent } from './pages/management-panel/management-panel.component';
import { TaskFormInputComponent } from './components/task-form-input/task-form-input.component';

export const routes: Routes = [
  { path: '', redirectTo: '/management-panel', pathMatch: 'full' },
  { path: 'management-panel', component: ManagementPanelComponent },
  { path: 'task-form-input', component: TaskFormInputComponent }
];

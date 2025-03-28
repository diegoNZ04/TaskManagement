import { Routes } from '@angular/router';
import { ManagementPanelComponent } from './pages/management-panel/management-panel.component';

export const routes: Routes = [
  { path: '', redirectTo: '/management-panel', pathMatch: 'full' },
  { path: 'management-panel', component: ManagementPanelComponent },
];

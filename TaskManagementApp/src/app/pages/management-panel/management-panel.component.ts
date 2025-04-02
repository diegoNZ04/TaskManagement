import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { ReactiveFormsModule } from '@angular/forms';
import Task from '../../interfaces/task';
import { TaskFormInputComponent } from '../../components/task-form-input/task-form-input.component';
import { TaskListComponent } from "../../components/task-list/task-list.component";
import Subtask from '../../interfaces/subtask';


@Component({
  selector: 'app-management-panel',
  imports: [CommonModule,
    FormsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatIconModule,
    MatListModule,
    ReactiveFormsModule,
    MatButtonToggleModule,
    TaskFormInputComponent, TaskListComponent],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './management-panel.component.html',
  styleUrl: './management-panel.component.css'
})
export class ManagementPanelComponent implements OnInit {
  tasks: Task[] = [];

  ngOnInit() {
    this.tasks = [];
  }

  handleAddTask(task: Task) {
    this.tasks = [...this.tasks, task];
  }

  handleAddSubtask(event: { taskIndex: number; subtask: Subtask }) {
    this.tasks[event.taskIndex].subtasks.push(event.subtask);
  }
}

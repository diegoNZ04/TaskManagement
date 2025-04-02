import { ChangeDetectionStrategy, Component, EventEmitter, Output } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import Task from '../../interfaces/task';

@Component({
  selector: 'app-task-form-input',
  imports: [
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    FormsModule,
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './task-form-input.component.html',
  styleUrl: './task-form-input.component.css'
})
export class TaskFormInputComponent {

  @Output() addTask = new EventEmitter<Task>();
  newTask: Task = { title: '', description: '', completed: false, subtasks: [] };

  submitTask() {
    if (this.newTask.title.trim()) {
      this.addTask.emit(this.newTask);
      this.newTask = { title: '', description: '', completed: false, subtasks: [] }
    }
  }
}

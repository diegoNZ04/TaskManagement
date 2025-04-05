import { ChangeDetectionStrategy, Component, EventEmitter, Inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import Task from '../../interfaces/task';
import Priority from '../../interfaces/priority';

@Component({
  selector: 'app-task-form-input',
  imports: [
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    MatSelectModule
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './task-form-input.component.html',
  styleUrl: './task-form-input.component.css'
})
export class TaskFormInputComponent {
  newTask: Task = this.createEmptyTask();

  constructor(
    private dialogRef: MatDialogRef<TaskFormInputComponent>
  ) { }

  submitTask(): void {
    if (this.newTask.title.trim()) {
      this.dialogRef.close(this.newTask);
    }
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

  private createEmptyTask(): Task {
    return {
      title: '',
      description: '',
      isCompleted: false,
      priority: '',
      completedAt: null,
      subtasks: []
    };
  }

  priorityOptions: Priority[] = [
    { value: 'high', viewValue: 'High' },
    { value: 'medium', viewValue: 'Medium' },
    { value: 'low', viewValue: 'Low' }
  ];
}

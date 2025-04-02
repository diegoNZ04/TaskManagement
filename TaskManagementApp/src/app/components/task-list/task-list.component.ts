import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { FormsModule } from '@angular/forms';
import Task from '../../interfaces/task';
import Subtask from '../../interfaces/subtask';

@Component({
  selector: 'app-task-list',
  imports: [
    FormsModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatListModule,
    CommonModule
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent {
  @Input() tasks: Task[] = [];

  @Output() addSubTask = new EventEmitter<{ taskIndex: number; subtask: Subtask }>();
  newSubtask: { [key: number]: string } = {};

  submitSubTask(taskIndex: number) {
    const title = this.newSubtask[taskIndex]?.trim();
    if (title) {
      this.addSubTask.emit({ taskIndex, subtask: { title, completed: false } });
      this.newSubtask[taskIndex] = '';
    }
  }
}

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import Task from '../../interfaces/task';
import Subtask from '../../interfaces/subtask';

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
  tasks: Task[] = [];

  newTask: Task = {
    title: '',
    description: '',
    completed: false,
    subtasks: []
  };
  newSubtaskTitle: string = '';

  ngOnInit() {
    // Add some sample tasks
    this.tasks = [
      {
        title: 'Complete Project Proposal',
        description: 'Write and submit the project proposal document',
        completed: false,
        subtasks: [
          { title: 'Research requirements', completed: true },
          { title: 'Create outline', completed: false }
        ]
      }
    ];
  }

  addTask() {
    if (this.newTask.title.trim()) {
      this.tasks.push({
        ...this.newTask,
        subtasks: []
      });
      this.newTask = {
        title: '',
        description: '',
        completed: false,
        subtasks: []
      };
    }
  }

  addSubtask(taskIndex: number) {
    if (this.newSubtaskTitle.trim()) {
      this.tasks[taskIndex].subtasks.push({
        title: this.newSubtaskTitle,
        completed: false
      });
      this.newSubtaskTitle = '';
    }
  }
}

import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { ReactiveFormsModule } from '@angular/forms';

interface Subtask {
  title: string;
  completed: boolean;
}

interface Task {
  title: string;
  description: string;
  completed: boolean;
  subtasks: Subtask[];
}

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
    ReactiveFormsModule],
  templateUrl: './management-panel.component.html',
  styleUrl: './management-panel.component.css'
})
export class ManagementPanelComponent {
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

import { ChangeDetectionStrategy, ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { ReactiveFormsModule } from '@angular/forms';
import Task from '../../interfaces/task';
import { TaskFormInputComponent } from '../../components/task-form-input/task-form-input.component';
import { TaskListComponent } from "../../components/task-list/task-list.component";
import Subtask from '../../interfaces/subtask';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-management-panel',
  imports: [CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    TaskListComponent
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './management-panel.component.html',
  styleUrl: './management-panel.component.css'
})
export class ManagementPanelComponent implements OnInit {
  readonly dialog = inject(MatDialog);
  private cdr = inject(ChangeDetectorRef);

  tasks: Task[] = [];

  ngOnInit() {
    this.tasks = [];
  }

  handleAddSubtask(event: { taskIndex: number; subtask: Subtask }) {
    this.tasks[event.taskIndex].subtasks.push(event.subtask);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(TaskFormInputComponent);

    dialogRef.afterClosed().subscribe((result: Task) => {
      if (result) {
        this.tasks = [...this.tasks, result];
        this.cdr.detectChanges();
      }
    });
  }
}

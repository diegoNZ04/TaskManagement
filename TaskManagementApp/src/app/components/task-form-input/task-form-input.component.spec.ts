import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskFormInputComponent } from './task-form-input.component';

describe('TaskFormInputComponent', () => {
  let component: TaskFormInputComponent;
  let fixture: ComponentFixture<TaskFormInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TaskFormInputComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TaskFormInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

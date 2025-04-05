import Subtask from "./subtask";

export default interface Task {
  title: string;
  description: string;
  isCompleted: boolean;
  priority: string;
  completedAt: Date | null;
  subtasks: Subtask[];
}

import Subtask from "./subtask";

export default interface Task {
  title: string;
  description: string;
  completed: boolean;
  subtasks: Subtask[];
}

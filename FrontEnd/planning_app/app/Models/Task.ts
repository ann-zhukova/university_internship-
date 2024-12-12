interface Task {
    id: number;
    name: string;
    description: string;
    startDate: string;
    endDate: string;
    status: boolean;
    dependsOnTask: TaskDepends;
    project: TaskProject;
    workers: TaskWorker[];
}
interface TaskDepends{
    id: number;
    name: string;
}
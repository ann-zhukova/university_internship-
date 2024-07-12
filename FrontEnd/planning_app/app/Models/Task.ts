interface Task {
    id: number;
    name: string;
    description: string;
    startDate: string;
    endDate: string;
    status: boolean;
    dependsOnTask: string;
    project: string;
    workers: string[];
}
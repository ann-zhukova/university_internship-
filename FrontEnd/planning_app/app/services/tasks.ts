export interface TaskRequest{
    name : string;
    status: boolean;
}
export const getAllTasks = async() => {
    const response = await fetch("http://localhost:5081/TaskControllers");
    return response.json();
}
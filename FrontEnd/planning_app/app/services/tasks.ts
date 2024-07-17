export interface TaskRequest {
    name: string;
    description?: string;
    startDate?: string;
    endDate?: string;
    status?: boolean;
    dependsOnTask?: number;
    project?: number;
    workers?: number[];
  }
export const getAllTasks = async() => {
    const response = await fetch("http://localhost:5081/TaskControllers");
    return response.json();
}

export const createTask = async(taskRequest:TaskRequest) => {
    const formData = new FormData();
    formData.append('name', taskRequest.name);
    formData.append('status', taskRequest.status ? 'true' : 'false');
    formData.append('description', taskRequest.description ?? '');
    formData.append('startDate', taskRequest.startDate ?? '');
    formData.append('endDate', taskRequest.endDate ?? '');
    if (taskRequest.dependsOnTask !== undefined) {
      formData.append('dependsOnTask', taskRequest.dependsOnTask.toString());
    }
    if (taskRequest.project !== undefined) {
      formData.append('project', taskRequest.project.toString());
    }
    if (taskRequest.workers !== undefined) {
      taskRequest.workers.forEach(worker => {
        formData.append('workers', worker.toString());
      });
    }
    const response = await fetch("http://localhost:5081/TaskControllers",
        {
            method : "POST",
            body: formData,
        }
    );
    return response;
}

export const updateTask = async(id: number ,taskRequest:TaskRequest) => {
    const formData = new FormData();
    formData.append('name', taskRequest.name);
    formData.append('status', taskRequest.status ? 'true' : 'false');
    formData.append('description', taskRequest.description ?? '');
    formData.append('startDate', taskRequest.startDate ?? '');
    formData.append('endDate', taskRequest.endDate ?? '');
    if (taskRequest.dependsOnTask !== undefined) {
      formData.append('dependsOnTask', taskRequest.dependsOnTask.toString());
    }
    if (taskRequest.project !== undefined) {
      formData.append('project', taskRequest.project.toString());
    }
    if (taskRequest.workers !== undefined) {
      taskRequest.workers.forEach(worker => {
        formData.append('workers', worker.toString());
      });
    }
    const response = await fetch(`http://localhost:5081/TaskControllers/${id}`,
        {
            method : "PUT",
            body: formData,
        }
    );
    return response;
}

export const deleteTask = async(id: number) => {
    const response = await fetch(`http://localhost:5081/TaskControllers/${id}`,
        {
            method : "DELETE",
        }
    );
    return response;
}
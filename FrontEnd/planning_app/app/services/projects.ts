export interface ProjectRequest{
    name : string;
    status: boolean;
}
export const getAllProjects = async() => {
    const response = await fetch("http://localhost:5081/ProjectControllers");
    return response.json();
}

export const createProject = async(projectRequest:ProjectRequest) => {
    const formData = new FormData();
    formData.append('name',projectRequest.name );
    formData.append('status', projectRequest.status.toString());
    const response = await fetch("http://localhost:5081/ProjectControllers",
        {
            method : "POST",
            body: formData,
        }
    );
    return response;
}

export const updateProject = async(id: number ,projectRequest:ProjectRequest) => {
    const formData = new FormData();
    formData.append('name',projectRequest.name );
    formData.append('status', projectRequest.status.toString());
    const response = await fetch(`http://localhost:5081/ProjectControllers/${id}`,
        {
            method : "PUT",
            body: formData,
        }
    );
    return response;
}

export const deleteProject = async(id: number) => {
    const response = await fetch(`http://localhost:5081/ProjectControllers/${id}`,
        {
            method : "DELETE",
        }
    );
    return response;
}
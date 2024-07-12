export const getAllProjects = async() => {
    const response = await fetch("http://localhost:5081/ProjectControllers");
    return response.json();
}
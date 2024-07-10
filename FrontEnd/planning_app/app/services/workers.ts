export const getAllWorkers = async() => {
    const response = await fetch("http://localhost:5081/WorkerControllers");
    return response.json();
}
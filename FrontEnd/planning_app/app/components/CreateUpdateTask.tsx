import Modal from "antd/es/modal/Modal"
import Input from "antd/es/input/Input"
import Checkbox from "antd/es/checkbox/Checkbox"
import Option from "antd/es/select"
import  Select  from 'antd/es/select';
import { TaskRequest } from "../services/tasks";
import {useEffect ,useState } from "react";
import TextArea from "antd/es/input/TextArea";
import { ProjectRequest } from "../services/projects";
import {  getAllProjects } from "../services/projects";
import { getAllWorkers } from "../services/workers";
interface Props{
    mode:Mode;
    values:Task;
    isModalOpen: boolean;
    handleCancel: ()=>void;
    handleCreate:(request: TaskRequest) => void;
    handleUpdate: (id: number, request: TaskRequest) => void;
}

export enum Mode{
    Create,
    Edit,
}


export const CreateUpdateTask = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}:Props) => {
    const [name, setName] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    const [startDate, setStartDate] = useState<string>("");
    const [endDate, setEndDate] = useState<string>("");
    const [status, setStatus] = useState<boolean>(false);
    const [dependsOnTask, SetDependsOnTask] = useState<TaskDepends>();
    const [project, setProject] = useState<TaskProject>();
    const [workers, setWorkers] = useState<TaskWorker[]>([]);
    const [options, setOptions] = useState<Project[]>([]);
    const [optionsWorker, setOptionsWorker] = useState<Worker[]>([]);
    useEffect(() => {
        const fetchProjects = async () => {
            setName(values.name);
            setDescription(values.description);
            setStartDate(values.startDate);
            setEndDate(values.endDate);
            setStatus(values.status);
            SetDependsOnTask(values.dependsOnTask);
            setProject(values.project);
            setWorkers(values.workers);
            const projects = await getAllProjects();
            setOptions(projects);
            const all_workers = await getAllWorkers();
            setOptionsWorker(all_workers);
        };

        fetchProjects();
    }, [values]);

    const handleOnOk = async()=>{
        const project_id = project?.id;
        const workers_id = workers.map(worker => worker.id);
        const dependsId = dependsOnTask?.id;
        const TaskRequest = {name, description,  startDate, endDate, status, depends : dependsId, project : project_id, workers :  workers_id };
        console.log(TaskRequest)
        mode == Mode.Create ? handleCreate(TaskRequest): handleUpdate(values.id, TaskRequest);
    };
    const handleChange = (value: string) => {
        const selectedOption = options.find(option => option.name === value);
        if (selectedOption) {
            setProject({ id: selectedOption.id, name: selectedOption.name });
        }
    };
    const handleChangeWorkers = (values: string[]) => {
        const selectedWorkers = values.map(value => {
            const selectedOption = optionsWorker.find(option => option.name === value);
            return selectedOption ? { id: selectedOption.id, name: selectedOption.name } : null;
        }).filter(worker => worker !== null); 
    
        setWorkers(selectedWorkers); 
        console.log(workers);
    };
    return(
        <Modal 
            title={
                mode === Mode.Create ? "Добавить задачу" : "Редактировать задачу"
            }
            open = {isModalOpen}
            cancelText={"Отмена"}
            onOk={handleOnOk}
            onCancel = {handleCancel}

        >
           <div className = "modal">
                <Input
                    value = {name}
                    onChange = {(e) => setName(e.target.value)}
                    placeholder = "Название"
                />
                <TextArea
                    value = {description}
                    onChange = {(e) => setDescription(e.target.value)}
                      placeholder = "Описание"
                />
                <Input
                    value = {startDate}
                    onChange = {(e) => setStartDate(e.target.value)}
                    placeholder = "Дата начала"
                />
                <Input
                    value = {endDate}
                    onChange = {(e) => setEndDate(e.target.value)}
                    placeholder = "Дата завершения"
                />
                 <Select
                    value={project?.name}
                    placeholder="Выберите опцию"
                    onChange={handleChange}
                >
                    {options.map(option => (
                        <Option key={option.id} value={option.name}>
                            {option.name}
                        </Option>
                    ))}
                </Select>
                <Select
                    mode="multiple" 
                    placeholder="Выберите работников"
                    value={workers?.map(worker => worker.name)}
                    onChange={handleChangeWorkers}
                >
                    {optionsWorker.map(option => (
                        <Option key={option.id} value={option.name}>
                            {option.name}
                        </Option>
                    ))}
                </Select>
                <Checkbox
                    checked={status} // Bind the checkbox state
                    onChange={(e) => setStatus(e.target.checked)} // Update state based on checkbox status
                >
                    Статус
                </Checkbox>

            </div> 
        </Modal>
    )
}
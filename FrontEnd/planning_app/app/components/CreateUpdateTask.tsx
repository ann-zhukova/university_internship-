import Modal from "antd/es/modal/Modal"
import Input from "antd/es/input/Input"
import { TaskRequest } from "../services/tasks";
import {useEffect ,useState } from "react";
import TextArea from "antd/es/input/TextArea";
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
    const[dependsOnTask, SetDependsOnTask] = useState<number>(0);
    const [project, setProject] = useState<number>(0);
    const [workers, setWorkers] = useState<number[]>([]);

    useEffect(()=> {
        setName(values.name);
        setDescription(values.description);
        setStartDate(values.startDate);
        setEndDate(values.endDate);
        setStatus(values.status);
    }, [values]);
    const handleOnOk = async()=>{
        const TaskRequest = {name, description,  startDate, endDate, status};
        mode == Mode.Create ? handleCreate(TaskRequest): handleUpdate(values.id, TaskRequest);
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
                <Input
                    value = {status}
                    onChange = {(e) => setStatus(e.target.value)}
                    placeholder = "Статус"
                />

            </div> 
        </Modal>
    )
}
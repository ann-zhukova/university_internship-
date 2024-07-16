import Modal from "antd/es/modal/Modal"
import Input from "antd/es/input/Input"
import { ProjectRequest } from "../services/projects";
import {useEffect ,useState } from "react";
interface Props{
    mode:Mode;
    values:Project;
    isModalOpen: boolean;
    handleCancel: ()=>void;
    handleCreate:(request: ProjectRequest) => void;
    handleUpdate: (id: number, request: ProjectRequest) => void;
}

export enum Mode{
    Create,
    Edit,
}

export const CreateUpdateProject = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}:Props) => {
    const [name, setName] = useState<string>("");
    const [status, setStatus] = useState<boolean>(false);

    useEffect(()=> {
        setName(values.name);
        setStatus(values.status);
    }, [values]);
    const handleOnOk = async()=>{
        const projectRequest = {name, status};
        mode == Mode.Create ? handleCreate(projectRequest): handleUpdate(values.id, projectRequest);
    };
    return(
        <Modal 
            title={
                mode === Mode.Create ? "Добавить проект" : "Редактировать проект"
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
                <Input
                    value = {status}
                    onChange = {(e) => setStatus(e.target.value)}
                    placeholder = "Название"
                />
            </div> 
        </Modal>
    )
}
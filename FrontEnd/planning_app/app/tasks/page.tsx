"use client";

import { useEffect, useState } from "react";
import { Tasks } from "../components/Tasks";
import { CreateUpdateTask, Mode } from "../components/CreateUpdateTask";
import { createTask, deleteTask, getAllTasks, TaskRequest, updateTask } from "../services/tasks";
import  Button  from "antd/es/button/button";

export default function TaskPage(){
    const defultValues = {
        name :"",
        status: false,
    }as Task;

    const [values, setValues] = useState<Task>({
        name :"",
        status: false,
    } as Task);

    const [isModalOpen, setModalOpen] = useState(false);
    const[mode, setMode] = useState(Mode.Create);
    const [tasks, setTasks] = useState<Task[]>([]);
    useEffect(() => {
        const getTasks = async() => {
            const tasks = await getAllTasks();
            setTasks(tasks);
        };
        getTasks();
    }, []);

    const handleCreateTask = async(request: TaskRequest)=>{
        await createTask(request);
        closeModal();

        const tasks = await getAllTasks();
        setTasks(tasks);
    }

    const handleUpdateTask = async(id: number, request: TaskRequest)=>{
        await updateTask(id, request);
        closeModal();

        const tasks = await getAllTasks();
        setTasks(tasks);
    }

    const handleDeleteTask = async(id: number)=>{
        await deleteTask(id);

        const tasks = await getAllTasks();
        setTasks(tasks);
    }

    const openModal = ()=>{
        setMode(Mode.Create);
        setModalOpen(true);
    }

    const closeModal = ()=>{
        setValues(defultValues);
        setModalOpen(false);
    }

    const openEditModal = (task: Task) => {
        setMode(Mode.Edit);
        setValues(task);
        setModalOpen(true);
    }
    return (
        <div>
            <Tasks tasks = {tasks} handleDelete={handleDeleteTask} handleOpen={openEditModal}/>
            <Button 
                onClick={openModal}
                type = "primary"
                style = {{marginTop:"38px"}}
                size ="large"
            >
                    Добавить задачу
            </Button>
            <CreateUpdateTask
            mode={mode}
            values={values}
            isModalOpen={isModalOpen}
            handleCreate={handleCreateTask}
            handleUpdate={handleUpdateTask}
            handleCancel={closeModal}
             />
        </div>
    );
}
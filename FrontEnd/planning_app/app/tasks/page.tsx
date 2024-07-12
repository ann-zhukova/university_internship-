"use client";

import { useEffect, useState } from "react";
import { Tasks } from "../components/Tasks";
import { getAllTasks } from "../services/tasks";

export default function ProjectPage(){
    const [tasks, setTasks] = useState<Task[]>([]);
    useEffect(() => {
        const getTasks = async() => {
            const tasks = await getAllTasks();
            setTasks(tasks);
        };
        getTasks();
    }, []);
    return (
        <div>
            <Tasks tasks = {tasks}/>
        </div>
    );
}
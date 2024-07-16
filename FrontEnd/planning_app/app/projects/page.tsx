"use client";

import { useEffect, useState } from "react";
import { Projects } from "../components/Projects";
import { createProject, deleteProject, getAllProjects, ProjectRequest, updateProject } from "../services/projects";
import { CreateUpdateProject, Mode } from "../components/CreateUpdateProject";
import  Button  from "antd/es/button/button";

export default function ProjectPage(){
    const defultValues = {
        name :"",
        status: false,
    }as Project;

    const [values, setValues] = useState<Project>({
        name :"",
        status: false,
    } as Project);

    const [projects, setProjects] = useState<Project[]>([]);
    const [isModalOpen, setModalOpen] = useState(false);
    const[mode, setMode] = useState(Mode.Create);

    useEffect(() => {
        const getProjects = async() => {
            const projects = await getAllProjects();
            setProjects(projects);
        };
        getProjects();
    }, []);

    const handleCreateProject = async(request: ProjectRequest)=>{
        await createProject(request);
        closeModal();

        const projects = await getAllProjects();
        setProjects(projects);
    }

    const handleUpdateProject = async(id: number, request: ProjectRequest)=>{
        await updateProject(id, request);
        closeModal();

        const projects = await getAllProjects();
        setProjects(projects);
    }

    const handleDeleteProject = async(id: number)=>{
        await deleteProject(id);

        const projects = await getAllProjects();
        setProjects(projects);
    }

    const openModal = ()=>{
        setMode(Mode.Create);
        setModalOpen(true);
    }

    const closeModal = ()=>{
        setValues(defultValues);
        setModalOpen(false);
    }

    const openEditModal = (project: Project) => {
        setMode(Mode.Edit);
        setValues(project);
        setModalOpen(true);
    }

    return (
        <div>
            <Projects projects = {projects} handleOpen={openEditModal} handleDelete={handleDeleteProject}/>
            <Button 
                onClick={openModal}
                type = "primary"
                style = {{marginTop:"38px"}}
                size ="large"
            >
                    Добавить проект
            </Button>
            <CreateUpdateProject
            mode={mode}
            values={values}
            isModalOpen={isModalOpen}
            handleCreate={handleCreateProject}
            handleUpdate={handleUpdateProject}
            handleCancel={closeModal}
             />
        </div>
    );
}
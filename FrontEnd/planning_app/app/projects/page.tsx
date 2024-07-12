"use client";

import { useEffect, useState } from "react";
import { Projects } from "../components/Projects";
import { getAllProjects } from "../services/projects";

export default function ProjectPage(){
    const [projects, setProjects] = useState<Project[]>([]);
    useEffect(() => {
        const getProjects = async() => {
            const projects = await getAllProjects();
            setProjects(projects);
        };
        getProjects();
    }, []);
    return (
        <div>
            <Projects projects = {projects}/>
        </div>
    );
}
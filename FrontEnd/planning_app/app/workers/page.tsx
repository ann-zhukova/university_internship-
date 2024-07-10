"use client";

import { useEffect, useState } from "react";
import { getAllWorkers } from "../services/workers";
import { Workers } from "../components/Workers";

export default function WorkersPage(){
    const [workers, setWorkers] = useState<Worker[]>([]);
    useEffect(() => {
        const getWorkers = async() => {
            const workers = await getAllWorkers();
            setWorkers(workers);
        };
        getWorkers();
    }, []);
    return (
        <div>
            <Workers workers = {workers}/>
        </div>
    );
}
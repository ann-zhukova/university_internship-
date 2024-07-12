import  Card  from "antd/es/card/Card"
import { CardTitle } from "./CardTitle"

interface Props{
    projects:Project[]
}
export const Projects = ({projects}:Props) =>{
    return (
        <div>
            {projects.map((project: Project) => (
                <Card 
                    key={project.id} 
                    title = {<CardTitle name = {project.name} />}
                    bordered = {false}
                >
                <p>Статус: {project.status ? 'Закончен' : 'В работе'}</p>
                </Card>
))}
        </div>
    );
};
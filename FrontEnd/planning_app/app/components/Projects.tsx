import  Card  from "antd/es/card/Card"
import { CardTitle } from "./CardTitle"
import  Button  from "antd/es/button/button";

interface Props{
    projects:Project[]
    handleDelete: (id:number)=>void;
    handleOpen:(project:Project)=> void;
}
export const Projects = ({projects, handleOpen, handleDelete}:Props) =>{
    return (
        <div className="cards">
            {projects.map((project: Project) => (
                <Card 
                    key={project.id} 
                    title = {<CardTitle name = {project.name} />}
                    bordered = {false}
                >
                <p>Статус: {project.status ? 'Закончен' : 'В работе'}</p>
                <div className="card_buttons">
                <Button 
                    onClick={()=>handleOpen(project)}
                    style = {{flex:1}}
                >
                        Изменить
                </Button>
                <Button
                    onClick={()=>handleDelete(project.id)}
                    style = {{flex:1}}
                    danger
                >
                    Удалить
                </Button>
                </div>
                </Card>
))}
        </div>
    );
};
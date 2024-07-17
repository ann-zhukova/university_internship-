import  Card  from "antd/es/card/Card"
import { CardTitle } from "./CardTitle"
import  Button  from "antd/es/button/button";
interface Props{
    tasks:Task[]
    handleDelete: (id:number)=>void;
    handleOpen:(task:Task)=> void;
}
export const Tasks = ({tasks, handleOpen, handleDelete}:Props) =>{
    return (
        <div className="cards">
            {tasks.map((task: Task) => (
                <Card 
                    key={task.id} 
                    title = {<CardTitle name = {task.name} />}
                    bordered = {false}
                >
                <p>Описание {task.description}</p>
                <p>Дата начала {task.startDate}</p>
                <p>Дата окончания {task.endDate}</p>
                <p>Проект : {task.project}</p>
                {task.workers.length != 0 && <p>Исполнители:  {task.workers.join(', ')}</p>}
                {task.dependsOnTask && <p>Зависит от задачи: {task.dependsOnTask}</p>}
                <p>Статус: {task.status ? 'Закончен' : 'В работе'}</p>
                <div className="card_buttons">
                    <Button 
                        onClick={()=>handleOpen(task)}
                        style = {{flex:1}}
                    >
                        Изменить
                    </Button>
                    <Button
                        onClick={()=>handleDelete(task.id)}
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
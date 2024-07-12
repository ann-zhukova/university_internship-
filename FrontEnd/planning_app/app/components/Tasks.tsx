import  Card  from "antd/es/card/Card"
import { CardTitle } from "./CardTitle"

interface Props{
    tasks:Task[]
}
export const Tasks = ({tasks}:Props) =>{
    return (
        <div>
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
                </Card>
))}
        </div>
    );
};
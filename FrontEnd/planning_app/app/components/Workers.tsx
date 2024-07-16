import  Card  from "antd/es/card/Card"
import { CardTitle } from "./CardTitle"

interface Props{
    workers:Worker[]
}
export const Workers = ({workers}:Props) =>{
    return (
        <div className="cards">
            {workers.map((worker: Worker) => (
                <Card 
                    key={worker.id} 
                    title = {<CardTitle name = {worker.name} />}
                    bordered = {false}
                >
                <p>Должность: {worker.position}</p>
                <p>Подразделение: {worker.department}</p>
                </Card>
))}
        </div>
    );
};
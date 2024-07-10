import  Card  from "antd/es/card/Card"
import { CardTitle } from "./CardTitle"

interface Props{
    workers:Worker[]
}
export const Workers = ({workers}:Props) =>{
    return (
        <div>
            {workers.map((worker: Worker) => (
                <Card 
                    key={worker.id} 
                    title = {<CardTitle name = {worker.name} position={worker.position} department={worker.department}/>}
                    bordered = {false}
                >
                <p>описание</p>
                </Card>
))}
        </div>
    );
};
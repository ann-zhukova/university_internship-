interface Props {
    name : string;
    position: string;
    department: string;
}
export const CardTitle = ({name, position, department}:Props) =>{
    return (
        <div style = {{
            display :"flex", 
            flexDirection:"row", 
            alignItems:"center", 
            justifyContent:"space-between",
        }}>
        <p> {name}</p>
        <p>{position}</p>
        <p> {department}</p>
        </div>
    );
};
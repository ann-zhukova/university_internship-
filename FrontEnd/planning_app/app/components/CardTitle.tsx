interface Props {
    name : string;
}
export const CardTitle = ({name}:Props) =>{
    return (
        <div style = {{
            display :"flex", 
            flexDirection:"row", 
            alignItems:"center", 
            justifyContent:"space-between",
        }}>
        <p> {name}</p>
        </div>
    );
};
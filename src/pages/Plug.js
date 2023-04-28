import DragDropFile from "./components/DragDropFile"
import Management from "../logic/Management"
const Plug = () => {
 
 Management.Do();
  return (
    <div >
      <DragDropFile />
    </div>
  );
}

export default Plug;
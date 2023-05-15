import DragDropFile from "./components/DragDropFile"
import Management from "../logic/Management"
import style from "../styles/pages/Plug.module.css"

const Plug = () => {
  return (
    <div className={style.plug}>
      <DragDropFile />
    </div>
  );
}

export default Plug;
import Cell from "./Cell.js"
import style from "../../styles/board/Board.module.css"
const  Board = (props) => {

  var cellls = new Array();
  var alt_color = true;

  const GetColor = () => {
    if (alt_color === true){
      alt_color = false;
      return 'white'
    }
    alt_color = true;
    return '#024b30'
  };

  const CreateBoard = () => {
    for(var i = 0; i < 8; i += 1 ) {
      for(var j = 0; j < 8; j += 1 )
      {
        cellls.push(<Cell Color={GetColor()} X={i} Y={j} Size={props.size} />)
      }
      GetColor();
    }
  };

  const size ={
    width: props.size * 8 ,
    height: props.size * 8,
  };

CreateBoard();
  return (
    <div style = {size} className={style.board}>
      {cellls}
    </div>
  );
}

export default Board;

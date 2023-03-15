import style from "../styles/pages/Game.module.css"
import Board from "../chess/board/Board"
import FenEncoder from "../chess/FenEncoder"
const getWidgth = () => {
  return Math.floor(window.innerWidth / 8)- 10;
}
const getFigures = () =>{
  return FenEncoder.encode("rnbqkbnr/pppppQpp/8/8/8/8/PPPPPPPP/RNBQKBNR", getWidgth());
}
const Menu = () => {
  return (
    <div>
      <div className={style.board_pos}>
        <Board size={getWidgth()} />
      </div>
      <div className={style.figures_pos}>
        {getFigures()}
      </div>
    </div>
  );
}

export default Menu;
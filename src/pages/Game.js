import style from "../styles/pages/Game.module.css"
import Board from "../chess/board/Board"
import FenEncoder from "../chess/FenEncoder"
import GameProcessor from "../logic/GameProcessor"
import Figure from "../chess/Figure.js"

const getWidgth = () => {
    return Math.floor(Math.min(window.innerWidth, window.innerHeight) / 8) - 10;
}
const map = Init();

var stream = new GameProcessor("komodo", "komodo");
stream.on('data', function(response) {
    var type = 'p';
    map.delete(response.getFrom());
    map.set(response.getTo(), new Figure(response.getTo(), type))
});
stream.on('end', function(end) {
    // stream end signal
});

const Game = () => {
    return (
        <div>
      <div className={style.board_pos}>
        <Board size={getWidgth()} />
      </div>
      <div className={style.figures_pos}>
      {Array.from(map.values()).map( obj => obj.toRender(getWidgth()))}
      </div>
    </div>
    );
}

export default Game;

function Init(){
    var map = new Map();
    //White pawns
    map.set('a2', new Figure(0, 1, 'P'));
    map.set('b2', new Figure(1, 1, 'P'));
    map.set('c2', new Figure(2, 1, 'P'));
    map.set('d2', new Figure(3, 1, 'P'));
    map.set('e2', new Figure(4, 1, 'P'));
    map.set('f2', new Figure(5, 1, 'P'));
    map.set('g2', new Figure(6, 1, 'P'));
    map.set('h2', new Figure(7, 1, 'P'));
    //Black pawns
    map.set('a7', new Figure(0, 6, 'p'));
    map.set('b7', new Figure(1, 6, 'p'));
    map.set('c7', new Figure(2, 6, 'p'));
    map.set('d7', new Figure(3, 6, 'p'));
    map.set('e7', new Figure(4, 6, 'p'));
    map.set('f7', new Figure(5, 6, 'p'));
    map.set('g7', new Figure(6, 6, 'p'));
    map.set('h7', new Figure(7, 6, 'p'));
    //Whitr figures
    map.set('a1', new Figure(0, 0, 'R'));
    map.set('b1', new Figure(1, 0, 'N'));
    map.set('c1', new Figure(2, 0, 'B'));
    map.set('d1', new Figure(3, 0, 'Q'));
    map.set('e1', new Figure(4, 0, 'K'));
    map.set('f1', new Figure(5, 0, 'B'));
    map.set('g1', new Figure(6, 0, 'N'));
    map.set('h1', new Figure(7, 0, 'R'));
    //Black figures
    map.set('a8', new Figure(0, 7, 'r'));
    map.set('b8', new Figure(1, 7, 'n'));
    map.set('c8', new Figure(2, 7, 'b'));
    map.set('d8', new Figure(3, 7, 'q'));
    map.set('e8', new Figure(4, 7, 'k'));
    map.set('f8', new Figure(5, 7, 'b'));
    map.set('g8', new Figure(6, 7, 'n'));
    map.set('h8', new Figure(7, 7, 'r'));
    return map;
  }
/*
const getFigures = () => {
    return FenEncoder.encode("rnbqkbnr/pppppQpp/8/8/8/8/PPPPPPPP/RNBQKBNR", getWidgth());
}


*/
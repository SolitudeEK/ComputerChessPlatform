import style from "../styles/pages/Game.module.css"
import Board from "../chess/board/Board"
import FenEncoder from "../chess/FenEncoder"
import GameProcessor from "../logic/GameProcessor"
import Figure from "../chess/Figure.js"
import React, { useState, useEffect } from 'react';

const Game = () => {
    const getWidgth = () => {
        return Math.floor(Math.min(window.innerWidth, window.innerHeight) / 8) - 10;
    }

    function checkCastling(from, to) {
        if (map.has('e1')) {
            if (map.get('e1').getType() === 'K' && from === 'e1') {
                if (to === 'g1') {
                    map.delete('e1');
                    map.delete('h1');
                    map.set('g1', new Figure('g1', 'K'));
                    map.set('f1', new Figure('f1', 'R'));
                    return false;
                }
                if (to === 'c1') {
                    map.delete('e1');
                    map.delete('a1');
                    map.set('g1', new Figure('c1', 'K'));
                    map.set('a1', new Figure('d1', 'R'));
                    return false;
                }
            }
        }
        if (map.has('e8')) {
            if (map.get('e8').getType() === 'k' && from === 'e8') {
                if (to === 'g8') {
                    map.delete('e8');
                    map.delete('h8');
                    map.set('g8', new Figure('g8', 'k'));
                    map.set('f8', new Figure('f8', 'r'));
                    return false;
                }
                if (to === 'c8') {
                    map.delete('e8');
                    map.delete('a8');
                    map.set('g8', new Figure('c1', 'k'));
                    map.set('a8', new Figure('d1', 'r'));
                    return false;
                }
            }
        }
        return true;
    }

    const map = Init();
    const [figures, setFigures] = useState('');
    useEffect(() => {
        setFigures(Array.from(map.values()).map(obj => obj.toRender(getWidgth())));
        console.log("game started");
        var stream = new GameProcessor("komodo", "komodo");
        stream.on('data', function(response) {
            var from = response.getFrom();
            var to = response.getTo();
            if (checkCastling(from, to)) {
                var type = map.get(from).getType();
                if (type === null) {
                    type = map.get(from).getType();
                }
                map.delete(from);
                map.delete(to);
                map.set(to, new Figure(to, type));
            }
            setFigures(Array.from(map.values()).map(obj => obj.toRender(getWidgth())));
        });
        stream.on('end', function(end) {
            //console.log(map)
        });
    }, []);

    return (
        <div>
      <div className={style.board_pos}>
        <Board size={getWidgth()} />
      </div>
      <div className={style.figures_pos}>
      {figures}
      </div>
    </div>
    );
}

export default Game;

function Init() {
    var map = new Map();
    //White pawns
    map.set('a2', new Figure('a2', 'P'));
    map.set('b2', new Figure('b2', 'P'));
    map.set('c2', new Figure('c2', 'P'));
    map.set('d2', new Figure('d2', 'P'));
    map.set('e2', new Figure('e2', 'P'));
    map.set('f2', new Figure('f2', 'P'));
    map.set('g2', new Figure('g2', 'P'));
    map.set('h2', new Figure('h2', 'P'));
    //Black pawns
    map.set('a7', new Figure('a7', 'p'));
    map.set('b7', new Figure('b7', 'p'));
    map.set('c7', new Figure('c7', 'p'));
    map.set('d7', new Figure('d7', 'p'));
    map.set('e7', new Figure('e7', 'p'));
    map.set('f7', new Figure('f7', 'p'));
    map.set('g7', new Figure('g7', 'p'));
    map.set('h7', new Figure('h7', 'p'));
    //Whitr figures
    map.set('a1', new Figure('a1', 'R'));
    map.set('b1', new Figure('b1', 'N'));
    map.set('c1', new Figure('c1', 'B'));
    map.set('d1', new Figure('d1', 'Q'));
    map.set('e1', new Figure('e1', 'K'));
    map.set('f1', new Figure('f1', 'B'));
    map.set('g1', new Figure('g1', 'N'));
    map.set('h1', new Figure('h1', 'R'));
    //Black figures
    map.set('a8', new Figure('a8', 'r'));
    map.set('b8', new Figure('b8', 'n'));
    map.set('c8', new Figure('c8', 'b'));
    map.set('d8', new Figure('d8', 'q'));
    map.set('e8', new Figure('e8', 'k'));
    map.set('f8', new Figure('f8', 'b'));
    map.set('g8', new Figure('g8', 'n'));
    map.set('h8', new Figure('h8', 'r'));
    return map;
}


/*
const getFigures = () => {
    return FenEncoder.encode("rnbqkbnr/pppppQpp/8/8/8/8/PPPPPPPP/RNBQKBNR", getWidgth());
}


*/
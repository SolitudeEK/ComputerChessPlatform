import pawnD from "./pics/pawnD.png"
import rookD from "./pics/rookD.png"
import queenD from "./pics/queenD.png"
import kingD from "./pics/kingD.png"
import knightD from "./pics/knightD.png"
import bishopD from "./pics/bishopD.png"
import pawnW from "./pics/pawnW.png"
import rookW from "./pics/rookW.png"
import queenW from "./pics/queenW.png"
import kingW from "./pics/kingW.png"
import knightW from "./pics/knightW.png"
import bishopW from "./pics/bishopW.png"
const {PosEncoder} = require('./PosEncoder');

class Figure{
	constructor(x, y, type){
		this.x = x;
		this.y = y;
		this.type = type;
	}

	ChangeType(type){
		this.type = type;
	}

	ChangePos(pos){
		var newPos = PosEncoder.ToDec(pos);
		this.x = newPos[0];
		this.y = newPos[1];
	}
	toRender(mlt){
		return (<img src={this.toFigure()} alt='chess figure' style = {this.position(mlt)} />);
	}
	position(mlt){
		return {
		position: "absolute",
		top: mlt * this.y,
		left: mlt * this.x,
		width: (mlt*0.95)+"px"
			};
	}
	toFigure(){
			switch(this.type){
			case 'p':
				return pawnD;
				break;
			case 'r':
				return rookD;
				break;
			case 'b':
				return bishopD;
				break;
			case 'k':
				return kingD;
				break;
			case 'q':
				return queenD;
				break;
			case 'n':
				return knightD;
				break;
			case 'P':
				return pawnW;
				break;
			case 'R':
				return rookW;
				break;
			case 'B':
				return bishopW;
				break;
			case 'K':
				return kingW;
				break;
			case 'Q':
				return queenW;
				break;
			case 'N':
				return knightW;
				break;
			}
	}
}
export default Figure;
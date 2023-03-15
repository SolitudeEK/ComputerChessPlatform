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


class FenEncoder{
	static encode(notation, mlt){
		var pos = 0;
		var otp = [];
		var cells = notation.split('');
		while(pos < 64){
			if(cells[0]=='/'){
				cells.shift();
			}
			if (+cells[0] === +cells[0]){
				pos +=Number(cells[0]);
			}
			else
			{
				otp.push(<img src={this.toFigure(cells[0])} alt='chess figure' style = {this.position(pos, mlt)} />);
				pos++;

			}
			cells.shift();
		}
		return otp;

	}

	static position(pos, mlt){
		return {
		position: "absolute",
		top: mlt * Math.floor(pos / 8),
		left: mlt * (pos % 8),
		width: (mlt*0.95)+"px"
		//objectFit: "scale-down"
			};
	}

	static toFigure(cell){
			switch(cell){
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
export default FenEncoder;
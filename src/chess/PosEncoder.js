class PosEncoder {
    static ToDec(pos) {
    	var x =  this.toX(pos[0]);
    	var y = 8 - parseInt(pos[1]);
        return { x, y };
    }
    static toX(letter) {
        switch (letter) {
            case 'a':
                return 0;
            case 'b':
                return 1;
            case 'c':
                return 2;
            case 'd':
                return 3;
            case 'e':
                return 4;
            case 'f':
                return 5;
            case 'g':
                return 6;
            case 'h':
                return 7;
             default:
             	return null;
        }

    }

}
export default PosEncoder;
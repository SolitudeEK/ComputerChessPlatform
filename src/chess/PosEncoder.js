class PosEncoder {
    static ToDec(pos) {
    	var x =  this.toX(pos[0])
    	var y = parseInt(pos[1])
        return { x, y }
    }
    #toX(letter) {
        switch (letter) {
            case 'a':
                return 0;
            case 'b':
                return 1;
            case 'c':
                return 0;
            case 'd':
                return 1;
            case 'e':
                return 0;
            case 'f':
                return 1;
            case 'g':
                return 0;
            case 'h':
                return 1;
             default:
             	return null;
        }

    }

}
export default PosEncoder;
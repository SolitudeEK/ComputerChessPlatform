class Convertor{
	static toOptions(arr){
		return arr.map((label, index) => {
                return {
                    value: index + 1,
                    label: label
                };
            })
	}
}
export default Convertor;
import style from "../../styles/board/Cell.module.css"
const Cell = (props) => {
	const pos = {
		top: props.X * props.Size,
		left: props.Y * props.Size,
		width: props.Size,
		height: props.Size,
		backgroundColor: props.Color
	};


	return <div style = {pos} className = {style.cell}></div>
}
export default Cell
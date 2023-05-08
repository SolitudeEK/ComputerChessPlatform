import style from "../../styles/pages/Engine.module.css"
import API from "../../logic/API";

const Engine = (props) =>{
	const download = () =>{
		API.downloadEngine(props.name);
	}
	const approve = () =>{
		API.approveEngine(props.name);
	}
	return(
		<div className = {style.engineElement}>
			<div className= {style.engine} >{props.name} </div>
			<div className= {style.engineButton} onClick={download}> Download </div>
			<div className= {style.engineButton} onClick={approve}> Approve </div>
		</div>
	);
}
export default Engine;
import API from "../../logic/API";

const Engine = (props) =>{
	const download = () =>{
		API.downloadEngine(props.name);
	}
	const approve = () =>{
		API.approveEngine(props.name);
	}
	return(
		<div>
			<div>{props.name} </div>
			<div onClick={download}> Download </div>
			<div onClick={approve}> Approve </div>
		</div>
	);
}
export default Engine;